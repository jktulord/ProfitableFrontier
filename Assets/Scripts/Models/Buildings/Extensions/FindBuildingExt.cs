using Assets.Scripts.Models.Buildings.Kinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Buildings.Extensions
{
    public static class FindBuildingExt
    {
        public static IBuilding FindBuildingWithSpace(this List<BaseBuilding> Buildings)
        {
            IBuilding buffer = null;
            foreach (IBuilding cur in Buildings)
            {
                if (cur.Kind == BuildingKind.House)
                {
                    House house = (House)cur;
                    if (house.Occupants.Count < house.MaxOccupants)
                        buffer = cur;
                }
            }
            return buffer;
        }

        public static IBuilding FindBuildingByPos(this List<BaseBuilding> Buildings, Vector3Int pos)
        {
            IBuilding buffer = null;
            foreach (IBuilding cur in Buildings)
            {
                if (cur.Pos == pos)
                    buffer = cur;
            }
            return buffer;
        }

        public static IBuilding FindMedicalWithPower(this List<BaseBuilding> Buildings)
        {
            IBuilding buffer = null;
            foreach (IBuilding cur in Buildings)
            {
                if (cur.Kind == BuildingKind.Medical)
                {
                    MedicalBuilding medical = (MedicalBuilding)cur;
                    if (0 < medical.RecoveryPower - medical.LastRecoveryPower)
                    {
                        buffer = cur;
                    }
                }
                    
            }
            return buffer;
        }

        public static IBuilding FindTradPostWithPower(this List<BaseBuilding> Buildings)
        {
            IBuilding buffer = null;
            foreach (IBuilding cur in Buildings)
            {
                if (cur.Kind == BuildingKind.TradePost)
                {
                    TradePostBuilding tradePost = (TradePostBuilding)cur;
                    if (0 < tradePost.TradePower - tradePost.Loot)
                    {
                        buffer = cur;
                    }
                }
                
            }
            return buffer;
        }

        public static IBuilding FindFoodBuildingWithPower(this List<BaseBuilding> Buildings)
        {
            IBuilding buffer = null;
            foreach (BaseBuilding cur in Buildings)
            {
                if (cur.Kind == BuildingKind.Food)
                {
                    FoodStalls current = (FoodStalls)cur;
                    if (0 < current.ServicePower - current.LastServicePower)
                    {
                        buffer = cur;
                    }
                }

            }
            return buffer;
        }

        public static BaseBuilding FindTownHouse(this List<BaseBuilding> Buildings)
        {
            BaseBuilding buffer = null;
            foreach (BaseBuilding cur in Buildings)
            {
                if (cur.Kind == BuildingKind.TownHouse)
                    buffer = cur;
            }
            return buffer;
        }

        public static List<BaseBuilding> FindAllByKind(this List<BaseBuilding> Buildings, BuildingKind buildingKind)
        {
            List<BaseBuilding> buffer = new List<BaseBuilding>();
            foreach (BaseBuilding cur in Buildings)
            {
                if (cur.Kind == buildingKind)
                    buffer.Add(cur);
            }
            return buffer;
        }

        

    }
}

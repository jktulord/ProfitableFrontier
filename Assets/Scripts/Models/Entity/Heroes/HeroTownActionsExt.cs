using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Entity.Heroes.Needs;
using Assets.Scripts.Models.Heroes;
using Assets.Scripts.ResInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Entity.Heroes
{
    public static class HeroTownActionsExt
    {
        public static void Rest(this Hero hero)
        {
            MedicalBuilding building = (MedicalBuilding)hero.HeroSystem.PlayerSystem.Player.Buildings.FindMedicalWithPower();
            if (building != null)
            {
                int hpDifference = hero.Hp.Max - hero.Hp.Amount;
                int recoveryDifference = building.RecoveryPower - building.LastRecoveryPower;
                if (recoveryDifference < hpDifference)
                {
                    hpDifference = recoveryDifference;
                }
                hero.Hp.Amount += hpDifference;
                building.Inventory.Silver += hpDifference;
                building.LastRecoveryPower += hpDifference;
                hero.Silver -= hpDifference;
            }
        }

        public static void Trade(this Hero hero)
        {
            TradePostBuilding building = (TradePostBuilding)hero.HeroSystem.PlayerSystem.Player.Buildings.FindTradPostWithPower();
            if (building != null)
            {
                int LootDifference = hero.Loot;
                //Hp.Amount = Hp.Max;
                int TradeDifference = building.TradePower - building.Loot;
                if (TradeDifference < LootDifference)
                {
                    LootDifference = TradeDifference;
                }
                building.Loot += LootDifference;
                hero.Loot -= LootDifference;
                hero.Silver += LootDifference;
            }
        }

        public static void BuyFood(this Hero hero)
        {
            FoodStalls building = (FoodStalls)hero.HeroSystem.PlayerSystem.Player.Buildings.FindFoodBuildingWithPower();
            if (building != null)
            {
                if (building.LastServicePower < building.ServicePower)
                {

                    hero.Silver -= building.SellCost;
                    building.Inventory.Silver += building.SellCost;
                    hero.Needs.Base[NeedKind.Food].Amount = 100;
                    building.Player.Inventory.Res[ResKind.Fish].Amount -= 1;
                    Debug.Log(hero + " eaten something");
                    
                }
            }
        }

        public static void EnteringDungeon(this Hero hero)
        {
            hero.HeroSystem.HeroEnterDungeon(hero);
        }

        public static void ReturnToTown(this Hero hero)
        {
            hero.Action = HeroActions.Slacking;
        }
    }
}

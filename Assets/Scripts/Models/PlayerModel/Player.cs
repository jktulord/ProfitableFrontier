using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.PlayerModel.Stats;
using Assets.Scripts.ResInventory;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;

namespace Assets.Scripts.Models.PlayerModel
{
    public class Player
    {
        public PlayerSystem PlayerSystem;

        public string Name;

        // Stats
        public ActionPoints AP;
        //public BuildLimit BuildLimit;
        public Workers Workers;

        //Status 
        public bool Hungry = true;

        // Upgrades
        public bool CanHireWorkers;

        // Settings
        public bool IsAutoTurn;
        public ResKind AutoSpendRes;


        public Inventory Inventory;
        public List<BaseBuilding> Buildings;

        public Player(PlayerSystem playerSystem)
        {
            PlayerSystem = playerSystem;

            CanHireWorkers = false;
            IsAutoTurn = false;
            AutoSpendRes = ResKind.Null;

            Name = "Player";

            AP = new ActionPoints(3);
            //BuildLimit = new BuildLimit(3);
            Workers = new Workers(0);

            Inventory = new Inventory();
            Inventory.Res[ResKind.Wood].Amount += 30;
            Inventory.Silver = 100;
            Buildings = new List<BaseBuilding>()
            {
               GetPresetBuilding.TownHouse(new Vector3Int(-2,1,0), this),
               GetPresetBuilding.Dungeon(new Vector3Int(-8,1,0), this)
            };
            
        }
        
        

        public void NextTurn()
        {
            if (Inventory.Res[ResKind.Fish].Amount <= 0)
            {
                Hungry = true;
                AP.CurrentMax = AP.Max - 1;
            } 
            else
            {
                Hungry = false;
                Inventory.Res[ResKind.Fish].Amount -= 1;
                AP.CurrentMax = AP.Max;
            }
            int autoSpendAP = AP.Value;
            for (int i = 0; i < autoSpendAP; i++)
            {
                if (AutoSpendRes == ResKind.Fish)
                {
                    FishingAction();
                }
                else if (AutoSpendRes == ResKind.Wood)
                {
                    ChoppingAction();
                }
            }
            AP.Value = AP.CurrentMax;
        }

        public bool FishingAction()
        {
            if (AP.Spend(1))
            {
                Inventory.Res[ResKind.Fish].Amount += 5;
                return true;
            }
            else
            {
                AutoTurnCheck();
                return false;
            }
        }

        public bool ChoppingAction()
        {
            if (AP.Spend(1))
            {
                Inventory.Res[ResKind.Wood].Amount += 5;
                return true;
            }
            else
            {
                AutoTurnCheck();
                return false;
            }
        }

        public bool BuildBuilding(Vector3Int pos, BaseBuilding building)
        {
            if (AP.Spend(1) && (Inventory.Res[building.BuildCost.Name].Amount >= building.BuildCost.Amount))
            {
                Inventory.Res[building.BuildCost.Name].Amount -= building.BuildCost.Amount;
                Buildings.Add(building);
                return true;
            }
            else
            {
                AutoTurnCheck();
                return false;
            }
        }

        public bool UpgradeConfirmation(BaseBuilding building)
        {
            ResKind resKind = building.UpgradeBuildCost[building.Tier].Name;
            if (AP.Spend(1) && (Inventory.Res[resKind].Amount >= building.UpgradeBuildCost[building.Tier].Amount))
            {
                Inventory.Res[resKind].Amount -= building.UpgradeBuildCost[building.Tier].Amount;
                return true;
            }
            else
            {
                AutoTurnCheck();
                return false;
            }
            
        }

        public bool CollectConfirmation(BaseBuilding building)
        {
            if (!building.Inventory.IfEmpty())
            {
                if (AP.Spend(1))
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                AutoTurnCheck();
                return false;
            }
            
        }

        public void AutoTurnCheck()
        {
            Debug.Log("AutoTurnCheck ");
            if (IsAutoTurn == true)
            {
                Debug.Log("AutoTurnCheck worked");
                PlayerSystem.NextTurn();
            }
        }

    }
}

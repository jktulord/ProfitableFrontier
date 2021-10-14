using Assets.Scripts.Models.Heroes;
using Assets.Scripts.ResInventory;
using Assets.Scripts.Models.PlayerModel;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Models.Buildings.Kinds
{
    public class WorkerHouse : BaseBuilding, IBuilding
    {

        public int WorkerLimit;
        public int[] UpgradeWorkerLimit;


        public WorkerHouse(Player player, string name,
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            int workerLimit = 0,
            int[] upgradeWorkerLimit = null) 
            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {
     
            Kind = BuildingKind.WorkerHouse;
            Tier = 0;

            WorkerLimit = workerLimit;
            UpgradeWorkerLimit = upgradeWorkerLimit;

            Inventory = new Inventory();

            //DaylyEarning = daylyEarning;
            //UpgradeDaylyEarnings = upgradeDaylyEarnings;
            //Occupants.Add(new Hero());
        }

        public new void Upgrade()
        {
            if (UpgradeTiles != null)
            {
                if (UpgradeTiles.Length > Tier)
                {
                    if (Player.UpgradeConfirmation(this))
                    {
                        Tile = UpgradeTiles[Tier];

                        if (UpgradeDescriptions != null)
                            Description = UpgradeDescriptions[Tier];

                        if (UpgradeWorkerLimit != null)
                            WorkerLimit = UpgradeWorkerLimit[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }
    }
}

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
    public class TownHouseBuilding : BaseBuilding, IBuilding
    {

        public TownHouseBuilding(Player player, string name,
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null) 
            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {
     
            Kind = BuildingKind.TownHouse;
            Tier = 0;

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

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }
    }
}

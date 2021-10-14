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
    public class ResourceBuilding : BaseBuilding, IBuilding
    {

        public Resource DaylyEarning;
        public Resource[] UpgradeDaylyEarnings;

     

        public new string AccumulatedDescriptionLine
        {
            get {
                return  "" + Inventory.Res[DaylyEarning.Name].Name + ":" + Inventory.Res[DaylyEarning.Name].Amount; 
;
            }
        }

        public ResourceBuilding(Player player, string name,
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            Resource daylyEarning = null, Resource[] upgradeDaylyEarnings = null) 

            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {

            Kind = BuildingKind.Resource;
            Tier = 0;

            DaylyEarning = daylyEarning;
            UpgradeDaylyEarnings = upgradeDaylyEarnings;

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

                        if (UpgradeDaylyEarnings != null)
                            DaylyEarning = UpgradeDaylyEarnings[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }

        public new void NextTurn(bool IfMarketDay = true)
        {
            Inventory += DaylyEarning;
            Debug.Log(DaylyEarning.Name + " " + DaylyEarning.Amount + "Earned");
        }
    }
}

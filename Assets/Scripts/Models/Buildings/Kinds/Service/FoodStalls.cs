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
    public class FoodStalls : BaseBuilding, IBuilding
    {
        public int SellCost;
        public int FoodTier;

        public Resource UsingResource;

        public int ServicePower;
        public int[] UpgradeServicePower;
        public int LastServicePower;

        public new string PropertyDescriptionLine { 
            get { return "People Served last turn: " + LastServicePower + "/" + ServicePower; }
        }

        public new string AccumulatedDescriptionLine { 
            get { return "Stored: " + Inventory.Silver + " Silver"; } 
        }
        
        public FoodStalls(Player player, string name, 
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            int sellCost = 0, int foodTier = 0,
            Resource usingResource = null,
            int servicePower = 0, int[] upgradeServicePower = null)
            
            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {

            Kind = BuildingKind.Food;
            Tier = 0;

            SellCost = sellCost;
            FoodTier = foodTier;
            UsingResource = usingResource;

            ServicePower = servicePower;
            UpgradeServicePower = upgradeServicePower;
            LastServicePower = 0;

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

                        if (UpgradeServicePower != null)
                            ServicePower = UpgradeServicePower[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }

        public new void NextTurn(bool IfMarketDay = true)
        {
            LastServicePower = 0;
        }
    }
}

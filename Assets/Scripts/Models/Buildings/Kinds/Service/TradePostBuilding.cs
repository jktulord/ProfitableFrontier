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
    public class TradePostBuilding : BaseBuilding, IBuilding
    {
        public int TradePower;
        public int[] UpgradeTradePower;
        public int Loot;

        public new string PropertyDescriptionLine
        {
            get { return "Loot in the storage: " + Loot + "/" + TradePower; }
        }

        public new string AccumulatedDescriptionLine
        {
            get { return "Stored: " + Inventory.Silver + " Silver"; }
        }

        public TradePostBuilding(Player player, string name,
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            int tradePower = 0, int[] upgradeTradePower = null) 

            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {
            Kind = BuildingKind.TradePost;
            Tier = 0;

            TradePower = tradePower;
            UpgradeTradePower = upgradeTradePower;

            Inventory = new Inventory();
            Loot = 0;

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

                        if (UpgradeTradePower != null)
                            TradePower = UpgradeTradePower[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }

        public new void NextTurn(bool IfMarketDay = true)
        {
            Inventory.Silver += Loot;
            Loot = 0;
        }
    }
}

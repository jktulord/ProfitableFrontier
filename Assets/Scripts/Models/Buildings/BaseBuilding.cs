using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Heroes;
using Assets.Scripts.Models.PlayerModel;
using Assets.Scripts.ResInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Models.Buildings
{
    public enum BuildingKind
    {
        House, 
        Resource, Storage, 
        Medical, TraingGround, 
        TradePost, Market, Food, Tavern,
        WorkerHouse, TownHouse, Dungeon, Null
    }

    public class BaseBuilding : IBuilding
    {

        public Player Player { get; set; }

        public string Name { get; set; }
        public BuildingKind Kind { get; set; }

        public string Description { get; set; }
        public string[] UpgradeDescriptions { get; set; }

        public int Tier { get; set; }

        public Tile Tile { get; set; }
        public Tile[] UpgradeTiles { get; set; }

        public Resource BuildCost { get; set; }
        public Resource[] UpgradeBuildCost { get; set; }

        public Inventory Inventory { get; set; }

        public Vector3Int Pos { get; set; }

        public string PropertyDescriptionLine { get { return ""; } }

        public string AccumulatedDescriptionLine { get { return ""; } }

        public BaseBuilding(Player player, string name,
            string description,
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null, 
            Resource[] upgradeBuildCost = null)
        {
            
            Player = player;

            Kind = BuildingKind.Dungeon;
            Name = name;
            Description = description;
            UpgradeDescriptions = upgradeDescriptions;
            Pos = pos;
            Tier = 0;

            Tile = tile;
            UpgradeTiles = upgradeTiles;

            BuildCost = buildCost;
            UpgradeBuildCost = upgradeBuildCost;

            /*
            MaxOccupants = maxOccupants;
            UpgradeMaxOccupants = upgradeMaxOccupants;
            */
            
            Inventory = new Inventory();

            //DaylyEarning = daylyEarning;
            //UpgradeDaylyEarnings = upgradeDaylyEarnings;
            //Occupants.Add(new Hero());
        }


        public void NextTurn(bool IfMarketDay = true)
        {
           
        }

        public void Upgrade()
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

        public void Collect()
        {
            if (Player.CollectConfirmation(this))
            {
                Player.Inventory += Inventory;
                Inventory.Clear();
                Player.PlayerSystem.Refresh();
            }
            
        }

    }
}

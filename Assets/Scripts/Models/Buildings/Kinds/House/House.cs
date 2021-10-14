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
    public class House : BaseBuilding, IBuilding
    {

        public int MaxOccupants;
        public int[] UpgradeMaxOccupants;

        public int HouseQuality;
        public int[] UpgradeHouseQuality;

        public List<Hero> Occupants;

        public new string PropertyDescriptionLine
        {
            get { return "Occupants:" + Occupants.Count + "/" + MaxOccupants; }
        }

        public new string AccumulatedDescriptionLine
        {
            get { return "Stored: " + Inventory.Silver + " Silver"; }
        }

        public House(Player player, string name, 
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            int maxOccupants = 0, int[] upgradeMaxOccupants = null,
            int houseQuality = 0, int[] upgradeHouseQuality = null) 
            
            : base(player, name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {

            Kind = BuildingKind.House;
            Tier = 0;

            MaxOccupants = maxOccupants;
            UpgradeMaxOccupants = upgradeMaxOccupants;

            HouseQuality = houseQuality;
            UpgradeHouseQuality = upgradeHouseQuality;

            Occupants = new List<Hero>();
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

                        if (UpgradeMaxOccupants != null)
                            MaxOccupants = UpgradeMaxOccupants[Tier];
                        
                        if (UpgradeHouseQuality != null)
                            HouseQuality = UpgradeHouseQuality[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }

        public new void NextTurn(bool IfMarketDay = true)
        {
            foreach (Hero hero in Occupants)
            {
                hero.Silver -= 1;
                Inventory.Silver += 1;
            }
        }
    }
}

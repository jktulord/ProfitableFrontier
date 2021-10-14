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
    public class MedicalBuilding : BaseBuilding, IBuilding
    {

        public int RecoveryPower;
        public int[] UpgradeRecoveryPower;
        public int LastRecoveryPower;

        public new string PropertyDescriptionLine
        {
            get { return "Hp used this turn: " + LastRecoveryPower + "/" + RecoveryPower; }
        }

        public new string AccumulatedDescriptionLine
        {
            get { return "Stored: " + Inventory.Silver + " Silver"; }
        }

        public MedicalBuilding(Player player, string name, 
            string description, 
            Vector3Int pos, Tile tile, Resource buildCost,
            string[] upgradeDescriptions = null,
            Tile[] upgradeTiles = null,
            Resource[] upgradeBuildCost = null,
            int recoveryPower = 0, int[] upgradeRecoveryPower = null) 
            
            : base(player,name, description, pos,
            tile, buildCost, upgradeDescriptions,
            upgradeTiles, upgradeBuildCost)
        {
            Kind = BuildingKind.Medical;
            Tier = 0;

            RecoveryPower = recoveryPower;
            UpgradeRecoveryPower = upgradeRecoveryPower;
            LastRecoveryPower = 0;

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
                        
                        if (UpgradeRecoveryPower != null)
                            RecoveryPower = UpgradeRecoveryPower[Tier];

                        Tier += 1;
                        Debug.Log("Upgraded to Tier " + Tier);
                        Player.PlayerSystem.Refresh();
                    }
                }
            }
        }

        public new void NextTurn(bool IfMarketDay = true)
        {
            LastRecoveryPower = 0;
        }
    }
}

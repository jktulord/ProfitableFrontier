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
    public interface IBuilding
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

        public string PropertyDescriptionLine { get; }
        public string AccumulatedDescriptionLine { get; }

        public void NextTurn(bool IfMarketDay = true);

        public void Upgrade();

        public void Collect();
    }
}

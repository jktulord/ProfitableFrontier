using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SystemScripts.Actions
{
    public static class BuildActions
    {
        public static void Build(TileSystem TileSystem, PopUpSystem PopUpSystem, PlayerSystem PlayerSystem,  Vector3Int pos, BaseBuilding baseBuilding)
        {
            if (!TileSystem.IfSpaceOccupied(pos))
            {
                if (PlayerSystem.Player.BuildBuilding(pos, baseBuilding))
                {
                    PlayerSystem.Refresh();
                    //PopUpSystem.ShowBetterAknowledgeMessage("Tent is built. $" +
                    //   "Heroes live here $");
                }
                else
                {
                    PopUpSystem.ShowAknowledgeMessage("Insuficient resources or AP");
                }
            }
            else
            {
                Debug.Log("Space is occupied");
            }
        }

       
    }
}

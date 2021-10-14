using Assets.Scripts.Models.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SystemScripts.Actions
{
    public static class ActActions
    {
        public static void Fishing(PopUpSystem PopUpSystem, PlayerSystem PlayerSystem)
        {
            if (PlayerSystem.Player.FishingAction())
            {
                PlayerSystem.Refresh();
                //PopUpSystem.ShowAknowledgeMessage("You were working hard to get your food. Got 3 fish ");
            }
            else
            {
                PopUpSystem.ShowAknowledgeMessage("Insuficient AP");
            }
        }

        public static void Chopping(PopUpSystem PopUpSystem, PlayerSystem PlayerSystem)
        {
            if (PlayerSystem.Player.ChoppingAction())
            {
                PlayerSystem.Refresh();
                //PopUpSystem.ShowAknowledgeMessage("You were working hard to get some wood. Got 3 wood ");
            }
            else
            {
                PopUpSystem.ShowAknowledgeMessage("Insuficient AP");
            }
        }
    }
}

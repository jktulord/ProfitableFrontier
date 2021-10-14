using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SystemScripts.Actions
{
    public static class MiscActions
    {
        public static void Help(PopUpSystem popUpSystem)
        {
            popUpSystem.ShowBetterAknowledgeMessage("----Game Basics----$" +
                "AP(action points)$" +
                "The game is turn-based. Every turn you get a certain amount of AP.$$" +
                "You spend can spend it on actions, like build buildings and gather resources.$$" +
                "Collecting resources from buildings also spends AP$" +
                "*If you don't have any food, your AP will get lower.$" +
                "*You can get more AP by upgrading your Townhouse.$" +
                "$" +
                "HEROES$" +
                "They are here to fight monsters in the dungeon and they are the main source of your silver. $$" +
                "New heroes come every turn, but only if you have enough houses. $$" +
                "Firstly they go to dungen, what depletes their hp and gives them loot. $$" +
                "Hp is restored in hospitals and Loot is sold in Tradeposts. $$" +
                "Silver given to those buidligs in exchange for service is yours. $$" +
                "Heroes also pay rent.$");
        }
    }
}

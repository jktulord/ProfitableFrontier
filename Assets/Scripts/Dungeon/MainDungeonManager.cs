using Assets.Scripts.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Dungeon
{
    public class MainDungeonManager : MonoBehaviour
    {
        public BattleLogScript LogPanel;

        public BattleSpace[] BattleSpaces;

        private PopUpSystem PopUpSystem;
        private HeroSystem HeroSystem;

        public string LogText;

        [Inject]
        private void Construct(PopUpSystem popUpSystem, HeroSystem heroSystem)
        {
            PopUpSystem = popUpSystem;
            HeroSystem = heroSystem;
        }

        public void Init()
        {
            foreach (BattleSpace battleSpace in BattleSpaces)
            {
                battleSpace.MainDungeonManager = this;
                battleSpace.Load();
            }
        }

        void Start()
        {
            Init();
            
        }

        public void BattleLogAdd(string text)
        {
            LogPanel.AddLine(text);
        }

        /*
        public void BattleLogRefresh()
        {
            LogPanel.AddLine(LogText);
        }
        */

        public void BattleLogClear()
        {
            LogPanel.Clear();
        }

        public void MoveHeroToNextLocation(Hero hero, BattleSpace previousBattleSpace)
        {
            int i = Array.IndexOf(BattleSpaces, previousBattleSpace);
            if (i+1 < BattleSpaces.Length)
            {
                Debug.Log(hero.Name + " movement step 2 " + BattleSpaces[i].Name);
                BattleSpaces[i + 1].HeroMoveHere(hero, previousBattleSpace);
            }
               
        }

        public void NextTurn()
        {
            BattleLogClear();
            foreach (BattleSpace battleSpace in BattleSpaces)
            {
                battleSpace.Turn();
            }

            //BattleLogRefresh();
        }

        public void HeroEnter(Hero hero)
        {
            if (BattleSpaces[0].Heroes.Count < BattleSpaces[0].HeroSpots.Length)
            {
                BattleSpaces[0].Heroes.Add(hero);
                BattleSpaces[0].Refresh();
            }
        }



        
        
        
    }
}

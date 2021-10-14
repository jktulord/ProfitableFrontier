using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Entity;
using Assets.Scripts.Models.Entity.BaseStats;
using Assets.Scripts.Models.Entity.Heroes;
using Assets.Scripts.Models.Entity.Heroes.Needs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Models.Heroes
{
    public enum HeroActions
    {
        Slacking, EnteringDungeon, Dungeon, Recover, Trade, BuyFood
    }

    public class Hero : EntityBase
    {
        public HeroSystem HeroSystem;
        public PopUpSystem PopUpSystem;

        public House Home; 

        public NeedsSystem Needs;

        public int Silver;
        public int Loot;

        public HeroActions Action;

        public Hero(HeroSystem heroSystem, PopUpSystem popUpSystem)
        {
            HeroSystem = heroSystem;
            PopUpSystem = popUpSystem;

            Name = Namer.GetRandName();
            List<Sprite> Sprites = new List<Sprite>();
            Sprites.Add(Resources.Load<Sprite>("Sprites/DungeonSprites/Hunter"));
            Sprites.Add(Resources.Load<Sprite>("Sprites/DungeonSprites/Mage"));
            Sprites.Add(Resources.Load<Sprite>("Sprites/DungeonSprites/Warrior"));
            Sprite = Sprites[Random.Range(0, Sprites.Count)];
            Action = HeroActions.Slacking;

            Level = new Level();
            Hp = new Hp(10);
            Attack = new Attack(1, 1);

            Silver = 10;
            Loot = 0;

            Needs = new NeedsSystem(this);

        }

        public void ShowStats()
        {
            PopUpSystem.ShowHeroStats(this);
        }

        public void NextTurn()
        {
            NeedsCalculation();
            Decision();
            Acting();

        }

        public void NeedsCalculation()
        {
            Needs.Base[NeedKind.Food].Amount -= 5;
            if (Home != null)
            {
                Needs.Base[NeedKind.Housing].Amount = Home.HouseQuality;
            }
            else
            {
                Needs.Base[NeedKind.Housing].Amount = 0;
            }
        }

        public void Decision()
        {
            
            if ((Action == HeroActions.EnteringDungeon) || (Action == HeroActions.Dungeon))
            {
                Action = HeroActions.Dungeon;
            }
            else if (Needs.Base[NeedKind.Food].Amount < 30)
            {
                Action = HeroActions.BuyFood;
            }
            else if (Hp.Amount < Hp.Max / 4)
            {
                Action = HeroActions.Recover;
            }
            else if (Loot > 10)
            {
                Action = HeroActions.Trade;
            }
            else
            {
                Action = HeroActions.EnteringDungeon;
            }
        }

        public void Acting()
        {
            switch (Action)
            {
                case HeroActions.Recover:
                    this.Rest();
                    break;
                case HeroActions.Trade:
                    this.Trade();
                    break;
                case HeroActions.EnteringDungeon:
                    this.EnteringDungeon();
                    break;
                case HeroActions.BuyFood:
                    this.BuyFood();
                    break;  
            }
        }
        
        
    }
}

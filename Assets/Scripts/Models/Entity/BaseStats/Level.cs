using Assets.Scripts.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Entity.BaseStats
{
    public class Level
    {
        public int Current;
        
        public int CurExp;
        public int[] ExpCaps = new int[6] { 5, 10, 15, 20, 25, 30 } ;

        public int[] Hp = new int[6] { 5, 11, 17, 23, 29, 35 };

        public int[] BaseAttack = new int[6] { 1, 2, 3, 4, 5, 6 };

        public int[] AdditonalAttack = new int[6] { 5, 11, 17, 23, 29, 35 };

        public Level(int current = 0)
        {
            Current = current;
        }

        public void LevelUp(Hero hero)
        {
            CurExp -= ExpCaps[Current]; // 1: 5 43 2 76| 6: 4 66 1 92| 8: 3 19 
            Current += 1;
            hero.Hp.Max = Hp[Current];
            hero.Attack.BaseValue = BaseAttack[Current];
            hero.Attack.AddValue = AdditonalAttack[Current];
        }

        public void LevelUpCheck(Hero hero)
        {
            if (Current < ExpCaps.Length)
                if (CurExp >= ExpCaps[Current])
                {
                    LevelUp(hero);
                }
        }
    }   
}

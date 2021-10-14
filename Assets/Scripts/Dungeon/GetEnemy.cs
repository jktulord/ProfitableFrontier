using Assets.Scripts.Models.Entity.BaseStats;
using Assets.Scripts.Models.Entity.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Dungeon
{
    public static class GetEnemy
    {
        public static Enemy Goblenlv1()
        {
            return new Enemy("Goblen", 1, 4, new Attack(1, 0), 1, 2);
        }
        public static Enemy HobGoblenlv3()
        {
            return new Enemy("HobGoblen", 3, 7, new Attack(1, 2), 3, 5);
        }
        public static Enemy Goblenlv2()
        {
            return new Enemy("Goblen", 2, 6, new Attack(2, 1), 3, 5);
        }
        public static Enemy HobGoblenlv5()
        {  
            return new Enemy("HobGoblen", 3, 9, new Attack(2, 3), 5, 10);
        }
    }
}

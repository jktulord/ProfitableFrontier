using Assets.Scripts.Models.Entity;
using Assets.Scripts.Models.Entity.Heroes;
using Assets.Scripts.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Dungeon
{
    public static class BattleActions
    {
        public static void EscapeFromDungeon(BattleSpace BattleSpace, Hero Hero)
        {
            MainDungeonManager MainDungeonManager = BattleSpace.MainDungeonManager;

            int Dodge = Random.Range(1, 21);

            if (Dodge > 10)
            {
                MainDungeonManager.BattleLogAdd(Hero.Name + " Escaped (" + Dodge + ")");
                Hero.ReturnToTown();
                BattleSpace.Heroes.Remove(Hero);
            }
            else
            {
                MainDungeonManager.BattleLogAdd(Hero.Name + " Tries to escape (" + Dodge + ")");
            }
        }

        public static void AttackEntity(BattleSpace BattleSpace, EntityBase Attacker, EntityBase Target)
        {
            MainDungeonManager MainDungeonManager = BattleSpace.MainDungeonManager;
            
            int Damage = Attacker.Attack.GetDamage();
            Target.Hp.Amount -= Damage;

            MainDungeonManager.BattleLogAdd(Attacker.Name + " hits " + Target.Name + " for " + Damage + " damage");
        }

    }
}

using Assets.Scripts.Models.Entity.BaseStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Entity.Enemy
{
    public class Enemy : EntityBase
    {
        public Loot Loot;
        public int Exp;

        public Enemy(string name, int level, int hp, Attack attack, int loot, int exp)
        {
            Name = name;
            Level = new Level(level);
            Hp = new Hp(hp);
            Attack = attack;
            Loot = new Loot(loot, 0);
            Exp = exp;

            if (name == "Goblen")
                Sprite = Resources.Load<Sprite>("Sprites/DungeonSprites/Goblen");
            else
                Sprite = Resources.Load<Sprite>("Sprites/DungeonSprites/HobGoblen");
        }
    }
}

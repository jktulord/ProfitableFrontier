using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Entity.BaseStats;
using Assets.Scripts.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Entity
{
    public class EntityBase
    {
        public string Name;

        public Level Level;

        public Hp Hp;

        public Attack Attack;

        public Sprite Sprite;
   
    }
}

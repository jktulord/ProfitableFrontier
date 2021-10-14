using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Entity.BaseStats
{
    public class Attack
    {
        public int BaseValue;
        public int AddValue;

        public Attack(int baseValue, int addValue)
        {
            BaseValue = baseValue;
            AddValue = addValue;
        }

        public int GetDamage()
        {
            return UnityEngine.Random.Range(BaseValue, BaseValue + AddValue + 1);
        }
        
    }
}

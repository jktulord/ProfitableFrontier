using Assets.Scripts.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Entity.BaseStats
{
    public class Loot : RandomValue 
    {
        public Loot(int baseValue, int addValue)
        {
            BaseValue = baseValue;
            AddValue = addValue;
        }
    }
}

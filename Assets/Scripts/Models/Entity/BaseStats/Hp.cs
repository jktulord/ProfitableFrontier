using Assets.Scripts.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Entity.BaseStats
{
    public class Hp : LimitedValue
    {
        public bool IfDead
        {
            get { return (Amount <= 0); }
        }

        public Hp(int max)
        {
            Max = max;
            Amount = max;  

        }
        
        public void FullHeal()
        {
            Amount = Max;
        }
    
    }
}

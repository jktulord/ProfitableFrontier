using Assets.Scripts.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Entity.Heroes.Needs
{
    public class NeedsSystem
    {
        public Hero Hero;
        public Dictionary<NeedKind, Need> Base;

        public int Average
        {
            get {
                int sum = 0;
                foreach (Need need in Base.Values)
                {
                    sum += need.Amount;
                }
                return sum / Base.Count; 
            }
        }

        public NeedsSystem(Hero hero)
        {
            Hero = hero;

            Base = new Dictionary<NeedKind, Need>();
            Base.Add(NeedKind.Housing, new Need(NeedKind.Food, 40));
            Base.Add(NeedKind.Food, new Need(NeedKind.Housing, 75));
            
        
        }

        public void Calculation(Hero hero)
        {
            
        }
    }
}

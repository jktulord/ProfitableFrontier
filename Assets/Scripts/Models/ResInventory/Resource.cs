using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResInventory
{
    public enum ResKind
    {
        Null, Wood, Fish, Hides
    }

    public class Resource
    {
        public ResKind Name;

        private int amount;
        public int Amount { 
            get { return amount; } 
            set {
                if ((value > Limit))
                {
                    amount = Limit;
                }
                else
                {
                    amount = value;
                } 
            }
        }
        public int Limit = 100000;

        public Resource(ResKind name, int amount = 0, int limit = 100000)
        {
            Name = name;
            Limit = limit;
            Amount = amount;
            
        }

    }
}

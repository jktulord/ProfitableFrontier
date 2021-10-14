using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Entity.Heroes.Needs
{
    public enum NeedKind
    {
        Food, Housing
    }

    public class Need
    {
        public NeedKind Kind;

        public int Amount;

        public Need(NeedKind kind, int amount)
        {
            Kind = kind;
            Amount = amount;
        }
    }
}

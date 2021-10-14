using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Basic
{

    public class LimitedValue
    {
        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                if (value > Max)
                {
                    value = Max;
                }
                amount = value;
            }
        }

        public int Max;
    }

}

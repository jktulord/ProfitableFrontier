using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.PlayerModel.Stats
{
    public class BuildLimit
    {
        public int Value;
        public int Max;

        public bool Spend(int value)
        {
            if (Value + value >= Max)
            {
                Value += value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public BuildLimit(int max)
        {
            Max = max;
            Value = 0;
        }
    }
}

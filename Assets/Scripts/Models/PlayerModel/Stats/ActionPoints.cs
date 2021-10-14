using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.PlayerModel.Stats
{
    public class ActionPoints
    {
        public int Value;
        public int CurrentMax;
        public int Max;

        public bool Spend(int value)
        {
            if (Value - value >= 0)
            {
                Value -= value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionPoints(int max)
        {
            Max = max;
            CurrentMax = Max;
            Value = Max;
        }
    }
}

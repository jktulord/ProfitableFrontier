using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Basic
{
    public class RandomValue
    {
        public int BaseValue;
        public int AddValue;


        public int Get()
        {
            return UnityEngine.Random.Range(BaseValue, BaseValue + AddValue + 1);
        }
    }
}

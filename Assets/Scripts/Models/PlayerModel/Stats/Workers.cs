using Assets.Scripts.Models.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.PlayerModel.Stats
{
    public enum WorkType
    {
        Collect, Order, Stock
    }

    public class Workers
    {
        public int Value;
        public int Max;

        public Dictionary<WorkType, int> Distribution;
        public Dictionary<WorkType, int> MaxDistribution;

        public int CollectInt;

        public Workers(int max)
        {
            Max = max;
            Value = Max;
            CollectInt = 0;
            Distribution = new Dictionary<WorkType, int>();
            MaxDistribution = new Dictionary<WorkType, int>();
            Distribution.Add(WorkType.Collect, 0);
            MaxDistribution.Add(WorkType.Collect, 10);
            Distribution.Add(WorkType.Order, 0);
            MaxDistribution.Add(WorkType.Order, 2);
            Distribution.Add(WorkType.Stock, 0);
            MaxDistribution.Add(WorkType.Stock, 2);
        }

        public bool Add(int value)
        {
            if ((Value + value >= 0) && (Value + value <= Max))
            {
                Value += value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DistributionSum()
        {
            return Distribution[WorkType.Collect] + Distribution[WorkType.Order] + Distribution[WorkType.Stock];
        }

        public bool Collect(BaseBuilding building, Player player)
        {
            if (building.Kind != BuildingKind.TownHouse)
            {
                player.Inventory += building.Inventory;
                building.Inventory.Clear();

                player.Workers.CollectInt++;
                return true;
            }
            else
            {
                player.Workers.CollectInt++;
                return false;
            }
        }
    }
}

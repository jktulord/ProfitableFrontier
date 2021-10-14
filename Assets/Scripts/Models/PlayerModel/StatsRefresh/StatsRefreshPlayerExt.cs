using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.PlayerModel.Stats;
using Assets.Scripts.ResInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.PlayerModel.StatsRefresh
{
    public static class StatsRefreshPlayerExt
    { 
        public static void StatsRefresh(this Player player, List<BaseBuilding> buildings)
        {
            BaseBuilding TownHouse = buildings.FindTownHouse();
            List<BaseBuilding> StorageBuildings = buildings.FindAllByKind(BuildingKind.Storage);
            List<BaseBuilding> WorkerHouses = buildings.FindAllByKind(BuildingKind.WorkerHouse);


            TownHouseTierBonusesCalculation(player, TownHouse);
            LimitCalculation(player, StorageBuildings);
            WorkerHouseCalculation(player, WorkerHouses);

        }

        public static void TownHouseTierBonusesCalculation(Player player, BaseBuilding TownHouse)
        {
            if (TownHouse != null)
            {
                //BuildLimit.Max = 3 + TownHouse.Tier * 5;
                player.Workers.Max = TownHouse.Tier * 2;
                player.AP.Max = 3 + 1 * TownHouse.Tier;
            }
            if (TownHouse.Tier >= 1)
            {
                player.CanHireWorkers = true;
            }
        }

        public static void LimitCalculation(Player player, List<BaseBuilding> StorageBuildings)
        {
            player.Workers.MaxDistribution[WorkType.Stock] = StorageBuildings.Count;

            player.Inventory.Res[ResKind.Wood].Limit = 50;
            player.Inventory.Res[ResKind.Fish].Limit = 50;
            player.Inventory.Res[ResKind.Hides].Limit = 50;
            if (StorageBuildings.Count > 0)
            {
                Inventory StorageLimit = new Inventory(IfHasLimit: true);
                foreach (StorageBuilding building in StorageBuildings)
                {
                    StorageLimit.Res[building.StorageAdditon.Name].Limit += building.StorageAdditon.Amount;
                }

                foreach (Resource resource in player.Inventory.Res.Values)
                {
                    resource.Limit += (int)(StorageLimit.Res[resource.Name].Limit * (0.5 + 0.5 * player.Workers.Distribution[WorkType.Stock] / player.Workers.MaxDistribution[WorkType.Stock]));
                }
            }
        }

        public static void WorkerHouseCalculation(Player player, List<BaseBuilding> WorkerHouses)
        {
            foreach (WorkerHouse workerHouse in WorkerHouses)
            {
                player.Workers.Max += workerHouse.WorkerLimit;
            }
        }
    }
}

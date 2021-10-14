using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.PlayerModel;
using Assets.Scripts.ResInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Models.Buildings
{
    public static class GetPresetBuilding
    {
        public static BaseBuilding Dungeon(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Ground/GroundPalete_15");
            Resource cost0 = new Resource(ResKind.Wood, 0);

            return (new BaseBuilding(player, "Dungeon", "Where all of the loot is going from", pos,
                tile0, cost0
                ));
        }
        public static BaseBuilding TownHouse(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_7");
            Tile tile1 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_7");
            Tile tile2 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_7");
            Resource cost0 = new Resource(ResKind.Wood, 0);
            Resource cost1 = new Resource(ResKind.Wood, 5);
            Resource cost2 = new Resource(ResKind.Wood, 25);

            return (new TownHouseBuilding(player, "TownHouse", "Place where you live and rule your town. Upgrade to hire workers.", pos,
                tile0, cost0,
                upgradeTiles: new Tile[2] { tile1, tile2 },
                upgradeBuildCost: new Resource[2] { cost1, cost2 }      
                ));
        }

        public static BaseBuilding WorkerHouse(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_20");
            Resource cost0 = new Resource(ResKind.Wood, 20);
            Resource cost1 = new Resource(ResKind.Wood, 20);
            Resource cost2 = new Resource(ResKind.Wood, 40);

            return (new WorkerHouse(player, "WorkerHouse", "Place to place your workers. +2 WorkerLimit", pos,
                tile0, cost0,
                upgradeDescriptions: new string[2] { "Place to place your workers. +3 WorkerLimit", "Place to place your workers. +5 WorkerLimit" },
                upgradeTiles: new Tile[2] { tile0, tile0 },
                upgradeBuildCost: new Resource[2] { cost1, cost2 },
                workerLimit: 2, upgradeWorkerLimit: new int[2] { 3, 5 }
                )) ;
        }

        public static BaseBuilding Tent(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_0");
            Tile tile1 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_1");
            Tile tile2 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_2");
            Resource cost0 = new Resource(ResKind.Wood, 10);
            Resource cost1 = new Resource(ResKind.Wood, 15);
            Resource cost2 = new Resource(ResKind.Wood, 20);

            return (new House(player, "Tent",  "Basic shelter for one person. Quality 20", pos,
                tile0, cost0,
                upgradeDescriptions: new string[2] {
                    "Basic shelter for 2 persons. Quality 15",
                    "Basic shelter for 3 persons. Quality 15"
                },
                upgradeTiles: new Tile[2] { tile1, tile2 },
                upgradeBuildCost: new Resource[2] { cost1, cost2 },
                maxOccupants: 1, upgradeMaxOccupants: new int[2] { 2, 3 },
                houseQuality: 20, upgradeHouseQuality: new int[2] { 15, 15 }));
        }

        public static BaseBuilding House(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_12");
            Tile tile1 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_13");
            Tile tile2 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_14");
            Resource cost0 = new Resource(ResKind.Wood, 30);
            Resource cost1 = new Resource(ResKind.Wood, 50);
            Resource cost2 = new Resource(ResKind.Wood, 100);

            return (new House(player, "House", "A nice house. Quality 50", pos,
                tile0, cost0,
                new string[2] {
                    "A nice house for two. Quality 45",
                    "A nice house for three. Quality 45"
                },
                upgradeTiles: new Tile[2] { tile1, tile2 },
                upgradeBuildCost: new Resource[2] { cost1, cost2 },
                maxOccupants: 1, upgradeMaxOccupants: new int[2] { 2, 3 },
                houseQuality: 50, upgradeHouseQuality: new int[2] { 45, 45 }));
                
        }

        public static BaseBuilding FishingHut(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_11");
            Resource cost0 = new Resource(ResKind.Wood, 20);
            Resource cost1 = new Resource(ResKind.Wood, 30);
            Resource cost2 = new Resource(ResKind.Wood, 40);
            Resource income0 = new Resource(ResKind.Fish, 3);
            Resource income1 = new Resource(ResKind.Fish, 5);
            Resource income2 = new Resource(ResKind.Fish, 7);
            return (new ResourceBuilding(player, "Fishing Hut",  "Hand made pound with hand made fishes. Generates 3 fish.", pos,
                tile, cost0,
                upgradeTiles: new Tile[2] { tile, tile },
                upgradeBuildCost: new Resource[2] { cost1, cost2 },
                daylyEarning: income0,
                upgradeDaylyEarnings: new Resource[2] { income1, income2 }));
        }

        public static BaseBuilding ChoppingHut(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_10");
            Resource cost0 = new Resource(ResKind.Wood, 20);
            Resource cost1 = new Resource(ResKind.Wood, 30);
            Resource cost2 = new Resource(ResKind.Wood, 40);
            Resource income0 = new Resource(ResKind.Wood, 3);
            Resource income1 = new Resource(ResKind.Wood, 5);
            Resource income2 = new Resource(ResKind.Wood, 7);
            return (new ResourceBuilding(player, "Chopping Hut",  "Hand made hut with hand made woods. Generates 3 wood.", pos,
                tile, cost0,
                upgradeTiles: new Tile[2] { tile, tile },
                upgradeBuildCost: new Resource[2] { cost1, cost2 },
                daylyEarning: income0,
                upgradeDaylyEarnings: new Resource[2] { income1, income2 }));
        }

        public static BaseBuilding WoodStorage(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_16");
            Tile tile1 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_17");
            Resource cost0 = new Resource(ResKind.Wood, 20);
            Resource cost1 = new Resource(ResKind.Wood, 50);
            Resource storage0 = new Resource(ResKind.Wood, 200);
            Resource storage1 = new Resource(ResKind.Wood, 400);

            return (new StorageBuilding(player, "Wood Storage",  "Place where your wood is contained.", pos,
                tile0, cost0,
                upgradeTiles: new Tile[1] { tile1 },
                upgradeBuildCost: new Resource[1] { cost1 },
                storageAdditon: storage0,
                upgradeStorageAdditon: new Resource[] { storage1 }
                ));
        }

        public static BaseBuilding FishStorage(Vector3Int pos, Player player)
        {
            Tile tile0 = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_18");
            Resource cost0 = new Resource(ResKind.Wood, 20);
            Resource storage0 = new Resource(ResKind.Fish, 200);

            return (new StorageBuilding(player, "Fish Storage",  "Place where your wood is contained.", pos,
                tile0, cost0,
                storageAdditon: storage0
                ));
        }

        public static BaseBuilding Hospital(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_15");
            Resource cost0 = new Resource(ResKind.Wood, 30);
            return (new MedicalBuilding(player, "Hospital",  "Place for heroes to be healed", pos,
                tile, cost0,
                recoveryPower: 15));
        }

        public static BaseBuilding TradePost(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_19");
            Resource cost0 = new Resource(ResKind.Wood, 30);
            return (new TradePostBuilding(player, "Trade Post",  "Place for heroes to sell loot", pos,
                tile, cost0,
                tradePower: 30));
        }

        public static BaseBuilding FoodBuilding(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_25");
            Resource cost0 = new Resource(ResKind.Wood, 30);
            return (new FoodStalls(player, "Food Stalls",  "Place for heroes to eat", pos,
                tile, cost0,
                sellCost: 1, foodTier: 1, usingResource: new Resource(ResKind.Fish, 1), servicePower: 5
                ));
        }
        public static BaseBuilding Tavern(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_9");
            Resource cost0 = new Resource(ResKind.Wood, 30);
            return (new Tavern(player, "Tavern", "Heroes spend their free time here. There is no beer in this town, so they mostly drink fish.", pos,
                tile, cost0,
                sellCost: 1, foodTier: 1, usingResource: new Resource(ResKind.Fish, 1), servicePower: 5
                ));
        }

        public static BaseBuilding TrainingGround(Vector3Int pos, Player player)
        {
            Tile tile = Resources.Load<Tile>("Tiles/Buildings/BuildingTileSet_22");
            Resource cost0 = new Resource(ResKind.Wood, 10);
            return (new TrainingGround(player, "Training Ground", "Heroes train here to gain exp.", pos,
                tile, cost0,
                sellCost: 1, foodTier: 1, usingResource: new Resource(ResKind.Fish, 1), servicePower: 5
                ));
        }
    }
}

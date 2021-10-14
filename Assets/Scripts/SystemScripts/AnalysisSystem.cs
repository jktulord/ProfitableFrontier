using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.ResInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnalysisSystem : MonoBehaviour
{
    private PlayerSystem PlayerSystem;
    private PopUpSystem PopUpSystem;
    private TileSystem TileSystem;
    private HeroSystem HeroSystem;

    [Inject]
    private void Construct(PopUpSystem popUpSystem, TileSystem tileSystem, HeroSystem heroSystem, PlayerSystem playerSystem)
    {
        PopUpSystem = popUpSystem;
        TileSystem = tileSystem;
        HeroSystem = heroSystem;
        PlayerSystem = playerSystem;
    }

    public Inventory CalculateUncollected()
    {
        Inventory Uncollected = new Inventory();
        foreach (BaseBuilding building in PlayerSystem.Player.Buildings)
        {
            Uncollected += building.Inventory;
        }

        return Uncollected;
    }

    public Inventory CalculateIncome()
    {
        Inventory Income = new Inventory();
        foreach (BaseBuilding building in PlayerSystem.Player.Buildings)
        {
            if (building.Kind == BuildingKind.Resource)
            {
                ResourceBuilding resourceBuilding = (ResourceBuilding)building;
                if (resourceBuilding.DaylyEarning != null)
                {
                    Income += resourceBuilding.DaylyEarning;
                }
            }
        }
        return Income;
    }

    public Inventory CalculateExpenses()
    {
        Inventory Expenses = new Inventory();
        /*
        foreach (Building building in PlayerSystem.Player.Buildings)
        {
            Uncollected += building.;
        }
        */
        Expenses.Silver += PlayerSystem.Player.Workers.Value * 10;
        return Expenses;     
    }

    
}

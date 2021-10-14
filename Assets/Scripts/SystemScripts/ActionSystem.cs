using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.PlayerModel;
using Assets.Scripts.SystemScripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ActionSystem : MonoBehaviour
{
    private PopUpSystem PopUpSystem;
    private TileSystem TileSystem;
    private HeroSystem HeroSystem;
    private PlayerSystem PlayerSystem;

    [Inject]
    private void Construct(PopUpSystem popUpSystem, TileSystem tileSystem, HeroSystem heroSystem, PlayerSystem playerSystem)
    {
        PopUpSystem = popUpSystem;
        TileSystem = tileSystem;
        HeroSystem = heroSystem;
        PlayerSystem = playerSystem;
    }

    public void Fishing()
    {
        ActActions.Fishing(PopUpSystem, PlayerSystem);
    }

    public void Chopping()
    {
        ActActions.Chopping(PopUpSystem, PlayerSystem);
    }

    public void AutoTurnUpdate(bool value)
    {
        PlayerSystem.Player.IsAutoTurn = value;
    }

    public void BuildTent()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.Tent(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildHouse()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.House(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildChoppingHut()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.ChoppingHut(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildFishingHut()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.FishingHut(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildHospital()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.Hospital(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildTradePost()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.TradePost(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildWoodStorage()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.WoodStorage(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }
    
    public void BuildFishStorage()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.FishStorage(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildFoodBuilding()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos, 
            GetPresetBuilding.FoodBuilding(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildWorkerHouse()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.WorkerHouse(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildTavern()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.Tavern(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void BuildTrainingGround()
    {
        BuildActions.Build(TileSystem, PopUpSystem, PlayerSystem, PlayerSystem.OutlineTilePos,
            GetPresetBuilding.TrainingGround(PlayerSystem.OutlineTilePos, PlayerSystem.Player));
    }

    public void Help()
    {
        MiscActions.Help(PopUpSystem);
    }
}

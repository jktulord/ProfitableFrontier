using Assets.Scripts.Dungeon;
using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Heroes;
using Assets.Scripts.Models.PlayerModel;
using Assets.Scripts.Models.PlayerModel.Stats;
using Assets.Scripts.Models.PlayerModel.StatsRefresh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using Zenject;

public class PlayerSystem : MonoBehaviour
{

    public Player Player;
    public ResourceView resourceView;
    public PlayerStatsView playerPanelView;
    public PlayerAnalysisPanel PlayerAnalysisPanel;
    public MainDescriptionView TileDescriptionScrollView;
    //public MainDungeonManager MainDungeonManager;

    public PanelMover MainDungeonPanel;
    
    private PopUpSystem PopUpSystem;
    private TileSystem TileSystem;
    private HeroSystem HeroSystem;
    private AnalysisSystem AnalysisSystem;

    public Vector3Int OutlineTilePos;

    public int Turn;

    [Inject]
    private void Construct(PopUpSystem popUpSystem, TileSystem tileSystem, HeroSystem heroSystem, AnalysisSystem analysisSystem)
    {
        PopUpSystem = popUpSystem;
        TileSystem = tileSystem;
        HeroSystem = heroSystem;
        AnalysisSystem = analysisSystem;
        
    } 

    // Start is called before the first frame update
    void Start()
    {
        Player = new Player(this);
        TileDescriptionScrollView.Load();
        playerPanelView.Refresh(Player);
        Refresh();
        Turn = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            OutlineTilePos = TileSystem.GetTileByCurMousePos();
            Refresh();
        }
        else if (Input.GetKeyDown(KeyCode.Space) /*|| Input.GetKeyDown(KeyCode.KeypadEnter)*/)
        {
            NextTurn();
        }
    }

    public void NextTurn()
    {
        Turn++;
        bool marketDay = false;
        if (Turn % 7 == 0)
        {
            marketDay = true;
            PopUpSystem.ShowAknowledgeMessage("Today is a market day. Loot in markets has been sold. ");
        }
        Player.NextTurn();
        foreach (IBuilding building in Player.Buildings)
        {
            building.NextTurn(marketDay);
        }
        HeroSystem.NextTurn();
        WorkerTurn(marketDay);
        MigrationAction();

        Refresh();
    }

    public void MigrationAction()
    {
        List<Hero> heroes = HeroSystem.Migration(1);
        string line = " arrived";
        foreach (Hero hero in heroes)
        {
            line = hero.Name + " " + line;
        }
        if (heroes.Count > 0)
            PopUpSystem.ShowAknowledgeMessage(line);
    }

    public void WorkerTurn(bool marketDay)
    {
        WorkerCollect();
        if (marketDay)
            Player.Inventory.Silver -= Player.Workers.Value * 10;
    }

    public void WorkerCollect()
    {
        List<BaseBuilding> buildings = Player.Buildings;
        Workers workers = Player.Workers;
        if (buildings.Count > 1)
        {
            int i = 0;
            while (i < workers.Distribution[WorkType.Collect])
            {
                if (workers.CollectInt < buildings.Count)
                    if (workers.Collect(buildings[workers.CollectInt], Player))
                    {
                        i++;
                    }
                    else { }
                else
                {
                    Player.Workers.CollectInt = 0;
                }
            }
        }
    }

    public void Win()
    {
        if (Player.Inventory.Silver >= 1000)
        {
            PopUpSystem.ShowAknowledgeMessage("You won. ");
            Player.Inventory.Silver -= 1000;
            Refresh();
        }
        else
        {
            PopUpSystem.ShowAknowledgeMessage("You know you don't have enough.");
        }
    }


    public void Refresh()
    {
        Player.StatsRefresh(Player.Buildings);

        IBuilding OutlinedBuilding = Player.Buildings.FindBuildingByPos(OutlineTilePos);
        
        TileDescriptionScrollView.Refresh(OutlinedBuilding);

        if (OutlinedBuilding != null)
            if (OutlinedBuilding.Kind == BuildingKind.Dungeon)
                MainDungeonPanel.Change();

        playerPanelView.Refresh(Player);
        
        PlayerAnalysisPanel.Refresh(
            AnalysisSystem.CalculateUncollected(), 
            AnalysisSystem.CalculateIncome(),
            AnalysisSystem.CalculateExpenses());
        PopUpSystem.RefreshStatusPops(Player);
        TileSystem.Refresh();
    }
}

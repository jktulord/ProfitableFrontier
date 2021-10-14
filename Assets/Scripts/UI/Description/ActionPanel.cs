using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Heroes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ActionPanel : MonoBehaviour
{
    
    private CollectAndUpgradePanel CollectAndUpgradePanel;
    private TownHallShow TownHallShow;
    private HeroShow HeroShow;

    private PlayerSystem PlayerSystem;
    

    [Inject]
    private void Construct(PlayerSystem playerSystem)
    {
        PlayerSystem = playerSystem;
    }

    public void Load()
    {
        
        CollectAndUpgradePanel = transform.Find("CollectAndUpgradePanel").GetComponent<CollectAndUpgradePanel>();
        TownHallShow = transform.Find("TownHallShow").GetComponent<TownHallShow>();
        HeroShow = transform.Find("HeroShow").GetComponent<HeroShow>();
    }

    

    public void Refresh(IBuilding building)
    {
        Load();
        if (building.Kind == BuildingKind.House)
        {
            HeroShow.gameObject.SetActive(true);
            HeroShow.Refresh((House)building);
            TownHallShow.gameObject.SetActive(false);
        }
        else if (building.Kind == BuildingKind.TownHouse)
        {
            HeroShow.gameObject.SetActive(false);
            if (PlayerSystem.Player.CanHireWorkers)
            {
                TownHallShow.gameObject.SetActive(true);
                TownHallShow.Refresh(building.Player);
            }
            else
            {
                TownHallShow.gameObject.SetActive(false);
            }
        }
        else
        {
            TownHallShow.gameObject.SetActive(false);
            HeroShow.gameObject.SetActive(false);      
        }
        CollectAndUpgradePanel.Refresh(building);
    }

    
}

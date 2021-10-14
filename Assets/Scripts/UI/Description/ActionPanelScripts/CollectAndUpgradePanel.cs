using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Kinds;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectAndUpgradePanel: MonoBehaviour
{
    public TMP_Text PropertyLine;
    
    public TMP_Text RequirementLine; 
    public TMP_Text AccumulatedLine;

    public Button UpgradeButton;
    public Button CollectButton;


    // Start is called before the first frame update
    public void Load()
    {
        PropertyLine = transform.Find("PropertyLine").GetComponent<TMP_Text>();
        RequirementLine = transform.Find("Requirement").GetComponent<TMP_Text>();
        AccumulatedLine = transform.Find("Accumulated").GetComponent<TMP_Text>();
        UpgradeButton = transform.Find("Upgrade").GetComponent<Button>();
        CollectButton = transform.Find("Collect").GetComponent<Button>();
    }

    public void Refresh(IBuilding building)
    {
        Load();
   
        PropertyLine.gameObject.SetActive(true);
        AccumulatedLine.gameObject.SetActive(true);
        UpgradeButton.gameObject.SetActive(true);
        CollectButton.gameObject.SetActive(true);

        UpgradeButton.onClick.RemoveAllListeners();
        CollectButton.onClick.RemoveAllListeners();

        if (building.Kind == BuildingKind.TownHouse)
        {
            TownHouseBuilding tradePostBuilding = (TownHouseBuilding)building;
            building = (TownHouseBuilding)building;
            AccumulatedLine.gameObject.SetActive(false);
            CollectButton.gameObject.SetActive(false);
        }
        else if (building.Kind == BuildingKind.House)
        {
            House house = (House)building;
            building = (House)building;
        }
        else if (building.Kind == BuildingKind.Resource)
        {
            ResourceBuilding resourceBuilding = (ResourceBuilding)building;
            building = (ResourceBuilding)building;
            PropertyLine.gameObject.SetActive(false);
        }
        else if (building.Kind == BuildingKind.Medical)
        {
            MedicalBuilding medicalBuilding = (MedicalBuilding)building;
            building = (MedicalBuilding)building;
        }
        else if (building.Kind == BuildingKind.TradePost)
        {
            TradePostBuilding tradePostBuilding = (TradePostBuilding)building;
            building = (TradePostBuilding)building;
        }
        else if (building.Kind == BuildingKind.Storage)
        {
            StorageBuilding tradePostBuilding = (StorageBuilding)building;
            building = (StorageBuilding)building;
            AccumulatedLine.gameObject.SetActive(false);
            CollectButton.gameObject.SetActive(false);
        }
        else if (building.Kind == BuildingKind.Food)
        {
            FoodStalls foodBuilding = (FoodStalls)building;
            building = (FoodStalls)building;
        }
        else if (building.Kind == BuildingKind.WorkerHouse)
        {
            WorkerHouse foodBuilding = (WorkerHouse)building;
            building = (WorkerHouse)building;
        }

        PropertyLine.text = building.PropertyDescriptionLine;
        AccumulatedLine.text = building.AccumulatedDescriptionLine;

        if ((building.UpgradeTiles != null) && (building.UpgradeTiles.Length > building.Tier))
        {
            RequirementLine.text = building.UpgradeBuildCost[building.Tier].Name + ":" + building.UpgradeBuildCost[building.Tier].Amount;
            UpgradeButton.onClick.AddListener(() => building.Upgrade());
        }
        else
        {
            RequirementLine.text = "N/A";
        }

        
        
        CollectButton.onClick.AddListener(() => building.Collect());


    }
}

using Assets.Scripts.Models.Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDescriptionView : MonoBehaviour
{
    private GameObject ActionPanel;
    private GameObject BuildingDescriptionLine;
    private GameObject GroundDescriptionLine;

    public void Start()
    {
        Load();
        //Refresh();
    }

    public void Load()
    {
        ActionPanel = transform.Find("Viewport").Find("Content").Find("ActionPanel").gameObject;
        BuildingDescriptionLine = transform.Find("Viewport").Find("Content").Find("BuildingDescriptionLine").gameObject;
        GroundDescriptionLine = transform.Find("Viewport").Find("Content").Find("GroundDescriptionLine").gameObject;
        
    }

    public void Refresh(IBuilding building)
    {
        GroundDescriptionLine.SetActive(true);
        GroundDescriptionLine.GetComponent<GroundDescriptionLine>().Refresh("Ground", "Nice place to build");

        if (building != null)
        {
            BuildingDescriptionLine.SetActive(true);
            BuildingDescriptionLine.GetComponent<BuildingDescriptionLine>().Refresh(building);
            ActionPanel.SetActive(true);
            ActionPanel.GetComponent<ActionPanel>().Refresh(building);

            //if (building.Occupants.Count > 0)
            //{
            //   HeroesDescriptionLine.SetActive(true);
            //   HeroesDescriptionLine.GetComponent<ActionDescriptionLine>().Refresh(building);
            //}
            //else
            //{
            //  HeroesDescriptionLine.SetActive(false);
            //}
        }
        else
        {
            ActionPanel.SetActive(false);
            BuildingDescriptionLine.SetActive(false);
        }
        
        
        
    }
}

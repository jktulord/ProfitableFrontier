using Assets.Scripts.Models.Buildings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDescriptionLine : MonoBehaviour
{
    private TMP_Text Name;
    private TMP_Text Description;
    //private TMP_Text Occupants;
   // private Button Upgrade;

    public void Load()
    {
        Name = transform.Find("Name").GetComponent<TMP_Text>();
        Description = transform.Find("Description").GetComponent<TMP_Text>();
        //Occupants = transform.Find("Occupants").GetComponent<TMP_Text>();
        //Upgrade = transform.Find("Upgrade").GetComponent<Button>();
    }

    public void Refresh(IBuilding building)
    {
        if (Name != null)
        {
            Name.text = building.Name;
            Description.text = building.Description;
            //Occupants.text = occupants;
            //Upgrade.onClick.RemoveAllListeners();
            //Upgrade.onClick.AddListener(() => building.Upgrade());   
        }
        else
        {
            Load();
        }
    }
}

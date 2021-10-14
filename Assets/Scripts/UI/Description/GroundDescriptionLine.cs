using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundDescriptionLine : MonoBehaviour
{
    private TMP_Text Name;
    private TMP_Text Description;
    

    public void Load()
    {
        Name = transform.Find("Name").GetComponent<TMP_Text>();
        Description = transform.Find("Description").GetComponent<TMP_Text>();
    }

    public void Refresh(string name, string description)
    {
        if (Description != null)
        {
            Name.text = name;
            Description.text = description;
        }
        else
        {
            Load();
        }

    }
}

using Assets.Scripts.ResInventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceLimitView : MonoBehaviour
{
    private GameObject Prefab;
    public List<TMP_Text> Lines;

    private Inventory inventory;
    public Inventory Inventory { 
        get { return inventory; } 
        set { 
            inventory = value;
            Load();
            Clear();
            Refresh(); 
        } 
    }

    private void Load()
    {
        if (Prefab == null)
        {
            Prefab = Resources.Load<GameObject>("Prefabs/UIPrefabs/TextLinePrefab");
        }
        
    }

    private void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Refresh()
    {
        Lines = new List<TMP_Text>();
        foreach (Resource resource in Inventory.Res.Values)
        {
            var ResLine = Instantiate(Prefab, transform);
            Lines.Add(ResLine.GetComponent<TMP_Text>());
            Lines[Lines.Count - 1].text = "/" + resource.Limit;
        }
    }

    

    
}

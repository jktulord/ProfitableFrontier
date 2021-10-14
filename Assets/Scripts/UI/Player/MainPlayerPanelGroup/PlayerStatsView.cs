
using Assets.Scripts.Models.PlayerModel;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerStatsView : MonoBehaviour
{
    private ResourceView ResourceViewVertical;
    private ResourceLimitView LimitViewVertical;
    private TMP_Text SilverLine;
    private TMP_Text APLine;
    //private TMP_Text BuildLimit;
    
    private void Load()
    {
        ResourceViewVertical = transform.Find("ResourceViewVertical").GetComponent<ResourceView>();
        LimitViewVertical = transform.Find("LimitViewVertical").GetComponent<ResourceLimitView>();
        SilverLine = transform.Find("StatsView").Find("SilverLine").GetComponent<TMP_Text>();
        APLine = transform.Find("StatsView").Find("APLine").GetComponent<TMP_Text>();
        //BuildLimit = transform.Find("StatsView").Find("BuildLimit").GetComponent<TMP_Text>();
    }

    public void Refresh(Player player)
    {
        Load();
        ResourceViewVertical.Inventory = player.Inventory;
        LimitViewVertical.Inventory = player.Inventory;
        SilverLine.text = "Silver:"+player.Inventory.Silver;
        APLine.text = "AP:" + player.AP.Value;
        //BuildLimit.text = "Build Limit:" + player.BuildLimit.Value + "/" + player.BuildLimit.Max;
    }  
}

using Assets.Scripts.Models.PlayerModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceForStatusPops : MonoBehaviour
{
    private GameObject StatusPopPrefab;

    public void Load()
    {
        if (StatusPopPrefab == null)
            StatusPopPrefab = Resources.Load<GameObject>("Prefabs/PopUp/StatusPop");
    }

    private void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Refresh(Player player)
    {
        Clear();
        Load();
        if (player.Hungry)
            Instantiate(StatusPopPrefab, transform);
    }

}

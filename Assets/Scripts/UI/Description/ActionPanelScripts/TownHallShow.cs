using Assets.Scripts.Models.PlayerModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallShow : MonoBehaviour
{
    private Distribution Distribution;
    private Hirement Hirement;

    void Load()
    {
        Distribution = transform.Find("Distribution").GetComponent<Distribution>();
        Hirement = transform.Find("Hirement").GetComponent<Hirement>();
    }

    public void Refresh(Player player)
    {
        if (Distribution == null)
            Load();

        Distribution.Refresh(player);
        Hirement.Refresh(player);
    }
}

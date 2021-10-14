using Assets.Scripts.Models.PlayerModel;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Hirement : MonoBehaviour
{

    private TMP_Text Workers;
    private TMP_Text WorkerCost;
    private TMP_Text WorkerWages;

    private PlayerSystem PlayerSystem;

    [Inject] 
    private void Construct(PlayerSystem playerSystem)
    {
        PlayerSystem = playerSystem;
    }

    void Load()
    {
        Workers = transform.Find("Workers").GetComponent<TMP_Text>();
        WorkerCost = transform.Find("WorkerCost").GetComponent<TMP_Text>();
        WorkerWages = transform.Find("WorkerWages").GetComponent<TMP_Text>();
    }
    

    public void Refresh(Player player)
    {
        Load();
        Workers.text = "Workers " + player.Workers.Value + "/" + player.Workers.Max;
        WorkerWages.text = "Weekly Wages: " + player.Workers.Value * 10 + " Silver";
        WorkerCost.text = "Hire Cost: " + 20 + " Silver";
    }

    public void MinusThree()
    {
        PlayerSystem.Player.Workers.Add(-3);
        PlayerSystem.Refresh();
    }

    public void MinusOne()
    {
        PlayerSystem.Player.Workers.Add(-1);
        PlayerSystem.Refresh();
    }

    public void PlusOne()
    {

        Player player = PlayerSystem.Player;
        if (player.Inventory.Silver >= 20)
        {
            player.Inventory.Silver -= 20;
            player.Workers.Add(1);
        }
        PlayerSystem.Refresh();
    }

    public void PlusThree()
    {
        Player player = PlayerSystem.Player;
        if (player.Inventory.Silver >= 20 * 3)
        {
            player.Inventory.Silver -= 20 * 3;
            player.Workers.Add(3);
        }
        PlayerSystem.Refresh();
    }
}

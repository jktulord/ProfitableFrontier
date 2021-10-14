using Assets.Scripts.ResInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AutoSpendViewScript : MonoBehaviour
{
    public Toggle FishingToggle;
    public Toggle ChoppingToggle;

    private PlayerSystem PlayerSystem;

    [Inject]
    private void Construct(PlayerSystem playerSystem)
    {
        PlayerSystem = playerSystem;
    }

    public void AutoSpendFishingUpdate(bool value)
    {
        if (value == true)
        {
            ChoppingToggle.isOn = false;
            PlayerSystem.Player.AutoSpendRes = ResKind.Fish;
        }
        else
        {
            PlayerSystem.Player.AutoSpendRes = ResKind.Null;
        }
    }

    public void AutoSpendChoppingUpdate(bool value)
    {
        if (value == true)
        {
            FishingToggle.isOn = false;
            PlayerSystem.Player.AutoSpendRes = ResKind.Wood;
        }
        else
        {
            PlayerSystem.Player.AutoSpendRes = ResKind.Null;
        }
    }
}

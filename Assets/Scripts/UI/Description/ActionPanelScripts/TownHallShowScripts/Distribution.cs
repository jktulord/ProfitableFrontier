using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.PlayerModel;
using Assets.Scripts.Models.PlayerModel.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Distribution : MonoBehaviour
{
    private PlayerSystem PlayerSystem;

    private ProSlider CollectSlider;
    private ProSlider OrderSlider;
    private ProSlider StockSlider;

    [Inject]
    public void Construct(PlayerSystem playerSystem)
    {
        PlayerSystem = playerSystem;
    } 


    void Load()
    {
        CollectSlider = transform.Find("SliderGroup").Find("CollectSlider").GetComponent<ProSlider>();
        CollectSlider.Load();
        //OrderSlider = transform.Find("SliderGroup").Find("OrderSlider").GetComponent<ProSlider>();
        //OrderSlider.Load();
        StockSlider = transform.Find("SliderGroup").Find("StockSlider").GetComponent<ProSlider>();
        StockSlider.Load();
    }

    // Start is called before the first frame update
    public void Refresh(Player player)
    {
        if (CollectSlider == null)
            Load();

        CollectSlider.Counter.text =  player.Workers.Distribution[WorkType.Collect] + "/" + player.Workers.MaxDistribution[WorkType.Collect];
        CollectSlider.Calculation.text = player.Workers.Distribution[WorkType.Collect] * 10 + "% Efficiency";
        CollectSlider.Slider.value = player.Workers.Distribution[WorkType.Collect];
        CollectSlider.Slider.maxValue = player.Workers.MaxDistribution[WorkType.Collect];

        /*
        Debug.Log(OrderSlider);
        OrderSlider.Counter.text = player.Workers.Distribution[WorkType.Order] + "/" + player.Workers.MaxDistribution[WorkType.Order];
        
        OrderSlider.Calculation.text = player.Workers.Distribution[WorkType.Order] * 10 + "% Efficiency";
        OrderSlider.Slider.value = player.Workers.Distribution[WorkType.Order];
        OrderSlider.Slider.maxValue = player.Workers.MaxDistribution[WorkType.Order];
        */

        StockSlider.Counter.text = player.Workers.Distribution[WorkType.Stock] + "/" + player.Workers.MaxDistribution[WorkType.Stock];
        if (player.Buildings.FindAllByKind(BuildingKind.Storage).Count > 0)
            StockSlider.Calculation.text = 50 + (player.Workers.Distribution[WorkType.Stock] / player.Workers.MaxDistribution[WorkType.Stock] * 50) + "% Efficiency";
        else
            StockSlider.Calculation.text = 100 + "% Efficiency";
        StockSlider.Slider.value = player.Workers.Distribution[WorkType.Stock];
        StockSlider.Slider.maxValue = player.Buildings.FindAllByKind(BuildingKind.Storage).Count;
    }

    public void CollectUpdate(float value)
    {

        int NewSliderSum = (int)(CollectSlider.Slider.value + /*OrderSlider.Slider.value*/ + StockSlider.Slider.value);
        //int OldSliderSum = PlayerSystem.Player.Workers.DistributionSum();
        if (NewSliderSum <= PlayerSystem.Player.Workers.Value)
        {
            PlayerSystem.Player.Workers.Distribution[WorkType.Collect] = (int)value;
            Refresh(PlayerSystem.Player);
        }
        else
        {
            CollectSlider.Slider.value = PlayerSystem.Player.Workers.Distribution[WorkType.Collect];
        }

        PlayerSystem.Refresh();
        //if ()
    }

    public void OrderUpdate(float value)
    {
        int NewSliderSum = (int)(CollectSlider.Slider.value + /*OrderSlider.Slider.value*/ + StockSlider.Slider.value);
        //int OldSliderSum = PlayerSystem.Player.Workers.DistributionSum();
        if (NewSliderSum <= PlayerSystem.Player.Workers.Value)
        {
            PlayerSystem.Player.Workers.Distribution[WorkType.Order] = (int)value;
            Refresh(PlayerSystem.Player);
        }
        else
        {
            CollectSlider.Slider.value = PlayerSystem.Player.Workers.Distribution[WorkType.Order];
        }

        PlayerSystem.Refresh();
    }

    public void StockUpdate(float value)
    {
        int NewSliderSum = (int)(CollectSlider.Slider.value + /*OrderSlider.Slider.value*/ + StockSlider.Slider.value);
        //int OldSliderSum = PlayerSystem.Player.Workers.DistributionSum();
        if (NewSliderSum <= PlayerSystem.Player.Workers.Value)
        {
            PlayerSystem.Player.Workers.Distribution[WorkType.Stock] = (int)value;
            Refresh(PlayerSystem.Player);
        }
        else
        {
            StockSlider.Slider.value = PlayerSystem.Player.Workers.Distribution[WorkType.Stock];
        }
        PlayerSystem.Refresh();
        
    }
}

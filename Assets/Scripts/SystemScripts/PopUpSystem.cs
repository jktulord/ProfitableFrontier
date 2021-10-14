using Assets.Scripts.Models.Heroes;
using Assets.Scripts.Models.PlayerModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PopUpSystem : MonoBehaviour
{
    private GameObject PopUpPanel;
    private GameObject LongPopUpPanel;
    private GameObject HeroStatsPrefab;
    
    private Canvas Canvas;

    public SpaceForStatusPops SpaceForStatusPops;

    [Inject]
    public void Construct(Canvas canvas, SpaceForStatusPops spaceForStatusPops)
    {
        Canvas = canvas;
        SpaceForStatusPops = spaceForStatusPops;
    } 

    public void Load()
    {
        PopUpPanel = Resources.Load<GameObject>("Prefabs/PopUp/PopUpPanel");
        LongPopUpPanel = Resources.Load<GameObject>("Prefabs/PopUp/LongPopUpPanel");
        HeroStatsPrefab = Resources.Load<GameObject>("Prefabs/PopUp/HeroStatsPanel");
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void RefreshStatusPops(Player player)
    {
        SpaceForStatusPops.Refresh(player);
    }

    public void ShowAknowledgeMessage(string Text)
    {
        GameObject gameObject = Instantiate(PopUpPanel, Canvas.transform);
        gameObject.GetComponent<PopUpPanel>().SetText(Text);
    }

    public void ShowBetterAknowledgeMessage(string Text)
    {
        GameObject gameObject = Instantiate(LongPopUpPanel, Canvas.transform);
        gameObject.GetComponent<LongPopUpPanel>().SetText(Text);
    }

    // Update is called once per frame
    public void ShowHeroStats(Hero hero)
    {
        GameObject gameObject = Instantiate(HeroStatsPrefab, Canvas.transform);
        gameObject.GetComponent<HeroStatsPanel>().Refresh(hero);
    }
}

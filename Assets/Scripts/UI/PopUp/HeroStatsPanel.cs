using Assets.Scripts.Models.Entity.Heroes.Needs;
using Assets.Scripts.Models.Heroes;
using TMPro;
using UnityEngine;

public class HeroStatsPanel : MonoBehaviour
{
    private TMP_Text Name;
    private TMP_Text Action;
    private HeroSpot HeroSpot;

    private TMP_Text Level;
    private TMP_Text Hp;

    private TMP_Text Silver;
    private TMP_Text Loot;

    private TMP_Text Happines;
    private TMP_Text Food;
    private TMP_Text Housing;
    


    public void Load()
    {
        Name = transform.Find("MainGroup").Find("Name").GetComponent<TMP_Text>();
        Action = transform.Find("MainGroup").Find("Action").GetComponent<TMP_Text>();
        HeroSpot = transform.Find("MainGroup").Find("HeroSpot").GetComponent<HeroSpot>();

        Level = transform.Find("RPGGroup").Find("Level").GetComponent<TMP_Text>();
        Hp = transform.Find("RPGGroup").Find("Hp").GetComponent<TMP_Text>();
        
        Silver = transform.Find("InventoryGroup").Find("Silver").GetComponent<TMP_Text>();
        Loot = transform.Find("InventoryGroup").Find("Loot").GetComponent<TMP_Text>();

        Happines = transform.Find("NeedsGroup").Find("Happines").GetComponent<TMP_Text>();
        Food = transform.Find("NeedsGroup").Find("Food").GetComponent<TMP_Text>();
        Housing = transform.Find("NeedsGroup").Find("Housing").GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    public void Refresh(Hero hero)
    {
        Load();

        Name.text = hero.Name;
        Action.text = "" + hero.Action;
        HeroSpot.Entity = hero;

        Level.text = "Level "+hero.Level.Current + " (" + hero.Level.CurExp + "/" + hero.Level.ExpCaps[hero.Level.Current] + ")";
        Hp.text = "Hp:"+hero.Hp.Amount + "/" + hero.Hp.Max;
        
        Silver.text = "Silver:"+hero.Silver;
        Loot.text = "Loot:"+hero.Loot;

        Happines.text = "Happines:" + hero.Needs.Average;
        Food.text = "Food:" + hero.Needs.Base[NeedKind.Food].Amount;
        Housing.text = "Housing:" + hero.Needs.Base[NeedKind.Housing].Amount;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}

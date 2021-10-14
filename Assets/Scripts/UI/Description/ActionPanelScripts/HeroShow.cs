using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Heroes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroShow : MonoBehaviour
{
    public GameObject PrefabLine;

    private Transform HeroList;
    // Start is called before the first frame update
    void Load()
    {
        HeroList = transform.Find("ScrollView").Find("Viewport").Find("HeroList").GetComponent<RectTransform>();
        PrefabLine = Resources.Load<GameObject>("Prefabs/HeroLine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearHeroes()
    {
        for (int i = 0; i < HeroList.transform.childCount; i++)
        {
            Destroy(HeroList.transform.GetChild(i).gameObject);
        }
    }

    public void Refresh(House building)
    {
        Load();
        ClearHeroes();
        foreach (Hero hero in building.Occupants)
        {
            GameObject Cur = Instantiate(PrefabLine, HeroList);
            Cur.GetComponent<TMP_Text>().text = hero.Name + " lv" + hero.Level.Current + " " + hero.Action;
            Cur.GetComponent<HeroLine>().Load();
            Cur.GetComponent<HeroLine>().button.onClick.AddListener(() => hero.ShowStats());
        }

    }
}

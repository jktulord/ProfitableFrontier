using Assets.Scripts.Models.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSpot : MonoBehaviour
{
    public bool IfCanShowPopUpLine = true;

    public StatusPop StatusPop;
    private Image Image;

    private EntityBase entity;
    public EntityBase Entity
    {
        get { return entity; }
        set
        {
            entity = value;
            Load();
            Image.sprite = Entity.Sprite;
        }
    }

    public void Load()
    {
        if (Image == null)
            Image = GetComponent<Image>();
    }

    public void Clear()
    {
        Load();
        Image.sprite = Resources.Load<Sprite>("Sprites/DungeonSprites/Empty");
    }

    void Start()
    {
        Load();
    }
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            StatusPop.gameObject.SetActive(false);
    }

    public void ShowStatsLine()
    {
        Load();
        if ((Entity != null) && (IfCanShowPopUpLine == true))
        { 
            StatusPop.gameObject.SetActive(true);
            StatusPop.SetText(Entity.Name + "Lv" + Entity.Level.Current + " Hp:" + Entity.Hp.Amount + "/" + Entity.Hp.Max, 170);
        }
    }

    
}

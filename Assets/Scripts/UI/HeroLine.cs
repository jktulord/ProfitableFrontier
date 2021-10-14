using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroLine : MonoBehaviour
{
    public Button button;

    public void Load()
    {
        button = transform.Find("Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
              
    }
}

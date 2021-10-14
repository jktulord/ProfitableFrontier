using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProSlider : MonoBehaviour
{
    public TMP_Text Counter;
    public TMP_Text Calculation;
    public Slider Slider;


    public void Load()
    {
        Counter = transform.Find("Counter").GetComponent<TMP_Text>();
        Calculation = transform.Find("Calculation").GetComponent<TMP_Text>();
        Slider = GetComponent<Slider>();         
    }

    // Start is called before the first frame update
    /*void Start()
    {
        Load();
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}

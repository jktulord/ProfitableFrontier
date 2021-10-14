using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpPanel : MonoBehaviour
{
    private TMP_Text Text;
    
    private void Load()
    {
        if (Text == null)
            Text = transform.Find("Text").GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        Load();
        Text.text = text;
    }
    
    public void Close()
    {
        Destroy(gameObject);
    }
}

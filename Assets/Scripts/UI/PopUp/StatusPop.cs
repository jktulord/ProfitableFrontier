using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusPop : MonoBehaviour
{
    private TMP_Text TextLine;

    public void Load()
    {
        if (TextLine == null)
            TextLine = transform.Find("TextLinePrefab").GetComponent<TMP_Text>();
    }

    public void SetText(string text, int Width = 90)
    {
        Load();
        TextLine.text = text;
        RectTransform rectTransform = (RectTransform)transform;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Width);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    public Transform Overlay;
    public Transform NotActiveOverlay;

    private bool current = false;

    public void Change()
    {
        RectTransform RectTransform = (RectTransform)transform;
        if (current == false)
        {
            transform.SetParent(Overlay);
           
            RectTransform.offsetMin = new Vector2(100, 100);
            RectTransform.offsetMax = new Vector2(-100, -100);

            /*
            float left = rt.offsetMin.x;
            float right = -rt.offsetMax.x;
            float top = -rt.offsetMax.y;
            float bottom = rt.offsetMin.y;
            */
            current = true;
        }
        else
        {
            transform.SetParent(NotActiveOverlay);
         
            RectTransform.offsetMin = new Vector2(30, 30);
            RectTransform.offsetMax = new Vector2(30, 30);
            current = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LongPopUpPanel : MonoBehaviour
{
    public Transform Content;
    public GameObject TextLinePrefab;

    public string Text = "";
    
    public void Load()
    {
        if (Content == null)
        {
            Content = transform.Find("ScrollView").Find("Viewport").Find("Content");
            TextLinePrefab = Resources.Load<GameObject>("Prefabs/UIPrefabs/TextLinePrefab");
        }
    }

    public void Clear()
    {
        Load();
        for (int i = 0; i < Content.childCount; i++ )
        {
            Destroy(Content.GetChild(i).gameObject);
        }
    }

    public void SetText(string text)
    {
        Text = text;
        Load();
        Clear();
        string[] Lines = text.Split(new char[] { '$' });
        foreach (string line in Lines)
        {
            GameObject gameObject = Instantiate(TextLinePrefab, Content);
            gameObject.GetComponent<TMP_Text>().text = line;
        }
    }
    
    public void Close()
    {
        Destroy(gameObject);
    }
}

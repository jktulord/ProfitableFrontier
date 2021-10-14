using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class TextAutoLiner : MonoBehaviour
{
    public Transform Content;
    private GameObject TextLinePrefab;

    private void Load()
    {
        if (TextLinePrefab == null)
        {
            TextLinePrefab = Resources.Load<GameObject>("Prefabs/UIPrefabs/TextLinePrefab");
        }
    }

    public void Clear()
    {
        int childAmount = transform.childCount;
        for (int i = 0; i < childAmount; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
    }

    public void SetText(string text)
    {
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
    


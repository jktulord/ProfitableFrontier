using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleLogScript : LongPopUpPanel
{
    public void AddLine(string line)
    {
        Load();
        GameObject gameObject = Instantiate(TextLinePrefab, Content);
        gameObject.GetComponent<TMP_Text>().text = line;
    }
}

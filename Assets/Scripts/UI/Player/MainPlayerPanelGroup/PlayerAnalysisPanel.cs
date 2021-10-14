using Assets.Scripts.ResInventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnalysisPanel : MonoBehaviour
{
    private TextAutoLiner UncollectedViewVertical;
    private TextAutoLiner IncomeViewVertical;
    private TextAutoLiner ExpensesViewVertical;
    private TMP_Text SilverUncollected;
    private TMP_Text SilverIncome;
    private TMP_Text SilverExpenses;

    // Start is called before the first frame update
    private void Load()
    {
        if (SilverUncollected == null)
        {
            UncollectedViewVertical = transform.Find("UncollectedViewVertical").GetComponent<TextAutoLiner>();
            IncomeViewVertical = transform.Find("IncomeViewVertical").GetComponent<TextAutoLiner>();
            ExpensesViewVertical = transform.Find("ExpensesViewVertical").GetComponent<TextAutoLiner>();
            SilverUncollected = transform.Find("SilverUncollected").GetComponent<TMP_Text>();
            SilverIncome = transform.Find("SilverIncome").GetComponent<TMP_Text>();
            SilverExpenses = transform.Find("SilverExpenses").GetComponent<TMP_Text>();
        }
            //BuildLimit = transform.Find("StatsView").Find("BuildLimit").GetComponent<TMP_Text>();
    }

    public void Refresh(Inventory Uncollected, Inventory Income, Inventory Expenses)
    {
        Load();
        string UncollectedLine = "";
        foreach (Resource cur in Uncollected.Res.Values)
        {
            UncollectedLine += cur.Name +":" + cur.Amount + "$";
        }
        UncollectedViewVertical.SetText(UncollectedLine);
        SilverUncollected.text = "Silver:" + Uncollected.Silver;

        string IncomeLine = "";
        foreach (Resource cur in Income.Res.Values)
        {
            IncomeLine += "+" + cur.Amount + "$";
        }
        IncomeViewVertical.SetText(IncomeLine);
        SilverIncome.text = "+" + Income.Silver;

        string ExpensesLine = "";
        foreach (Resource cur in Expenses.Res.Values)
        {
            ExpensesLine += "-" + cur.Amount + "$";
        }
        ExpensesViewVertical.SetText(ExpensesLine);
        SilverExpenses.text = "-" + Expenses.Silver;
    }
}

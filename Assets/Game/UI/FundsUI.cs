using System;
using Game;
using TMPro;
using UnityEngine;

public class FundsUI : MonoBehaviour
{
    public CompanyStats companyStats;
    public TextMeshProUGUI moneyDisplay;
    
    private void Start()
    {
        companyStats.StatsDictionary[TargetTags.CompFunds].onStatChanged += UpdateMoney;
        UpdateMoney(companyStats.StatsDictionary[TargetTags.CompFunds]);
    }

    private void UpdateMoney(Statistic stat)
    {
        moneyDisplay.text = stat.Value.ToString();
    }
}

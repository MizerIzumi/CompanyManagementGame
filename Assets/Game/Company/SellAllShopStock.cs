using System;
using Game;
using UnityEngine;

public class SellAllShopStock : MonoBehaviour
{
    public CompanyStats companyStats;
    public ShopAndCompInv shopAndCompInv;
    private TimeManager _timeManager;

    private void Start()
    {
        _timeManager = GameManager.Instance.timeManager;
    }

    public void SellAllStock()
    {
        if (shopAndCompInv.shopInventory.Count == 0) return;
        foreach (SO_ItemBase item in shopAndCompInv.shopInventory)
        {
            companyStats.StatsDictionary[TargetTags.CompFunds].IncreaseStat(item.SellValue);
        }
        shopAndCompInv.shopInventory.Clear();
        _timeManager.AdvanceTime();
    }
}

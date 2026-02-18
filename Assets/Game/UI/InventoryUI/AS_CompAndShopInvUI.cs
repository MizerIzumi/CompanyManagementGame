using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;

public class AS_CompAndShopInvUI : ActionStack.ActionBehavior
{
    [SerializeField]
    private GameObject _itemBoxPrefab;
    [SerializeField]
    private GameObject _invGrid;
    [SerializeField] 
    private TextMeshProUGUI _capacityDisplay;
    
    [SerializeField]
    private GameObject _compInv;

    [SerializeField]
    private GameObject _shopInv;

    private List<SO_ItemBase> _activeInventory;
    private List<GameObject> _spawnedItemBoxes;
    private List<ItemBox> _selectedItems;
    public ShopAndCompInv shopAndCompInv;
    private bool _compToShop = true;
    
    private bool _isDone = false;


    public override void OnBegin(bool bFirstTime)
    {
        base.OnBegin(bFirstTime);
        if (bFirstTime)
        {
            shopAndCompInv.OnCompInvChanged += UpdateCapacityDisplay;
        }

        _isDone = false;
        EnableUI();
    }


    private void UpdateCapacityDisplay(int value)
    {
        _capacityDisplay.text = _activeInventory.Count.ToString() + " | " + _activeInventory.Capacity.ToString();
    }
    
    public void TransferToShop()
    {
        List<SO_ItemBase> sinv = shopAndCompInv._shopInventory;
        List<SO_ItemBase> cinv = shopAndCompInv._companyInventory;
        
        foreach (ItemBox itembox in _selectedItems)
        {
            sinv.Add(itembox.item);
            cinv.Remove(itembox.item);
            _spawnedItemBoxes.Remove(itembox.gameObject);
        }
    }
    
    public void TransferToCompany()
    {
        List<SO_ItemBase> sinv = shopAndCompInv._shopInventory;
        List<SO_ItemBase> cinv = shopAndCompInv._companyInventory;
        
        foreach (ItemBox itembox in _selectedItems)
        {
            cinv.Add(itembox.item);
            sinv.Remove(itembox.item);
            _spawnedItemBoxes.Remove(itembox.gameObject);
        }
    }

    public void EnableUI()
    {
        gameObject.SetActive(true);
        if (_compToShop)
        {
            //Company inv
            _activeInventory = shopAndCompInv._companyInventory;
            DisableInvUI(_shopInv);
            EnableInvUI(_compInv);
        }
        else
        {
            //Shop inv
            _activeInventory = shopAndCompInv._shopInventory;
            DisableInvUI(_compInv);
            EnableInvUI(_shopInv);
        }
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
        ClearAllItems();
    }

    public void CompOrShopView(bool company)
    {
        _compToShop = company;
        if (_compToShop)
        {
            //Company inv
            _activeInventory = shopAndCompInv._companyInventory;
            DisableInvUI(_shopInv);
            EnableInvUI(_compInv);
        }
        else
        {
            //Shop inv
            _activeInventory = shopAndCompInv._shopInventory;
            DisableInvUI(_compInv);
            EnableInvUI(_shopInv);
        }
    }
    
    private void EnableInvUI(GameObject invUI)
    {
        invUI.SetActive(true);
        AddItemsFromInventory();
    }

    private void DisableInvUI(GameObject invUI)
    {
        invUI.SetActive(false);
        ClearAllItems();
    }

    private void AddItemsFromInventory()
    {
        foreach (SO_ItemBase item in _activeInventory)
        {
            GameObject itembox = Instantiate(_itemBoxPrefab, _invGrid.transform);
            itembox.GetComponent<ItemBox>().InitializeItemBox(item, this);
            _spawnedItemBoxes.Add(itembox);
        }
    }
    
    public bool TrySelectItemBox(ItemBox itembox)
    {
        if (_selectedItems.Contains(itembox))
        {
            return false;
        }
        
        if (_compToShop)
        {
            if (shopAndCompInv.shopInvCapacity <= _selectedItems.Count) return false;
        }
        else
        {
            if (shopAndCompInv.companyInvCapacity <= _selectedItems.Count) return false;
        }
        
        _selectedItems.Add(itembox);
        return true;
    }

    private void ClearAllItems()
    {
        if (_selectedItems.Count == 0) return;
        foreach (GameObject itembox in _spawnedItemBoxes)
        {
            Destroy(itembox.gameObject); 
        }
        _spawnedItemBoxes.Clear();
        _selectedItems.Clear();
    }

    public void Exit()
    {
        _isDone = true;
    }
    
    public override bool IsDone()
    {
        base.IsDone();
        return _isDone;
    }

    public override void OnEnd()
    {
        base.OnEnd();
        DisableUI();
        ClearAllItems();
    }
}

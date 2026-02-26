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
    private List<GameObject> _spawnedItemBoxes = new();
    private List<ItemBox> _selectedItems = new();
    public ShopAndCompInv shopAndCompInv;
    private bool _compToShop = true;
    private bool _isDone = false;

    private int _compInvCap = 0;
    private int _shopInvCap = 0;


    public override void OnBegin(bool bFirstTime)
    {
        base.OnBegin(bFirstTime);
        _isDone = false;
        _compInvCap = shopAndCompInv.companyInvCapacity;
        _shopInvCap = shopAndCompInv.shopInvCapacity;
        if (bFirstTime) { }
        EnableUI();
    }


    private void UpdateCapacityDisplay(int invCapacity)
    {
        _capacityDisplay.text = _activeInventory.Count.ToString() + " | " + invCapacity.ToString();
    }
    
    public void TransferToShop()
    {
        if (_selectedItems == null || _selectedItems.Count == 0) return;
        foreach (ItemBox itembox in _selectedItems)
        {
            shopAndCompInv.ItemFromCompToShopInv(itembox.item);
            _spawnedItemBoxes.Remove(itembox.gameObject);
            Destroy(itembox.gameObject);
        }

        ClearSelectedItems();
        UpdateCapacityDisplay(_compInvCap);
    }
    
    public void TransferToCompany()
    {
        if (_selectedItems == null || _selectedItems.Count == 0) return;
        foreach (ItemBox itembox in _selectedItems)
        {
            shopAndCompInv.ItemFromShopInvToComp(itembox.item);
            _spawnedItemBoxes.Remove(itembox.gameObject);
            Destroy(itembox.gameObject);
        }

        ClearSelectedItems();
        UpdateCapacityDisplay(_shopInvCap);
    }

    public void EnableUI()
    {
        gameObject.SetActive(true);
        CompOrShopView(_compToShop);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
        ClearAllItems();
    }

    public void CompOrShopView(bool company)
    {
        _compToShop = company;
        if (company)
        {
            //Company inv
            _activeInventory = shopAndCompInv.companyInventory;
            UpdateCapacityDisplay(_compInvCap);
            DisableInvUI(_shopInv);
            EnableInvUI(_compInv);
        }
        else
        {
            //Shop inv
            _activeInventory = shopAndCompInv.shopInventory;
            UpdateCapacityDisplay(_shopInvCap);
            DisableInvUI(_compInv);
            EnableInvUI(_shopInv);
        }
    }
    
    private void EnableInvUI(GameObject invUI)
    {
        invUI.SetActive(true);
        ClearAllItems();
        AddItemsFromInventory();
    }

    private void DisableInvUI(GameObject invUI)
    {
        invUI.SetActive(false);
        ClearAllItems();
    }

    private void AddItemsFromInventory()
    {
        if (_activeInventory.Count <= 0) return;
        
        foreach (SO_ItemBase item in _activeInventory)
        {
            GameObject itembox = Instantiate(_itemBoxPrefab, _invGrid.transform);
            itembox.TryGetComponent<ItemBox>(out ItemBox _itembox);
            _itembox?.InitializeItemBox(item, this);
            
            _spawnedItemBoxes.Add(itembox);
        }
    }
    
    public bool TrySelectItemBox(ItemBox itembox)
    {
        if (_selectedItems.Contains(itembox))
        {
            _selectedItems.Remove(itembox);
            return false;
        }
        
        if (_compToShop)
        {
            if (shopAndCompInv.shopInvCapacity - shopAndCompInv.shopInventory.Count <= _selectedItems.Count) return false;
        }
        else
        {
            if (shopAndCompInv.companyInvCapacity - shopAndCompInv.companyInventory.Count<= _selectedItems.Count) return false;
        }
        
        _selectedItems.Add(itembox);
        return true;
    }

    private void ClearAllItems()
    {
        if (_spawnedItemBoxes == null || _spawnedItemBoxes.Count == 0) return;
        foreach (GameObject itembox in _spawnedItemBoxes)
        {
            Destroy(itembox.gameObject); 
        }
        _spawnedItemBoxes.Clear();
        if (_selectedItems == null || _selectedItems.Count == 0) return;
        _selectedItems.Clear();
    }

    private void ClearSelectedItems()
    {
        if (_selectedItems == null || _selectedItems.Count == 0) return;
        foreach (ItemBox itembox in _selectedItems)
        {
            _spawnedItemBoxes.Remove(itembox.gameObject);
            Destroy(itembox.gameObject);
        }
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ShopAndCompInv : MonoBehaviour
    {
        public event Action<int> OnCompInvChanged;
        public event Action<int> OnShopInvChanged;
        
        private CompanyStats _companyStats;
        [Header("Company")]
        public List<SO_ItemBase> _companyInventory;

        private int _compinvcap;
        public int companyInvCapacity
        {
            get { return _compinvcap; }
            set
            {
                _compinvcap = value;
            }
        }
    
        [Header("Shop")]
        public List<SO_ItemBase> _shopInventory;

        private int _shopInvCapacity;
        public int shopInvCapacity
        {
            get { return _shopInvCapacity; }
            set
            {
                _shopInvCapacity = value; 
            }
        }

        private void Start()
        {
            _companyStats = gameObject.GetComponent<CompanyStats>();
            _companyStats.StatsDictionary[TargetTags.CompInvSize].onStatChanged += UpdateCompanyInventoryCapacity;
            _companyStats.StatsDictionary[TargetTags.CompShopInvSize].onStatChanged += UpdateShopInventoryCapacity;
            companyInvCapacity = (int)_companyStats.StatsDictionary[TargetTags.CompInvSize].Value;
            shopInvCapacity = (int)_companyStats.StatsDictionary[TargetTags.CompShopInvSize].Value;
        }


        public void AddItemToCompInv(SO_ItemBase item)
        {
            if (_companyInventory.Count < companyInvCapacity)
            {
                AddItem(_companyInventory, item);
            }
        }
        
        public void ItemFromCompToShopInv(SO_ItemBase item)
        {
            TryMoveItemToInv(_companyInventory, _shopInventory, shopInvCapacity, item);
        }

        public void ItemFromShopInvToComp(SO_ItemBase item)
        {
            TryMoveItemToInv(_shopInventory, _companyInventory, companyInvCapacity, item);
        }
        
        

        private bool TryMoveItemToInv(List<SO_ItemBase> fromInventoryA, List<SO_ItemBase> toInventoryB, int CapacityB, SO_ItemBase item)
        {
            if (!item)
            {
                Debug.LogError("Item can not be null!");
                return false;
            }

            if (fromInventoryA.Contains(item))
            {
                if (toInventoryB.Count < CapacityB)
                {
                    RemoveItem(fromInventoryA, item);
                    AddItem(toInventoryB, item);
                    return true;
                }
            }
            return false;
        }

        public void AddItem(List<SO_ItemBase> inventory, SO_ItemBase item)
        {
            inventory.Add(item);
        }
        
        public void RemoveItem(List<SO_ItemBase> inventory, SO_ItemBase item)
        {
            inventory.Remove(item);
        }
    
        
        
        private void UpdateCompanyInventoryCapacity(Statistic stat)
        {
            companyInvCapacity = Mathf.FloorToInt(stat.Value);
        }

        private void UpdateShopInventoryCapacity(Statistic stat)
        {
            shopInvCapacity = Mathf.FloorToInt(stat.Value);
        }
    }
}


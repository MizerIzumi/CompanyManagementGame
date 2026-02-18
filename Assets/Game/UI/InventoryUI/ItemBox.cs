using TMPro;
using UnityEngine;

namespace Game
{
    public class ItemBox : MonoBehaviour
    {
        public SO_ItemBase item;
        private AS_CompAndShopInvUI _cnsInv;
        [SerializeField]
        private GameObject _selectedBorder;
        [SerializeField]
        private TextMeshProUGUI _itemName;

        public void InitializeItemBox(SO_ItemBase inititem, AS_CompAndShopInvUI compAndShopInvUI)
        {
            item = inititem;
            _cnsInv = compAndShopInvUI;
            _itemName.text = item.ItemName;
        }
        
        public void SelectBox()
        {
            if (_cnsInv.TrySelectItemBox(this))
            {
                _selectedBorder.SetActive(true);
                return;
            }
            DeselectBox();
        }

        public void DeselectBox()
        {
            _selectedBorder.SetActive(false);
        }
    }
}


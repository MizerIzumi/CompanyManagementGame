using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "It_Item", menuName = "ScriptableObjects/Items/Item", order = 99)]
    public class SO_ItemBase : ScriptableObject
    {
        public string ItemName;
        public int SellValue;
        //public Vector2 range;
        protected void AddToStorage()
        {
            //TO DO - Add the Equipment to storage;
        }
    }
}
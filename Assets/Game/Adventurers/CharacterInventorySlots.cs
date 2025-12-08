using System.Collections.Generic;

namespace Game
{
    public class CharacterInventorySlots
    {
        public int InvSize;

        private List<SO_ItemBase> Items = new List<SO_ItemBase>();

        public bool TryAddItem(SO_ItemBase item)
        {
            if (item == null || Items.Count == InvSize)
            {
                return false;
            }

            Items.Add(item);
            return true;
        }

        public bool ReplaceItem(SO_ItemBase replacedItem, SO_ItemBase replacementItem)
        {
            if (replacedItem && replacementItem)
            {
                if (Items.Contains(replacedItem))
                {
                    Items.Remove(replacedItem);
                }

                Items.Add(replacementItem);

                return true;
            }

            return false;
        }

        public List<SO_ItemBase> GetItems()
        {
            return Items;
        }
    }
}
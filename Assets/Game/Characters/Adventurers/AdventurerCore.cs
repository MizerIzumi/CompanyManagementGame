using UnityEngine;

namespace Game
{
    public class AdventurerCore : MonoBehaviour
    {
        public AdventurerStats adventurerStats;
        public CharacterEquipmentSlots equipmentSlots;
        public CharacterInventorySlots inventorySlots;
        
        //TODO: Rer rout all direct references used in the scripts adventurers use to go through this one instead
        //Also fix adventurers inventories, for now rewards are just going to go straight to the company storage.
    }
}


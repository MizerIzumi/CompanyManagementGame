using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class CharacterEquipmentSlots : MonoBehaviour
    {
        public SO_WeaponBase Weapon;
        public SO_HelmetBase Helmet;
        public SO_ChestPieceBase ChestPiece;
        public SO_BootsBase Boots;
        public SO_AccessoryBase Accessory;
        private bool _initialized = false;

        public void InitializeEquipment(EquipmentSet startingequipment)
        {
            if (_initialized)
            {
                Debug.Log("Character equipment already initialized");
                return;
            }
            
            Weapon = startingequipment.Weapon;
            Helmet = startingequipment.Helmet;
            ChestPiece =  startingequipment.ChestPiece;
            Boots = startingequipment.Boots;
            Accessory = startingequipment.Accessory;
            _initialized = true;
        }
    }
    
    [Serializable]
    public struct EquipmentSet
    {
        public SO_WeaponBase Weapon;
        public SO_HelmetBase Helmet;
        public SO_ChestPieceBase ChestPiece;
        public SO_BootsBase Boots;
        public SO_AccessoryBase Accessory;
    }
}


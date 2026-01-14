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

        public void UnequipAll()
        {
            Weapon.Unequip(this);
            Helmet.Unequip(this);
            ChestPiece.Unequip(this);
            Boots.Unequip(this);
            Accessory.Unequip(this);
        }

        public void TestingOnlyEquipSet(EquipmentSet equipmentSet)
        {
            UnequipAll();
            Weapon = equipmentSet.Weapon;
            Helmet = equipmentSet.Helmet;
            ChestPiece = equipmentSet.ChestPiece;
            Boots = equipmentSet.Boots;
            Accessory = equipmentSet.Accessory;
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


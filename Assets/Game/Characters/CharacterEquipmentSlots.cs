using System;
using UnityEngine;

namespace Game
{
    public class CharacterEquipmentSlots : MonoBehaviour
    {
        public AdventurerStats advStats;
        
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
            if (Weapon != null) Weapon.Unequip(this);
            if (Helmet != null) Helmet.Unequip(this);
            if (ChestPiece != null) ChestPiece.Unequip(this);
            if (Boots != null) Boots.Unequip(this);
            if (Accessory != null) Accessory.Unequip(this);
        }

        public void TestingOnlyEquipSet(EquipmentSet equipmentSet)
        {
            UnequipAll();
            equipmentSet.Weapon.Equip(this);
            equipmentSet.Helmet.Equip(this);
            equipmentSet.ChestPiece.Equip(this);
            equipmentSet.Boots.Equip(this);
            equipmentSet.Accessory.Equip(this);
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


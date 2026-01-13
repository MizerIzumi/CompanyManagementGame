using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Weapon", menuName = "ScriptableObjects/Items/Weapon", order = 1)]
    public class SO_WeaponBase : SO_EquipmentBase
    {
        public int Damage;
        
        public override void Equip(CharacterEquipmentSlots target)
        {
            base.Equip(target);
            if (target.Weapon !=null)
            {
                target.Weapon.Unequip(target);
            }

            target.Weapon = this;
            Debug.Log("Equipping " + target.Weapon.name);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            base.Unequip(target);
            if (target.Weapon != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            
            Debug.Log("Unequipping " + name);
            AddToStorage();
            target.Weapon = null;
        }
    }
}
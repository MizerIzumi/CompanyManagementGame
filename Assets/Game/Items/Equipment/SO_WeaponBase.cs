using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Weapon", menuName = "ScriptableObjects/Items/Weapon", order = 1)]
    public class SO_WeaponBase : SO_EquipmentBase
    {
        public override void Equip(CharacterEquipmentSlots target)
        {
            if (target.Weapon !=null)
            {
                target.Weapon.Unequip(target);
            }
            target.Weapon = this;
            base.Equip(target);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            if (target.Weapon != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            base.Unequip(target);
            AddToStorage();
            target.Weapon = null;
        }
    }
}
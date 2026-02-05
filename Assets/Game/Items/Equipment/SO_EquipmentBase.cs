

using UnityEngine;

namespace Game
{
    public class SO_EquipmentBase : SO_ItemBase
    {
        public Modifier[] modifiers;

        public virtual void Equip(CharacterEquipmentSlots target)
        {
            target.advStats.ApplyModifiers(modifiers);
        }

        public virtual void Unequip(CharacterEquipmentSlots target)
        {
            //Debug.Log("Unequipping " + name);
            target.advStats.RemoveModifiers(modifiers);
        }
    }
}

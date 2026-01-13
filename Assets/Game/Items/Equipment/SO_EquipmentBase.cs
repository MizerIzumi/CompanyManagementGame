

namespace Game
{
    public class SO_EquipmentBase : SO_ItemBase
    {
        public Modifier[] modifiers;

        public virtual void Equip(CharacterEquipmentSlots target) {}
        public virtual void Unequip(CharacterEquipmentSlots target) {}
    }
}

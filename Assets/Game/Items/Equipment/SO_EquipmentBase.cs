

namespace Game
{
    public class SO_EquipmentBase : SO_ItemBase
    {
        public Modifier[] modifiers;

        public virtual void Equip(CharacterEquipmentSlots target)
        {
            foreach (Modifier modifier in modifiers)
            {
                target.advStats.StatsDictionary[modifier.TargetTag].AddModifier(modifier);
            }
        }

        public virtual void Unequip(CharacterEquipmentSlots target)
        {
            foreach (Modifier modifier in modifiers)
            {
                target.advStats.StatsDictionary[modifier.TargetTag].TryRemoveModifier(modifier);
            }
        }
    }
}

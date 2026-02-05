using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Accessorie", menuName = "ScriptableObjects/Items/Accessorie", order = 5)]
    public class SO_AccessoryBase : SO_EquipmentBase
    {
        
        public override void Equip(CharacterEquipmentSlots target)
        {
            if (target.Accessory !=null)
            {
                target.Accessory.Unequip(target);
            }
            target.Accessory = this;
            base.Equip(target);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            if (target.Accessory != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            base.Unequip(target);
            AddToStorage();
            target.Accessory = null;
        }
    }
}
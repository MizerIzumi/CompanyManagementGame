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
            Debug.Log("Equipping " + target.Accessory.name);
            base.Equip(target);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            if (target.Accessory != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            
            Debug.Log("Unequipping " + name);
            base.Unequip(target);
            AddToStorage();
            target.Accessory = null;
        }
    }
}
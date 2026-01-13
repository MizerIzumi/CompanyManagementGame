using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Boots", menuName = "ScriptableObjects/Items/Boots", order = 4)]
    public class SO_BootsBase : SO_EquipmentBase
    {
        public int Defence;
        
        public override void Equip(CharacterEquipmentSlots target)
        {
            base.Equip(target);
            if (target.Boots !=null)
            {
                target.Boots.Unequip(target);
            }

            target.Boots = this;
            Debug.Log("Equipping " + target.Boots.name);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            base.Unequip(target);
            if (target.Boots != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            
            Debug.Log("Unequipping " + name);
            AddToStorage();
            target.Boots = null;
        }
    }
}
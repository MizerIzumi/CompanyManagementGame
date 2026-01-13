using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Helmet", menuName = "ScriptableObjects/Items/Helmet", order = 2)]
    public class SO_HelmetBase : SO_EquipmentBase
    {
        public int Defence;

        public override void Equip(CharacterEquipmentSlots target)
        {
            base.Equip(target);
            if (target.Helmet !=null)
            {
                target.Helmet.Unequip(target);
            }

            target.Helmet = this;
            Debug.Log("Equipping " + target.Helmet.name);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            base.Unequip(target);
            if (target.Helmet != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            
            Debug.Log("Unequipping " + name);
            AddToStorage();
            target.Helmet = null;
        }
    }
}
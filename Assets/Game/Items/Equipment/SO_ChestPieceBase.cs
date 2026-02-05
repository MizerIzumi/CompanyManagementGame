using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_ChestPiece", menuName = "ScriptableObjects/Items/ChestPiece", order = 3)]
    public class SO_ChestPieceBase : SO_EquipmentBase
    {
        public override void Equip(CharacterEquipmentSlots target)
        {
            if (target.ChestPiece !=null)
            {
                target.ChestPiece.Unequip(target);
            }
            target.ChestPiece = this;
            base.Equip(target);
        }

        public override void Unequip(CharacterEquipmentSlots target)
        {
            if (target.ChestPiece != this)
            {
                Debug.LogError("ERROR - Item: " + name + " not equipped by " + target.name);
            }
            base.Unequip(target);
            AddToStorage();
            target.ChestPiece = null;
        }
    }
}
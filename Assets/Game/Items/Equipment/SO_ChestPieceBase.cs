using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_ChestPiece", menuName = "ScriptableObjects/Items/ChestPiece", order = 3)]
    public class SO_ChestPieceBase : SO_EquipmentBase
    {
        public int Defence;
    }
}
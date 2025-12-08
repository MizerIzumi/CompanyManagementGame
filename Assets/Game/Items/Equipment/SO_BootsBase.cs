using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Boots", menuName = "ScriptableObjects/Items/Boots", order = 4)]
    public class SO_BootsBase : SO_EquipmentBase
    {
        public int Defence;
    }
}
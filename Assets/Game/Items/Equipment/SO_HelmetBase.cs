using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Helmet", menuName = "ScriptableObjects/Items/Helmet", order = 2)]
    public class SO_HelmetBase : SO_EquipmentBase
    {
        public int Defence;
    }
}
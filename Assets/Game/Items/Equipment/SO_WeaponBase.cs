using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Weapon", menuName = "ScriptableObjects/Items/Weapon", order = 1)]
    public class SO_WeaponBase : SO_EquipmentBase
    {
        public int Damage;
    }
}
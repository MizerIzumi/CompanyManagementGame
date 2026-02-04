using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game
{
    [CreateAssetMenu(fileName = "SO_Profession", menuName = "ScriptableObjects/Adventurer/Profession", order = 1)]
    public class SO_AdventurerProfessionBase : ScriptableObject
    {
        public string ProfessionName;
        
        public SO_EquipmentSetBase startingEquipment;
        
        public StatInitializer[] StartingStats = new StatInitializer[11]
        {
            new StatInitializer("Level", 0, 0, -999, 999),
            new StatInitializer("Health", 0, 0, -999, 999),
            new StatInitializer("Mana", 0, 0, -999, 999),
            new StatInitializer("Strength", 0, 0, -999, 999),
            new StatInitializer("Dexterity", 0, 0, -999, 999),
            new StatInitializer("Intelligence", 0, 0, -999, 999),
            new StatInitializer("Physical Damage", 0, 0, -999, 999),
            new StatInitializer("Magic Damage", 0, 0, -999, 999),
            new StatInitializer("Physical Defence", 0, 0, -999, 999),
            new StatInitializer("Magical Defence", 0, 0, -999, 999),
            new StatInitializer("Inventory Size", 0, 0, -999, 999)
        };
    }
}
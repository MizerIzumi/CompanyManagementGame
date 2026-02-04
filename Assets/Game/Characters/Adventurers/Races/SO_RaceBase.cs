using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Race", menuName = "ScriptableObjects/Adventurer/Race", order = 2)]
    public class SO_RaceBase : ScriptableObject
    {
        public string RaceName;
        public ConditionalTags RaceTag;
        public ConditionalTags IncompatableSubRace;
        public StatInitializer[] StartingStats = new StatInitializer[11]
        {
            new StatInitializer("Level", 0, 1, -999, 999),
            new StatInitializer("Health", 0, 1, -999, 999),
            new StatInitializer("Mana", 0, 1, -999, 999),
            new StatInitializer("Strength", 0, 1, -999, 999),
            new StatInitializer("Dexterity", 0, 1, -999, 999),
            new StatInitializer("Intelligence", 0, 1, -999, 999),
            new StatInitializer("Physical Damage", 0, 1, -999, 999),
            new StatInitializer("Magic Damage", 0, 1, -999, 999),
            new StatInitializer("Physical Defence", 0, 1, -999, 999),
            new StatInitializer("Magical Defence", 0, 1, -999, 999),
            new StatInitializer("Inventory Size", 0, 1, -999, 999)
        };
        
    }
}


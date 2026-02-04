using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_SubRace", menuName = "ScriptableObjects/Adventurer/Sub-Race", order = 3)]
    public class SO_SubRaceBase : ScriptableObject
    {
        public string SubRaceName;
        public ConditionalTags SubRaceTag;
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


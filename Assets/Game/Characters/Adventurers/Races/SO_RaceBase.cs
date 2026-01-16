using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_Race", menuName = "ScriptableObjects/Adventurer/Race", order = 2)]
    public class SO_RaceBase : ScriptableObject
    {
        public string RaceName;
        public ConditionalTags RaceTag;
        public ConditionalTags IncompatableSubRace;
        public Modifier[] modifiers;
    }
}


using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_SubRace", menuName = "ScriptableObjects/Adventurer/Sub-Race", order = 3)]
    public class SO_SubRaceBase : ScriptableObject
    {
        public string SubRaceName;
        public ConditionalTags SubRaceTag;
        public Modifier[] modifiers;
    }
}


using UnityEngine;


namespace Game
{
    [CreateAssetMenu(fileName = "SO_Profession", menuName = "ScriptableObjects/Adventurer/Profession", order = 1)]
    public class SO_AdventurerProfessionBase : ScriptableObject
    {
        public string ClassName;
        public AdventurerStatsInitializer InitialStats;
    }
}
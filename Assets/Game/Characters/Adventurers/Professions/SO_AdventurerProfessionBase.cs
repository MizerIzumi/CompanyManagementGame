using UnityEngine;
using UnityEngine.Serialization;


namespace Game
{
    [CreateAssetMenu(fileName = "SO_Profession", menuName = "ScriptableObjects/Adventurer/Profession", order = 1)]
    public class SO_AdventurerProfessionBase : ScriptableObject
    {
        public string ProfessionName;
        
        public int InitialHp;
        public int InitialMp;
        
        public int InitialStr;
        public int InitialDex;
        public int InitialInt;
        
        public int InitialPDamage;
        public int InitialMDamage;
        public int InitialPDefence;
        public int InitialMDefence;
        
        public Modifier[] modifiers;
    }
}
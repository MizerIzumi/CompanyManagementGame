using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_EncounterData", menuName = "ScriptableObjects/EncounterData", order = 4)]
    public class SO_EncounterData : ScriptableObject
    {
        //TODO: Numbers will need revision when equipment gets fully implemented
        public enum Difficulty
        {
            VeryEasy = 25,
            Easy = 50,
            Medium = 75,
            Hard = 100,
            VeryHard = 125,
            Extreme = 150
        }
        
        public string encounterName;
        public string encounterDescription;
        public Rarity encounterRarity;
        
        public EncounterOption optionA;
        public EncounterOption optionB;
        public EncounterOption optionC;
        public EncounterOption optionD;

        [Serializable]
        public struct EncounterOption
        {
            public string optionDescription;
            public Difficulty difficulty;
            public TargetTags stat;
            public bool hasReward;
            public bool hasPenalty;

            
            //TODO: Re work these so that rewards and penalties are scriptable object
            //reward
            public List<SO_ItemBase> rewards;
            public ConditionalTags condition;

            //Penalty
            
        }
    }


}

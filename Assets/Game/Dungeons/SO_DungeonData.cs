using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SO_DungeonData", menuName = "ScriptableObjects/DungeonData", order = 3)]
    public class SO_DungeonData : ScriptableObject
    {
        public string dungeonName;
        public int dangerRating = 1;
        public int duration = 3;
        public int partySize = 1;
        public int encounterRate = 25;

        //Conditional bonuses/detriments here
        
        public List<SO_EncounterData>  encounters = new List<SO_EncounterData>();
        
        //Completion rewards here


    }
}



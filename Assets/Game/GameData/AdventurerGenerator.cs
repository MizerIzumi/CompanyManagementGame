using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AdventurerGenerator : MonoBehaviour
    {
        public HashSet<SO_SubRaceBase> AvailableRaces = new();
        public HashSet<SO_SubRaceBase> AvailableSubRaces = new();
        public HashSet<SO_AdventurerProfessionBase> AvailableProfessions = new();
        
        public void GenerateAdventurerData()
        {
            
        }
    }
}


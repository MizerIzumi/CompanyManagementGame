using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    public class MissionManager : MonoBehaviour
    {
        public CompanyStats companystats;


        public void MissionComplete(List<AdventurerStats> party, int dangerRating)
        {
            foreach (AdventurerStats adventurer in party)
            {
                GiveAdvanturerExp(adventurer, dangerRating, party.Count);
            }
        }
        
        private void GiveAdvanturerExp(AdventurerStats adventurerStats, int dangerRating, int partySize)
        {
            float level = adventurerStats.StatsDictionary[TargetTags.AdvLevel].Value;
            int rankDifference = dangerRating - (int)level;

            float exp = GlobalFunctions.Functions.CalculateExpToNextLevel((int)level);
            double multiplier = 1 + (0.15 * rankDifference);
        
            multiplier = math.clamp(multiplier, 0.01, 2.5);
        
            adventurerStats.GiveExp((exp * (float)multiplier)/partySize);
            print("Adventurer " + adventurerStats.GetName() + " Gained: " + (exp * multiplier) / partySize + " Exp!");
            adventurerStats.missionsCleared++;
        }
    }
}
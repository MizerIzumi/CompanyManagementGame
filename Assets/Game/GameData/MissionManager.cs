using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    public class MissionManager : MonoBehaviour
    {
        public CompanyStats companystats;
        
        
        public void GiveAdvanturerExp(AdventurerStats adventurerStats, int missionRank)
        {
            float level = adventurerStats.StatsDictionary[TargetTags.AdvLevel].Value;
            int rankDifference = missionRank - (int)level;

            float exp = GlobalFunctions.Functions.CalculateExpToNextLevel((int)level);
            double multiplier = 1 + (0.15 * rankDifference);
        
            multiplier = math.clamp(multiplier, 0.01, 2.5);
        
            adventurerStats.GiveExp(exp * (float)multiplier);
            print("Adventurer " + adventurerStats.GetName() + " Gained: " + exp * multiplier + " Exp!");
            adventurerStats.missionsCleared++;
        }
    }
}
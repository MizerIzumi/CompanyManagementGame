using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GlobalFunctions
{
    public static class Functions
    {
        public static float CalculateExpToNextLevel(float characterLevel)
        {
            float exp = 0;

            exp = 100 * Mathf.Pow(characterLevel, 1.8f);
            
            return exp;
        }

        public static Rarity GetRandomRarity()
        {
            //TODO: Move these ints to the Game Manager
            int totalChances = 10000;
            
            int uncommonChances = 3000;
            int rareChances = 1500;
            int epicChances = 750;
            int legendaryChances = 100;
            
            int commonChances = totalChances - uncommonChances - rareChances - epicChances - legendaryChances;
            
            Dictionary<int, Rarity> chances = new()
            {
                {legendaryChances, Rarity.Legendary},
                {epicChances, Rarity.Epic},
                {rareChances, Rarity.Rare},
                {uncommonChances, Rarity.Uncommon},
                {commonChances, Rarity.Common}
            };
            
            int rngValue = UnityEngine.Random.Range(0, totalChances);

            int currentOdds = 0;
            foreach (var chance in chances)
            {
                currentOdds += chance.Key;
                if (rngValue > totalChances - currentOdds)
                {
                    return chance.Value;
                }
            }
            return Rarity.ERROR;
        }
    }
}


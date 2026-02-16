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
    }
}


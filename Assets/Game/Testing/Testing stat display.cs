using System;
using UnityEngine;
using TMPro;

namespace Game
{
    public class Testingstatdisplay : MonoBehaviour
    {
        public AdventurerStats adventurerStats;
        public TextMeshProUGUI Int;
        public TextMeshProUGUI Str;
        public TextMeshProUGUI Dex;

        private void Start()
        {
            AdventurerStatsInitializer adinit = new();
            adinit.InitialDex = 10;
            adventurerStats.InitializeAdvStats(adinit);
        }

        void Update()
        {
            Int.text = adventurerStats.StatsDictionary[TargetTags.AdvIntelligence].Value.ToString();
            Str.text = adventurerStats.StatsDictionary[TargetTags.AdvStrength].Value.ToString();
            Dex.text = adventurerStats.StatsDictionary[TargetTags.AdvDexterity].Value.ToString();
        }
    }
}
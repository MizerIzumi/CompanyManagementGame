using System;
using UnityEngine;
using TMPro;

namespace Game
{
    public class Testingstatdisplay : MonoBehaviour
    {
        public AdventurerStats adventurerStats;
        public CharacterEquipmentSlots characterEquipmentSlots;
        public SO_EquipmentSetBase equipmentSet;
        public TextMeshProUGUI Int;
        public TextMeshProUGUI Str;
        public TextMeshProUGUI Dex;

        private void Start()
        {
            AdventurerStatsInitializer adinit = new();
            adinit.InitialDex = 10;
            adventurerStats.InitializeAdvStats(adinit);
        }

        public void TestingEquipSet()
        {
            characterEquipmentSlots.TestingOnlyEquipSet(equipmentSet.equipmentSet);
        }

        public void TestingUnequipAll()
        {
            characterEquipmentSlots.UnequipAll();
        }

        void Update()
        {
            Int.text = adventurerStats.StatsDictionary[TargetTags.AdvIntelligence].Value.ToString();
            Str.text = adventurerStats.StatsDictionary[TargetTags.AdvStrength].Value.ToString();
            Dex.text = adventurerStats.StatsDictionary[TargetTags.AdvDexterity].Value.ToString();
        }
    }
}
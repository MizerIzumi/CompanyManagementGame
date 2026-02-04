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
        public TextMeshProUGUI CharName;
        public TextMeshProUGUI Int;
        public TextMeshProUGUI Str;
        public TextMeshProUGUI Dex;
        public TextMeshProUGUI PATT;
        public TextMeshProUGUI MATT;
        public TextMeshProUGUI PDeff;
        public TextMeshProUGUI MDeff;
        public TextMeshProUGUI InvSze;
        public TextMeshProUGUI LVL;
        public TextMeshProUGUI HP;
        public TextMeshProUGUI MP;
        public TextMeshProUGUI Helmet;
        public TextMeshProUGUI ChestP;
        public TextMeshProUGUI Boots;
        public TextMeshProUGUI Accessory;
        public TextMeshProUGUI Weapon;
        public TextMeshProUGUI Race;
        public TextMeshProUGUI SubRace;
        public TextMeshProUGUI Faith;

        [SerializeField]
        private AdventurerStatsInitializer adinit;

        private void Start()
        {
            adventurerStats.InitializeAdvStats(adinit);
            Faith.text = "Not fixed yet";
        }

        public void TestingEquipSet()
        {
            characterEquipmentSlots.EquipSet(equipmentSet.equipmentSet);
        }

        public void TestingUnequipAll()
        {
            characterEquipmentSlots.UnequipAll();
        }

        void Update()
        {
            /*
            Int.text = adventurerStats.StatsDictionary[TargetTags.AdvIntelligence].Value.ToString();
            Str.text = adventurerStats.StatsDictionary[TargetTags.AdvStrength].Value.ToString();
            Dex.text = adventurerStats.StatsDictionary[TargetTags.AdvDexterity].Value.ToString();
            PATT.text = adventurerStats.StatsDictionary[TargetTags.AdvPhysicalAttack].Value.ToString();
            MATT.text = adventurerStats.StatsDictionary[TargetTags.AdvMagicalAttack].Value.ToString();
            PDeff.text = adventurerStats.StatsDictionary[TargetTags.AdvPhysicalDefence].Value.ToString();
            MDeff.text = adventurerStats.StatsDictionary[TargetTags.AdvMagicalDefence].Value.ToString();
            InvSze.text = adventurerStats.StatsDictionary[TargetTags.AdvInvSize].Value.ToString();
            LVL.text = adventurerStats.StatsDictionary[TargetTags.AdvLevel].Value.ToString();
            HP.text = adventurerStats.StatsDictionary[TargetTags.AdvHealth].Value.ToString();
            MP.text = adventurerStats.StatsDictionary[TargetTags.AdvMana].Value.ToString();
            Race.text = adventurerStats.Race.RaceName;
            SubRace.text = adventurerStats.SubRace.SubRaceName;
            
            CharName.text = adventurerStats.GetName();
            if (characterEquipmentSlots.Helmet) Helmet.text = characterEquipmentSlots.Helmet.ItemName;
            else Helmet.text = "N/A";
            if (characterEquipmentSlots.ChestPiece) ChestP.text = characterEquipmentSlots.ChestPiece.ItemName;
            else ChestP.text = "N/A";
            if (characterEquipmentSlots.Boots) Boots.text = characterEquipmentSlots.Boots.ItemName;
            else Boots.text = "N/A";
            if (characterEquipmentSlots.Accessory) Accessory.text = characterEquipmentSlots.Accessory.ItemName;
            else Accessory.text = "N/A";
            if (characterEquipmentSlots.Weapon) Weapon.text = characterEquipmentSlots.Weapon.ItemName;
            else Weapon.text = "N/A";
            */
        }
    }
}
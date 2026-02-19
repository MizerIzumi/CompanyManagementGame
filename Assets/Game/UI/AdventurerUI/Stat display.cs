using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Game
{
    public class Statdisplay : MonoBehaviour
    {
        public AdventurerStats adventurerStats;
        public CharacterEquipmentSlots characterEquipmentSlots;
        
        [Header("Character Details")]
        public Image characterImage;
        public TextMeshProUGUI Race;
        public TextMeshProUGUI SubRace;
        public TextMeshProUGUI Profession;
        public TextMeshProUGUI Faith;
        
        [Header("Character Stats")]
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
        
        
        [Header("Character Equipment")]
        public TextMeshProUGUI Helmet;
        public TextMeshProUGUI ChestP;
        public TextMeshProUGUI Boots;
        public TextMeshProUGUI Accessory;
        public TextMeshProUGUI Weapon;

        public void TestingUnequipAll()
        {
            characterEquipmentSlots.UnequipAll();
        }

        void Update()
        {
            if (adventurerStats)
            {
                characterImage.sprite = adventurerStats.race.Portrait;
                Int.text = adventurerStats.StatsDictionary[TargetTags.AdvIntelligence].GetRoundDownValue().ToString();
                Str.text = adventurerStats.StatsDictionary[TargetTags.AdvStrength].GetRoundDownValue().ToString();
                Dex.text = adventurerStats.StatsDictionary[TargetTags.AdvDexterity].GetRoundDownValue().ToString();
                PATT.text = adventurerStats.StatsDictionary[TargetTags.AdvPhysicalAttack].GetRoundDownValue().ToString();
                MATT.text = adventurerStats.StatsDictionary[TargetTags.AdvMagicalAttack].GetRoundDownValue().ToString();
                PDeff.text = adventurerStats.StatsDictionary[TargetTags.AdvPhysicalDefence].GetRoundDownValue().ToString();
                MDeff.text = adventurerStats.StatsDictionary[TargetTags.AdvMagicalDefence].GetRoundDownValue().ToString();
                InvSze.text = adventurerStats.StatsDictionary[TargetTags.AdvInvSize].GetRoundDownValue().ToString();
                LVL.text = adventurerStats.StatsDictionary[TargetTags.AdvLevel].GetRoundDownValue().ToString();
                HP.text = adventurerStats.StatsDictionary[TargetTags.AdvHealth].GetRoundDownValue().ToString();
                MP.text = adventurerStats.StatsDictionary[TargetTags.AdvMana].GetRoundDownValue().ToString();
                Race.text = adventurerStats.race.RaceName;
                SubRace.text = adventurerStats.subRace.SubRaceName;
                CharName.text = adventurerStats.GetName();
                Profession.text = adventurerStats.profession.ProfessionName;
            }
            
            if (characterEquipmentSlots)
            {
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
            }
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game
{
    public class AdventurerStats : StatHandler
    {
        [Header("Adventurer Details")]
        public SO_RaceBase race;
        public SO_SubRaceBase subRace;
        public ConditionalTags alignment;
        public ConditionalTags faith = ConditionalTags.NoFaith;
        
        //private int _minStatLvl = 0;
        //private int _maxStatLvl = 999;
        
        public CharacterInventorySlots inventorySlots;
        public SO_AdventurerProfessionBase profession;
        
        public int missionsCleared = 0;
        
        //TODO: When rerouting through Adventurer Core is setup, move this bool to there.
        public bool isOccupied = false;
        
        private bool _initialized = false;
        [SerializeField]
        private float _expMultiplier = 1;
        
        //TODO: Health and mana need revision, adventurers can start with 0 or less health and the bar attached to health is not being used
        public void InitializeAdvStats(AdventurerStatsInitializer advStatsInit)
        {
            if (_initialized)
            {
                Debug.LogError("ERROR - " + _name + " AdventurerStats has already been initialized");
                return;
            }
            
            _name = advStatsInit.name;
            alignment = advStatsInit.alignment;
            race = advStatsInit.race;
            subRace = advStatsInit.subRace;
            faith = advStatsInit.faith;
            _expMultiplier = advStatsInit.expMultiplier;
            
            inventorySlots = new CharacterInventorySlots((int)advStatsInit.initialInv.initialValue);
            
            profession = advStatsInit.profession;
            
            Statistic AdvLevel = new Statistic(advStatsInit.initialLvl);
            ProgressBar AdvLevelBar = new ProgressBar(true, false, 1, (float)GlobalFunctions.Functions.CalculateExpToNextLevel(1), 0);
            AddStatWithBar(AdvLevel, TargetTags.AdvLevel, AdvLevelBar);
            
            Statistic AdvHealth = new Statistic(advStatsInit.initialHp);
            AddStat(AdvHealth, TargetTags.AdvHealth);
            
            Statistic AdvMana = new Statistic(advStatsInit.initialMp);
            AddStat(AdvMana, TargetTags.AdvMana);
            
            Statistic AdvStrength = new Statistic(advStatsInit.initialStr);
            AddStat(AdvStrength, TargetTags.AdvStrength);
            
            Statistic AdvDexterity = new Statistic(advStatsInit.initialDex);
            AddStat(AdvDexterity, TargetTags.AdvDexterity);
            
            Statistic AdvIntelligence = new Statistic(advStatsInit.initialInt);
            AddStat(AdvIntelligence, TargetTags.AdvIntelligence);
            
            Statistic AdvPAttack = new Statistic(advStatsInit.initialPDamage);
            AddStat(AdvPAttack, TargetTags.AdvPhysicalAttack);
            
            Statistic AdvMAttack = new Statistic(advStatsInit.initialMDamage);
            AddStat(AdvMAttack, TargetTags.AdvMagicalAttack);
            
            Statistic AdvPDefence = new Statistic(advStatsInit.initialPDefence);
            AddStat(AdvPDefence, TargetTags.AdvPhysicalDefence);
            
            Statistic AdvMDefence = new Statistic(advStatsInit.initialMDefence);
            AddStat(AdvMDefence, TargetTags.AdvMagicalDefence);
            
            Statistic AdvInventory = new Statistic(advStatsInit.initialInv);
            AddStat(AdvInventory, TargetTags.AdvInvSize);

            AdvLevelBar.onBarReset += LevelUp;
            
            _initialized = true;
        }

        private void LevelUp()
        {
            foreach (var stat in StatsDictionary)
            {
                if (stat.Value == StatsDictionary[TargetTags.AdvInvSize] ||
                    stat.Value == StatsDictionary[TargetTags.AdvLevel])
                {
                    continue;
                }
                stat.Value.IncrementStat();
                //print(stat.Key + ": " + StatsDictionary[stat.Key].Value);
            }
            GetStatBar(TargetTags.AdvLevel).BarMax = GlobalFunctions.Functions.CalculateExpToNextLevel((int)StatsDictionary[TargetTags.AdvLevel].Value);
            print(_name + " Leveled Up!");
        }

        public void GiveExp(float expAmount)
        {
            ProgressBar statbar = GetStatBar(TargetTags.AdvLevel);
            statbar.IncreaseBar(expAmount * _expMultiplier);
        }
    }
    
    [Serializable]
    public struct AdventurerStatsInitializer
    {
        [Header("Advanced Characteristics")]
        public string name;
        public ConditionalTags alignment;
        public SO_RaceBase race;
        public SO_SubRaceBase subRace;
        public ConditionalTags faith;
        public SO_AdventurerProfessionBase profession;

        [Header("Adventurer Stats")]
        public StatInitializer initialLvl;
        public float expMultiplier;
        public StatInitializer initialHp;
        public StatInitializer initialMp;
        public StatInitializer initialStr;
        public StatInitializer initialDex;
        public StatInitializer initialInt;
        public StatInitializer initialPDamage;
        public StatInitializer initialMDamage;
        public StatInitializer initialPDefence;
        public StatInitializer initialMDefence;
        public StatInitializer initialInv;
    }
}
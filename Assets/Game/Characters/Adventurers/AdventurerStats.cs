using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game
{
    public class AdventurerStats : StatHandler
    {
        public ConditionalTags Alignment;
        public SO_RaceBase Race;
        public SO_SubRaceBase SubRace;
        public ConditionalTags Faith = ConditionalTags.NoFaith;
        
        private int _minStatLvl = 0;
        private int _maxStatLvl = 999;
        
        public CharacterInventorySlots InventorySlots;
        public SO_AdventurerProfessionBase Profession;
        
        private bool _initialized = false;
        
        public void InitializeAdvStats(AdventurerStatsInitializer advStatsInit)
        {
            if (_initialized)
            {
                Debug.LogError("ERROR - " + name + " AdventurerStats has already been initialized");
                return;
            }
            
            _name = advStatsInit.name;
            Alignment = advStatsInit.alignment;
            Race = advStatsInit.race;
            SubRace = advStatsInit.subRace;
            Faith = advStatsInit.faith;
            
            InventorySlots = new CharacterInventorySlots((int)advStatsInit.InitialInv.initialValue);
            
            Profession = advStatsInit.profession;
            
            Statistic AdvLevel = new Statistic(advStatsInit.InitialLvl);
            ProgressBar AdvLevelBar = new ProgressBar(true, false, 1, 100, 0);
            AddStatWithBar(AdvLevel, TargetTags.AdvLevel, AdvLevelBar);
            
            Statistic AdvHealth = new Statistic(advStatsInit.InitialHp);
            AddStat(AdvHealth, TargetTags.AdvHealth);
            
            Statistic AdvMana = new Statistic(advStatsInit.InitialMp);
            AddStat(AdvMana, TargetTags.AdvMana);
            
            Statistic AdvStrength = new Statistic(advStatsInit.InitialStr);
            AddStat(AdvStrength, TargetTags.AdvStrength);
            
            Statistic AdvDexterity = new Statistic(advStatsInit.InitialDex);
            AddStat(AdvDexterity, TargetTags.AdvDexterity);
            
            Statistic AdvIntelligence = new Statistic(advStatsInit.InitialInt);
            AddStat(AdvIntelligence, TargetTags.AdvIntelligence);
            
            Statistic AdvPAttack = new Statistic(advStatsInit.InitialPDamage);
            AddStat(AdvPAttack, TargetTags.AdvPhysicalAttack);
            
            Statistic AdvMAttack = new Statistic(advStatsInit.InitialMDamage);
            AddStat(AdvMAttack, TargetTags.AdvMagicalAttack);
            
            Statistic AdvPDefence = new Statistic(advStatsInit.InitialPDefence);
            AddStat(AdvPDefence, TargetTags.AdvPhysicalDefence);
            
            Statistic AdvMDefence = new Statistic(advStatsInit.InitialMDefence);
            AddStat(AdvMDefence, TargetTags.AdvMagicalDefence);
            
            Statistic AdvInventory = new Statistic(advStatsInit.InitialInv);
            AddStat(AdvInventory, TargetTags.AdvInvSize);
            
            _initialized = true;
        }
    }
    
    [Serializable]
    public struct AdventurerStatsInitializer
    {
        public string name;
        public ConditionalTags alignment;
        public SO_RaceBase race;
        public SO_SubRaceBase subRace;
        public ConditionalTags faith;
        public SO_AdventurerProfessionBase profession;

        public StatInitializer InitialLvl;
        public StatInitializer InitialHp;
        public StatInitializer InitialMp;
        public StatInitializer InitialStr;
        public StatInitializer InitialDex;
        public StatInitializer InitialInt;
        public StatInitializer InitialPDamage;
        public StatInitializer InitialMDamage;
        public StatInitializer InitialPDefence;
        public StatInitializer InitialMDefence;
        public StatInitializer InitialInv;
    }
}
/*
 *         public AdventurerStatsInitializer(string advname, , StatInitializer lvl, StatInitializer hp, StatInitializer mp, 
            StatInitializer str, StatInitializer dex, StatInitializer intel, StatInitializer pdmg,
            StatInitializer mdmg, StatInitializer pdef, StatInitializer mdef, StatInitializer inv)
        {
            
        }
*/
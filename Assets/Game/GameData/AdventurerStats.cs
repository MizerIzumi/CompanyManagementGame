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
            
            InventorySlots = new CharacterInventorySlots(advStatsInit.InitialInv);
            
            Profession = advStatsInit.profession;
            
            Statistic AdvLevel = new Statistic("Level", advStatsInit.InitialLvl, _minStatLvl,  _maxStatLvl);
            ProgressBar AdvLevelBar = new ProgressBar(true, false, 1, 100, 0);
            AddStatWithBar(AdvLevel, TargetTags.AdvLevel, AdvLevelBar);
            
            Statistic AdvHealth = new Statistic("Health", advStatsInit.InitialHp, _minStatLvl,  _maxStatLvl);
            AddStat(AdvHealth, TargetTags.AdvHealth);
            
            Statistic AdvMana = new Statistic("Mana", advStatsInit.InitialMp, _minStatLvl,  _maxStatLvl);
            AddStat(AdvMana, TargetTags.AdvMana);
            
            Statistic AdvStrength = new Statistic("Strength", advStatsInit.InitialStr, _minStatLvl, _maxStatLvl);
            AddStat(AdvStrength, TargetTags.AdvStrength);
            
            Statistic AdvDexterity = new Statistic("Dexterity", advStatsInit.InitialDex, _minStatLvl, _maxStatLvl);
            AddStat(AdvDexterity, TargetTags.AdvDexterity);
            
            Statistic AdvIntelligence = new Statistic("Intelligence", advStatsInit.InitialInt, _minStatLvl, _maxStatLvl);
            AddStat(AdvIntelligence, TargetTags.AdvIntelligence);
            
            Statistic AdvPAttack = new Statistic("Physical Attack", advStatsInit.InitialPDamage, -9999999, 9999999);
            AddStat(AdvPAttack, TargetTags.AdvPhysicalAttack);
            
            Statistic AdvMAttack = new Statistic("Magical Attack", advStatsInit.InitialMDamage, -9999999, 9999999);
            AddStat(AdvMAttack, TargetTags.AdvMagicalAttack);
            
            Statistic AdvPDefence = new Statistic("Physical Defence", advStatsInit.InitialPDefence, -9999999, 9999999);
            AddStat(AdvPDefence, TargetTags.AdvPhysicalDefence);
            
            Statistic AdvMDefence = new Statistic("Magical Defence", advStatsInit.InitialMDefence, -9999999, 9999999);
            AddStat(AdvMDefence, TargetTags.AdvMagicalDefence);
            
            Statistic AdvInventory = new Statistic("Inventory", advStatsInit.InitialInv, _minStatLvl, _maxStatLvl);
            AddStat(AdvInventory, TargetTags.AdvInvSize);
            
            foreach (var VARIABLE in StatsDictionary)
            {
                Debug.Log(VARIABLE.Value.DisplayName + " : " + VARIABLE.Value.BaseValue);
            }
            
            ApplyModifiers(Race.modifiers);
            ApplyModifiers(SubRace.modifiers);
            ApplyModifiers(Profession.modifiers);
            
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
        
        public int InitialLvl;
        public int InitialHp;
        public int InitialMp;
        public int InitialStr;
        public int InitialDex;
        public int InitialInt;
        public int InitialPDamage;
        public int InitialMDamage;
        public int InitialPDefence;
        public int InitialMDefence;
        public int InitialInv;
    }
}
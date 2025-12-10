using System;
using UnityEngine;


namespace Game
{
    public class AdventurerStats : StatHandler
    {
        public ConditionalTags Alignment;
        public ConditionalTags Race;
        public ConditionalTags Sub_Race = ConditionalTags.NoSubRace;
        public ConditionalTags Faith = ConditionalTags.NoFaith;
        
        private int MinStatLvl = 0;
        private int MaxStatLvl = 99;

        public CharacterEquipmentSlots EquipmentSlots = new();
        public CharacterInventorySlots InventorySlots;
        
        
        public void InitializeAdvStats(AdventurerStatsInitializer advStatsInit)
        {
            Alignment = advStatsInit.alignment;
            Race = advStatsInit.race;
            Sub_Race = advStatsInit.subRace;
            Faith = advStatsInit.faith;
            
            InventorySlots = new CharacterInventorySlots(advStatsInit.InitialInv);
            
            Statistic AdvLevel = new Statistic("Level", advStatsInit.InitialLvl, MinStatLvl,  MaxStatLvl);
            ProgressBar AdvLevelBar = new ProgressBar(true, false, 1, 100, 0);
            AddStatWithBar(AdvLevel, TargetTags.AdvLevel, AdvLevelBar);
            
            Statistic AdvHealth = new Statistic("Health", advStatsInit.InitialHp, MinStatLvl,  MaxStatLvl);
            AddStat(AdvHealth, TargetTags.AdvHealth);
            
            Statistic AdvMana = new Statistic("Mana", advStatsInit.InitialMp, MinStatLvl,  MaxStatLvl);
            AddStat(AdvMana, TargetTags.AdvMana);
            
            Statistic AdvStrength = new Statistic("Strength", advStatsInit.InitialStr, MinStatLvl, MaxStatLvl);
            AddStat(AdvStrength, TargetTags.AdvStrength);
            
            Statistic AdvDexterity = new Statistic("Dexterity", advStatsInit.InitialDex, MinStatLvl, MaxStatLvl);
            AddStat(AdvDexterity, TargetTags.AdvDexterity);
            
            Statistic AdvIntelligence = new Statistic("Intelligence", advStatsInit.InitialInt, MinStatLvl, MaxStatLvl);
            AddStat(AdvIntelligence, TargetTags.AdvIntelligence);
            
            Statistic AdvInventory = new Statistic("Inventory", advStatsInit.InitialInv, MinStatLvl, MaxStatLvl);
            AddStat(AdvInventory, TargetTags.AdvInvSize);
            
            foreach (var VARIABLE in StatsDictionary)
            {
                Debug.Log(VARIABLE.Value.DisplayName + " : " + VARIABLE.Value.BaseValue);
            }
        }
    }
    
    [Serializable]
    public struct AdventurerStatsInitializer
    {
        public ConditionalTags alignment;
        public ConditionalTags race;
        public ConditionalTags subRace;
        public ConditionalTags faith;
        
        public int InitialLvl;
        public int InitialHp;
        public int InitialMp;
        public int InitialStr;
        public int InitialDex;
        public int InitialInt;
        public int InitialInv;
    }
}
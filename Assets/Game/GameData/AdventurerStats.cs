using UnityEngine;


namespace Game
{
    public class AdventurerStats : StatHandler
    {
        public ConditionalTags Alignment;
        public ConditionalTags Race;
        public ConditionalTags Sub_Race = ConditionalTags.NoSubRace;
        public ConditionalTags Faith = ConditionalTags.NoFaith;
        
        public int InitialLvl = 1;
        public int InitialHp = 10;
        public int InitialMp = 5;
        public int InitialStr = 1;
        public int InitialDex = 1;
        public int InitialInt = 1;
        public int InitialInv = 1;
        
        public int MinStatLvl = 0;
        public int MaxStatLvl = 99;
        
        public void OnEnable()
        {
            Statistic AdvLevel = new Statistic("Level", InitialLvl, MinStatLvl,  MaxStatLvl);
            ProgressBar AdvLevelBar = new ProgressBar(true, false, 1, 100, 0);
            AddStatWithBar(AdvLevel, TargetTags.AdvLevel, AdvLevelBar);
            
            Statistic AdvHealth = new Statistic("Health", InitialHp, MinStatLvl,  MaxStatLvl);
            AddStat(AdvHealth, TargetTags.AdvHealth);
            
            Statistic AdvMana = new Statistic("Mana", InitialMp, MinStatLvl,  MaxStatLvl);
            AddStat(AdvMana, TargetTags.AdvMana);
            
            Statistic AdvStrength = new Statistic("Strength", InitialStr, MinStatLvl, MaxStatLvl);
            AddStat(AdvStrength, TargetTags.AdvStrength);
            
            Statistic AdvDexterity = new Statistic("Dexterity", InitialDex, MinStatLvl, MaxStatLvl);
            AddStat(AdvDexterity, TargetTags.AdvDexterity);
            
            Statistic AdvIntelligence = new Statistic("Intelligence", InitialInt, MinStatLvl, MaxStatLvl);
            AddStat(AdvIntelligence, TargetTags.AdvIntelligence);
            
            Statistic AdvInventory = new Statistic("Inventory", InitialInv, MinStatLvl, MaxStatLvl);
            AddStat(AdvInventory, TargetTags.AdvInvSize);
        }

        public void Start()
        {
            foreach (var VARIABLE in Stats)
            {
                Debug.Log(VARIABLE.Value.DisplayName);
            }
        }
    }
}
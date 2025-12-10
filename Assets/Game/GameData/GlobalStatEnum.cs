

namespace Game
{
    public enum ModifierType
    {
        Multiplication_Multiplicative = 0,
        Multiplication_Additive = 1,
        Flat = 2,
    }
    
    public enum TargetTags
    {
        //------------------------- Company Stats -------------------------
        CompFunds = 100,
        RepLevel = 101,
        CompInvSize = 102,
        ShopInvSize = 103,
        CompAlignment = 104,
        RecruitCapacity = 105,
        
        //------------------------- Adventurer Stats -------------------------
        AdvLevel = 200,
        AdvHealth = 201,
        AdvMana = 202,
        AdvStrength = 203,
        AdvDexterity = 204,
        AdvIntelligence = 205,
        AdvInvSize = 206,
        
        //------------------------- Affiliations -------------------------
        NoAffiliation = 300,
        //Alignment A
        Affiliation1 = 301,
        Affiliation2 = 302,
        Affiliation3 = 303,
        
        //Neutral
        Affiliation4 = 310,
        Affiliation5 = 311,
        Affiliation6 = 312,
        
        //Alignment B
        Affiliation7 = 320,
        Affiliation8 = 321,
        Affiliation9 = 322,
        
        TestAffiliation = 399
    }

    public enum ConditionalTags
    {
        NoCondition = 0,
        //------------------------- Races -------------------------
        //Alignment A
        Human = 100,
        Celestial = 101,
        Elf = 102,
        
        //Neutral
        Dwarf = 110,
        BeastKin = 111,
        Goblin = 112,
        
        //Alignment B
        PureBlood = 120,
        Dragon = 121,
        
        //------------------------- Sub Races -------------------------
        NoSubRace = 200,
        Vampire = 201,
        Werbeast = 202,
        Fae = 203,
        Draconic = 204,
        Angelic = 205,
        Demonic = 206,
        Golem = 207,
        Undead = 208,
        
        //------------------------- Faiths -------------------------
        NoFaith = 300,
        
        //------------------------- Alignments -------------------------
        AlignmentNeutral = 400,
        AlignmentA = 401,
        AlignmentB = 402,
    }
}
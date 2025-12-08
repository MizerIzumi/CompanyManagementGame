

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
    
    
    /*
    public enum TagsEnum
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
        Health = 201,
        Mana = 202,
        Strength = 203,
        Dexterity = 204,
        Intelligence = 205,
        AdvInvSize = 206,
        AdvAlignment = 207,
        
        //------------------------- Races -------------------------
        //Alignment A
        Human = 300,
        Celestial = 301,
        Elf = 302,
        
        //Neutral
        Dwarf = 310,
        BeastKin = 311,
        Goblin = 312,
        
        //Alignment B
        PureBlood = 320,
        Dragon = 321,
        
        //------------------------- Sub Races -------------------------
        NoSubRace = 400,
        Vampire = 401,
        Werbeast = 402,
        Fae = 403,
        Draconic = 404,
        Angelic = 405,
        Demonic = 406,
        Golem = 407,
        Undead = 408,
        
        //------------------------- Faiths -------------------------
        NoFaith = 500,
        
        //------------------------- Affiliations -------------------------
        NoAffiliation = 600,
        //Alignment A
        Affiliation1 = 601,
        Affiliation2 = 602,
        Affiliation3 = 603,
        
        //Neutral
        Affiliation4 = 610,
        Affiliation5 = 611,
        Affiliation6 = 612,
        
        //Alignment B
        Affiliation7 = 620,
        Affiliation8 = 621,
        Affiliation9 = 622,
        
        TestAffiliation = 699
    }
    */
}
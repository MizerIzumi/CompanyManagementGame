

namespace Game
{
    public enum ModifierType
    {
        Flat,
        Multiplication_Individual,
        Multiplication_Combined,
    }
    
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
}
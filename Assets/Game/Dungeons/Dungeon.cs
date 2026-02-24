using System.Collections.Generic;
using Game;
using UnityEngine;
using GlobalFunctions;
public class Dungeon
{
    public SO_DungeonData dungeonData;
    private int _timeElapsed = 0;
    public bool isDone = false;
    public List<AdventurerStats> party = new();
    
    private List<Encounter> commonEncounters = new();
    private List<Encounter> uncommonEncounters = new();
    private List<Encounter> rareEncounters = new();
    private List<Encounter> epicEncounters = new();
    private List<Encounter> legendaryEncounters = new();
    
    public Encounter activeEncounter;
    
    public void StartDungeon()
    {
        Debug.Log("Initializing Dungeon: " + dungeonData.dungeonName);
        InnitializeEncounters();
    }
    
    private void InnitializeEncounters()
    {
        foreach (var encounterData in dungeonData.encounters)
        {
            switch (encounterData.encounterRarity)
            {
                case Rarity.Common:
                    commonEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Uncommon:
                    uncommonEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Rare:
                    rareEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Epic:
                    epicEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Legendary:
                    legendaryEncounters.Add(CreateEncounter(encounterData));
                    break;
            }
        }
    }

    private Encounter CreateEncounter(SO_EncounterData encounterData)
    {
        Encounter newEncounter = new Encounter();
        newEncounter.encounterData = encounterData;
        return newEncounter;
    }
    
    public void AdvanceDungeon(TimeManager.TimeSlot timeSlot)
    {
        if (_timeElapsed == dungeonData.duration)
        {
            //End Dungeon
            isDone =  true;
            return;
        }
        _timeElapsed++;

        if (activeEncounter != null)
        {
            activeEncounter.AutoResolveEncounter();
        }
        EncounterCheck();
    }

    private void EncounterCheck()
    {
        if (Random.Range(0, 100) <= dungeonData.encounterRate)
        {
            activeEncounter = EncounterPicker(Functions.GetRandomRarity());
            Debug.Log("Encountered: " + activeEncounter.encounterData.encounterName); 
            return;
        }
        Debug.Log("No Encounter");
    }

    private Encounter EncounterPicker(Rarity rarity)
    {
        int encounterIndex;
        switch (rarity)
        {
            case Rarity.Common:
                
                encounterIndex = Random.Range(0, commonEncounters.Count);
                return commonEncounters[encounterIndex];
            
            case Rarity.Uncommon:
                if (uncommonEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Common);
                }
                encounterIndex = Random.Range(0, uncommonEncounters.Count);
                return uncommonEncounters[encounterIndex];
            
            case Rarity.Rare:
                if (rareEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Uncommon);
                }
                encounterIndex = Random.Range(0, rareEncounters.Count);
                return rareEncounters[encounterIndex];
            
            case Rarity.Epic:
                if (epicEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Rare);
                }
                encounterIndex = Random.Range(0, epicEncounters.Count);
                return epicEncounters[encounterIndex];
            
            case Rarity.Legendary:
                if (legendaryEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Epic);
                }
                encounterIndex = Random.Range(0, legendaryEncounters.Count);
                return legendaryEncounters[encounterIndex];
        }
        
        return null;
    }
}

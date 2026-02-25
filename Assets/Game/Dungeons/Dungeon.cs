using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using GlobalFunctions;
using Random = UnityEngine.Random;

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

    public bool dungeonStarted = false;
    
    public void StartDungeon()
    {
        Debug.Log("Initializing Dungeon: " + dungeonData.dungeonName);
        InnitializeEncounters();
        dungeonStarted =  true;
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
        newEncounter.dungeonData = dungeonData;
        return newEncounter;
    }
    
    public void AdvanceDungeon(TimeManager.TimeSlot timeSlot)
    {
        if (_timeElapsed == dungeonData.duration)
        {
            //End Dungeon
            isDone =  true;
            foreach (AdventurerStats adventurer in party)
            {
                adventurer.isOccupied = false;
            }
            return;
        }
        _timeElapsed++;

        if (activeEncounter != null)
        {
            activeEncounter.AutoResolveEncounter();
            activeEncounter = null;
        }
        EncounterCheck();
    }

    private void EncounterCheck()
    {
        if (Random.Range(0, 100) <= dungeonData.encounterRate)
        {
            AdventurerStats adventurer = party[Random.Range(0, party.Count)];
            activeEncounter = EncounterPicker(Functions.GetRandomRarity());
            activeEncounter.adventurer = adventurer;
            Debug.Log(adventurer.GetName() + " encountered: " + activeEncounter.encounterData.encounterName);
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

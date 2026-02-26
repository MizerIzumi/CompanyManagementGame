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
    
    private List<Encounter> _commonEncounters = new();
    private List<Encounter> _uncommonEncounters = new();
    private List<Encounter> _rareEncounters = new();
    private List<Encounter> _epicEncounters = new();
    private List<Encounter> legendaryEncounters = new();
    
    public Encounter activeEncounter;

    public bool dungeonStarted = false;
    
    private bool _innitialized = false;
    
    public void StartDungeon()
    {
        if (!_innitialized)
        {
            Debug.Log("Initializing Dungeon: " + dungeonData.dungeonName);
            InnitializeEncounters();
            _innitialized = true;
        }
        dungeonStarted =  true;
    }
    
    private void InnitializeEncounters()
    {
        foreach (var encounterData in dungeonData.encounters)
        {
            switch (encounterData.encounterRarity)
            {
                case Rarity.Common:
                    _commonEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Uncommon:
                    _uncommonEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Rare:
                    _rareEncounters.Add(CreateEncounter(encounterData));
                    break;
                case Rarity.Epic:
                    _epicEncounters.Add(CreateEncounter(encounterData));
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
            activeEncounter = null;
            return;
        }
        _timeElapsed++;

        if (activeEncounter != null)
        {
            if (!activeEncounter.resolved)
            {
                activeEncounter.AutoResolveEncounter();
            }
            activeEncounter.resolved = false;
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
                
                encounterIndex = Random.Range(0, _commonEncounters.Count);
                return _commonEncounters[encounterIndex];
            
            case Rarity.Uncommon:
                if (_uncommonEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Common);
                }
                encounterIndex = Random.Range(0, _uncommonEncounters.Count);
                return _uncommonEncounters[encounterIndex];
            
            case Rarity.Rare:
                if (_rareEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Uncommon);
                }
                encounterIndex = Random.Range(0, _rareEncounters.Count);
                return _rareEncounters[encounterIndex];
            
            case Rarity.Epic:
                if (_epicEncounters.Count == 0)
                {
                    return EncounterPicker(Rarity.Rare);
                }
                encounterIndex = Random.Range(0, _epicEncounters.Count);
                return _epicEncounters[encounterIndex];
            
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

    public void ResetDungeon()
    {
        party.Clear();
        dungeonStarted = false;
        isDone = false;
        _timeElapsed = 0;
    }
}

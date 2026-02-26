using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DungeonManager : MonoBehaviour
    {
        public event Action<Encounter> OnEncounter;
        public event Action<Dungeon> OnDungeonStatusChanged;
        
        private TimeManager  _timeManager;
        public MissionManager missionManager;
        private Dictionary<SO_DungeonData, Dungeon> _dungeons = new();
        public List<Dungeon> dungeonsInProgress = new();
        public AS_DungeonUI asDungeonUI;
        private List<Encounter> _encounterQueue = new();

        private void Start()
        {
            _timeManager = GameManager.Instance.timeManager;
            _timeManager.OnTimeSlotChanged += AdvanceDungeons;
        }

        public void OpenDungeonUI(SO_DungeonData dungeonData)
        {
            if (asDungeonUI._firstTime)
            {
                asDungeonUI.SetDungeonManager(this);
            }
            asDungeonUI.SetDungeon(GetDungeon(dungeonData));
            ActionStack.Main.PushAction(asDungeonUI);
            if (_encounterQueue.Count > 0)
            {
                //TODO: Find a better way than this to handle encounters.
                asDungeonUI.asEncounterUI.SetEncounter(_encounterQueue[0]);
                _encounterQueue.Remove(_encounterQueue[0]);
                ActionStack.Main.PushAction(asDungeonUI.asEncounterUI);
            }
        }
        
        public bool StartDungeon(Dungeon dungeon)
        {
            if (dungeon.party.Count <= 0) return false;
            
            print("Starting dungeon: " + dungeon.dungeonData.dungeonName);
            dungeonsInProgress.Add(dungeon);
            dungeon.StartDungeon();
            
            _timeManager.AdvanceTime();
            OnDungeonStatusChanged?.Invoke(dungeon);
            return true;
        }

        public Dungeon GetDungeon(SO_DungeonData dungeonData)
        {
            if (_dungeons.TryGetValue(dungeonData, out var dungeon))
            {
                //dungeon already exists
                return dungeon;
            }
            
            Dungeon newDungeon = new Dungeon
            {
                dungeonData = dungeonData,
            };
            
            _dungeons.Add(dungeonData, newDungeon);
            
            return newDungeon;
        }
        
        private void AdvanceDungeons(TimeManager.TimeSlot timeSlot)
        {
            if (dungeonsInProgress.Count == 0) return;
            _encounterQueue.Clear();

            for (int i = 0; i < dungeonsInProgress.Count; i++)
            {
                Dungeon dungeon = dungeonsInProgress[i];
                dungeon.AdvanceDungeon(timeSlot);
                if (dungeon.activeEncounter != null)
                {
                    _encounterQueue.Add(dungeon.activeEncounter);
                    OnEncounter?.Invoke(dungeon.activeEncounter);
                }
                if (dungeon.isDone)
                {
                    FinishDungeon(dungeon);
                }
            }
        }

        public void EncounterResolved(Encounter encounter)
        {
            encounter.resolved = true;
            OnEncounter?.Invoke(encounter);
            _encounterQueue.Remove(encounter);
        }

        private void FinishDungeon(Dungeon dungeon)
        {
            foreach (AdventurerStats adventurer in dungeon.party)
            {
                adventurer.isOccupied = false;
            }
            missionManager.MissionComplete(dungeon.party, dungeon.dungeonData.dangerRating);
            dungeon.ResetDungeon();
            dungeonsInProgress.Remove(dungeon);
            OnDungeonStatusChanged?.Invoke(dungeon);
        }

        public bool CanAdventurerJoinParty(Dungeon dungeon, AdventurerStats adventurer)
        {
            if (dungeon == null || adventurer == null)
            {
                Debug.LogError("CanAdventurerJoinParty: dungeon is null or adventurer is null");
                return false;
            }

            if (adventurer.isOccupied) return false;

            return dungeon.party.Count < dungeon.dungeonData.partySize;
        }
        
        public void AddAdventurerToParty(Dungeon dungeon, AdventurerStats adventurer)
        {
            adventurer.isOccupied = true;
            dungeon.party.Add(adventurer);
        }

        public void RemoveAdventurerFromParty(Dungeon dungeon, AdventurerStats adventurer)
        {
            adventurer.isOccupied = false;
            dungeon.party.Remove(adventurer);
        }
    }
}
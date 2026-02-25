using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class DungeonManager : MonoBehaviour
    {
        private TimeManager  _timeManager;
        public MissionManager missionManager;
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
            asDungeonUI.SetDungeon(CreateDungeon(dungeonData));
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
            return true;
        }

        public Dungeon CreateDungeon(SO_DungeonData dungeonData)
        {
            Dungeon newDungeon = new Dungeon
            {
                dungeonData = dungeonData,
            };
            
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
                }
                if (dungeon.isDone)
                {
                    missionManager.MissionComplete(dungeon.party, dungeon.dungeonData.dangerRating);
                    dungeonsInProgress.Remove(dungeon);
                }
            }
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
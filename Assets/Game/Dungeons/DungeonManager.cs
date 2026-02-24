using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private TimeManager  _timeManager;
    public MissionManager missionManager;
    public List<Dungeon> dungeonsInProgress = new();

    private void Start()
    {
        _timeManager = GameManager.Instance.timeManager;

        _timeManager.OnTimeSlotChanged += AdvanceDungeons;
    }

    public void StartDungeon(SO_DungeonData dungeonData, List<AdventurerStats> party)
    {
        print("Starting dungeon");
        Dungeon newDungeon = new Dungeon();
        newDungeon.dungeonData = dungeonData;
        newDungeon.party = party;
        dungeonsInProgress.Add(newDungeon);
        newDungeon.StartDungeon();
    }
    
    private void AdvanceDungeons(TimeManager.TimeSlot timeSlot)
    {
        if (dungeonsInProgress.Count == 0) return;

        for (int i = 0; i < dungeonsInProgress.Count -1; i++)
        {
            Dungeon dungeon = dungeonsInProgress[i];
            dungeon.AdvanceDungeon(timeSlot);
            if (dungeon.isDone)
            {
                missionManager.MissionComplete(dungeon.party, dungeon.dungeonData.dangerRating);
                dungeonsInProgress.Remove(dungeon);
            }
        }
    }
}

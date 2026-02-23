using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private TimeManager  _timeManager;
    public List<Dungeon> dungeonsInProgress = new();

    private void Start()
    {
        _timeManager = GameManager.Instance.timeManager;

        _timeManager.OnTimeSlotChanged += AdvanceDungeons;
    }

    public void StartDungeon(SO_DungeonDataBase dungeonData)
    {
        Dungeon newDungeon = new Dungeon();
        newDungeon.dungeonData = dungeonData;
        dungeonsInProgress.Add(newDungeon);
        newDungeon.StartDungeon();
    }
    
    private void AdvanceDungeons(TimeManager.TimeSlot timeSlot)
    {
        if (dungeonsInProgress.Count == 0) return;
        
        print("AdvanceDungeons");
        
        foreach (Dungeon dungeon in dungeonsInProgress)
        {
            dungeon.AdvanceDungeon(timeSlot);
            if (dungeon.isDone)
            {
                
            }
        }
    }
}

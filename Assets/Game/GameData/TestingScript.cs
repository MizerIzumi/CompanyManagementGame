using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TestingScript : MonoBehaviour
    {
        public MissionManager missionmanager;
        public AdventurerStats adventurerstats;
        public int fakeMissionRank = 1;

        public ShopAndCompInv cnsinv;
        public SO_ItemBase goldNugget;
        
        public DungeonManager dungeonmanager;
        public SO_DungeonData dungeonData;
        public List<AdventurerStats> party = new();

        public float FakeDifficultyOdds;
        public int FakeStat;
        
        public void CompleteFakeMission()
        {
            List<AdventurerStats> _party = new() {adventurerstats};
            missionmanager.MissionComplete(party, fakeMissionRank);
        }
        
        public void PrintGrowth()
        {
            foreach (var stat in adventurerstats.StatsDictionary)
            {
                print( stat.Value.DisplayName + " : " + stat.Value.StatGrowthMultiplier);
            }
        }

        public void PrintStatModifiers()
        {
            foreach (var stat in adventurerstats.StatsDictionary)
            {
                print(stat.Value.DisplayName + " : ");
                foreach (var mod in stat.Value.GetModifiers())
                {
                    print(mod.Type + " : " + mod.Value);
                }
            }
        }

        public void AddGoldNuggetToCompInv()
        {
            cnsinv.AddItemToCompInv(goldNugget);
        }

        public void PrintRNGRarity()
        {
            print("Rarity: " + GlobalFunctions.Functions.GetRandomRarity());
        }

        public void StartTestDungeon()
        {
            //dungeonmanager.StartDungeon(dungeon);
        }

        public void PrintOdds()
        {
            float x = FakeStat / FakeDifficultyOdds;
            Double result = (x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2) * 100;
            print((int)result + "%");
        }
    }
}
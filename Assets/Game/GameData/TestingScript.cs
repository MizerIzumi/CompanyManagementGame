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
        
        public void CompleteFakeMission()
        {
            missionmanager.GiveAdvanturerExp(adventurerstats, fakeMissionRank);
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
    }
}
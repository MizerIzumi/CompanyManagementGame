using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Encounter
    {
        public SO_EncounterData encounterData;
        public SO_DungeonData dungeonData;
        public AdventurerStats adventurer;
        
        public bool ChooseOption(SO_EncounterData.EncounterOption  option)
        {
            
            int RNG = UnityEngine.Random.Range(0, 100);
            Debug.Log("Success Chance: " + SuccessChance(option) + "%");
            Debug.Log("Rolled Number: " + RNG);
            if (RNG <= SuccessChance(option))
            {
                //Success!
                Debug.Log("Encounter successful");
                if (!option.hasReward) return true;
                foreach (SO_ItemBase reward in option.rewards)
                {
                    //TODO: Change this when adventurer inventories are finished.
                    GameManager.Instance.compAndShopInv.AddItemToCompInv(reward);
                }
                //TODO: Add a popup that shows the rewards you got.
                return true;
            }
            //Failure...
            Debug.Log("Encounter failed");
            //TODO: Fix penalties for failing, for now it will be nothing.
            
            return false;
        }
        
        public bool AutoResolveEncounter()
        {
            List<SO_EncounterData.EncounterOption> options = new()
            {
                encounterData.OptionA,
                encounterData.OptionB,
                encounterData.OptionC,
                encounterData.OptionD
            };
            
            return ChooseOption(options[UnityEngine.Random.Range(0, options.Count)]);
        }
        
        //This returns a number between 0-100 indicating the % chance of success
        public int SuccessChance(SO_EncounterData.EncounterOption  option)
        {
            float guaranteedSuccess = ((((int)option.difficulty / 100f) * dungeonData.dangerRating) + 5) * 2;
            
            float x = adventurer.StatsDictionary[option.stat].Value / guaranteedSuccess;
            //EaseInOutQuad
            double result = (x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2) * 100;
            if (result >= guaranteedSuccess)
            {
                return 100;
            }
            return (int)result;
        }
    }
}


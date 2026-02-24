

using System;
using System.Collections.Generic;

namespace Game
{
    public class Encounter
    {
        public SO_EncounterData encounterData;
        public SO_DungeonData dungeonData;
        public AdventurerStats adventurer;

        public bool ChooseOption(SO_EncounterData.EncounterOption  option)
        {
            if (UnityEngine.Random.Range(0, 100) <= SuccessChance(option))
            {
                //Success!
                return true;
            }
            //Failure...
            return false;
        }
        
        
        //TODO: fix the auto resolve encounter as well as the choose option, it needs to result in something, currently it dose pretty much nothing
        public void AutoResolveEncounter()
        {
            List<SO_EncounterData.EncounterOption> options = new()
            {
                encounterData.OptionA,
                encounterData.OptionB,
                encounterData.OptionC,
                encounterData.OptionD,
            };
            if (ChooseOption(options[UnityEngine.Random.Range(0, options.Count)]))
            {
                //Success
            }
            //failed
        }
        
        //This returns a number between 0-100 indicating the % chance of success
        public int SuccessChance(SO_EncounterData.EncounterOption  option)
        {
            float guaranteedSuccess = ((((int)option.difficulty / 100f) * dungeonData.dangerRating) + 2) * 2;
            
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


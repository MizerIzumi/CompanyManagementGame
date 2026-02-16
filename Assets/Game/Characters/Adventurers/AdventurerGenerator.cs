using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game
{
    public class AdventurerGenerator : MonoBehaviour
    {
        public List<SO_RaceBase> AvailableRaces = new();
        public List<SO_SubRaceBase> AvailableSubRaces = new();
        public List<SO_AdventurerProfessionBase> AvailableProfessions = new();
        public int _SubracePercentChance = 25;
        [FormerlySerializedAs("_noSubRace")] [SerializeField]
        private SO_SubRaceBase _noSubrace;
        [SerializeField]
        private GameObject AdventurerPrefab;
        [SerializeField]
        private ListOfNames AdventurerNames;

        private int statmin = -9999;
        private int statmax = 9999;
        
        public GameObject GenerateAdventurer()
        {
            SO_RaceBase newRace;
            SO_SubRaceBase newSubRace;
            SO_AdventurerProfessionBase newProfession;
            GameObject newAdventurer;
            
            newRace = PickRace();
            newSubRace = PickSubRace();
            newProfession = PickProfession();
            
            AdventurerStatsInitializer advinit  = new AdventurerStatsInitializer();
            
            advinit.name = AdventurerNames.Names[Random.Range(0, AdventurerNames.Names.Count)];
            advinit.alignment = (ConditionalTags)Random.Range(400, 402);
            //When I get around to adding faiths remember to fix this here <---------------------------------------------------x To Do
            advinit.faith = ConditionalTags.NoFaith;
            
            advinit.race = newRace;
            advinit.subRace = newSubRace;
            advinit.profession = newProfession;
            
            advinit.expMultiplier = newRace.expMultiplier + newSubRace.expMultiplier;
            
            //This is garbage but in favor of time I am setting it up like this for now.
            advinit.initialLvl = AddUpStats(newRace.StartingStats[0], newSubRace.StartingStats[0], newProfession.StartingStats[0]);
            advinit.initialHp = AddUpStats(newRace.StartingStats[1], newSubRace.StartingStats[1], newProfession.StartingStats[1]);
            advinit.initialMp = AddUpStats(newRace.StartingStats[2], newSubRace.StartingStats[2], newProfession.StartingStats[2]);
            advinit.initialStr = AddUpStats(newRace.StartingStats[3], newSubRace.StartingStats[3], newProfession.StartingStats[3]);
            advinit.initialDex = AddUpStats(newRace.StartingStats[4], newSubRace.StartingStats[4], newProfession.StartingStats[4]);
            advinit.initialInt = AddUpStats(newRace.StartingStats[5], newSubRace.StartingStats[5], newProfession.StartingStats[5]);
            advinit.initialPDamage = AddUpStats(newRace.StartingStats[6], newSubRace.StartingStats[6], newProfession.StartingStats[6]);
            advinit.initialMDamage = AddUpStats(newRace.StartingStats[7], newSubRace.StartingStats[7], newProfession.StartingStats[7]);
            advinit.initialPDefence = AddUpStats(newRace.StartingStats[8], newSubRace.StartingStats[8], newProfession.StartingStats[8]);
            advinit.initialMDefence = AddUpStats(newRace.StartingStats[9], newSubRace.StartingStats[9], newProfession.StartingStats[9]);
            advinit.initialInv = AddUpStats(newRace.StartingStats[10], newSubRace.StartingStats[10], newProfession.StartingStats[10]);
            
            newAdventurer = Instantiate(AdventurerPrefab);
            newAdventurer.GetComponent<AdventurerStats>().InitializeAdvStats(advinit);
            
            newAdventurer.GetComponent<CharacterEquipmentSlots>().EquipSet(advinit.profession.startingEquipment.equipmentSet);
            
            return newAdventurer;
        }

        private StatInitializer AddUpStats(StatInitializer racestat, StatInitializer subracestat, StatInitializer professionstat)
        {
            StatInitializer newstat = new StatInitializer();
            
            newstat.initialValue = racestat.initialValue + subracestat.initialValue + professionstat.initialValue;
            if (racestat.statgrowthmultiplier + subracestat.statgrowthmultiplier + professionstat.statgrowthmultiplier <= 0)
            {
                newstat.statgrowthmultiplier = 0.01f;
            }
            else
            {
                newstat.statgrowthmultiplier = racestat.statgrowthmultiplier + subracestat.statgrowthmultiplier + professionstat.statgrowthmultiplier;
            }
            newstat.statmin = statmin;
            newstat.statmax = statmax;
            newstat.statname = racestat.statname;
            return newstat;
        }

        private SO_RaceBase PickRace()
        {
            SO_RaceBase race = new SO_RaceBase();
            if (AvailableRaces.Count < 0)
            {
                Debug.LogError("No Races Available");
                return null;
            }
            
            race = AvailableRaces[RNGMachine(0, AvailableRaces.Count)];
            
            return race;
        }

        private SO_SubRaceBase PickSubRace()
        {
            SO_SubRaceBase subrace = new SO_SubRaceBase();
            if (AvailableSubRaces.Count < 0)
            {
                Debug.LogError("No Sub Races Available");
                subrace = _noSubrace;
                return null;
            }

            if (RNGMachine(0, 100) > _SubracePercentChance)
            {
                subrace = _noSubrace;
            }
            else
            {
                subrace = AvailableSubRaces[RNGMachine(0, AvailableSubRaces.Count)];
            }
            
            return subrace;
        }

        private SO_AdventurerProfessionBase PickProfession()
        {
            SO_AdventurerProfessionBase profession  = new SO_AdventurerProfessionBase();
            if (AvailableProfessions.Count < 0)
            {
                Debug.LogError("No Professions Available");
                return null;
            }
            
            profession = AvailableProfessions[RNGMachine(0, AvailableProfessions.Count)];
            
            return profession;
        }

        private int RNGMachine(int min, int max)
        {
            return Random.Range(minInclusive: min, maxExclusive: max);
        }
    }
}


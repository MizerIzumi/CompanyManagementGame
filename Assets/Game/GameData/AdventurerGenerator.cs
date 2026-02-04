using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class AdventurerGenerator : MonoBehaviour
    {
        public List<SO_RaceBase> AvailableRaces = new();
        public List<SO_SubRaceBase> AvailableSubRaces = new();
        public List<SO_AdventurerProfessionBase> AvailableProfessions = new();
        [SerializeField]
        private GameObject AdventurerPrefab;
        [SerializeField]
        private ListOfNames AdventurerNames;

        private int statmin = -9999;
        private int statmax = 9999;

        public List<GameObject> Adventurers = new List<GameObject>();

        public void TestMakeNewAdventurer()
        {
            Adventurers.Add(GenerateAdventurer());
        }

        public GameObject GenerateAdventurer()
        {
            SO_RaceBase tRace;
            SO_SubRaceBase tSubRace;
            SO_AdventurerProfessionBase tProfession;
            GameObject tAdventurer;
            
            tRace = PickRace();
            tSubRace = PickSubRace();
            tProfession = PickProfession();
            
            AdventurerStatsInitializer tadvinit  = new AdventurerStatsInitializer();
            
            tadvinit.name = AdventurerNames.Names[Random.Range(0, AdventurerNames.Names.Count)];
            tadvinit.alignment = (ConditionalTags)Random.Range(400, 402);
            //When I get around to adding faiths remember to fis this here <---------------------------------------------------x To Do
            tadvinit.faith = ConditionalTags.NoFaith;
            
            tadvinit.race = tRace;
            tadvinit.subRace = tSubRace;
            tadvinit.profession = tProfession;
            
            //This is garbage but in favor of time I am setting it up like this for now.
            tadvinit.InitialLvl = AddUpStats(tRace.StartingStats[0], tSubRace.StartingStats[0], tProfession.StartingStats[0]);
            tadvinit.InitialHp = AddUpStats(tRace.StartingStats[1], tSubRace.StartingStats[1], tProfession.StartingStats[1]);
            tadvinit.InitialMp = AddUpStats(tRace.StartingStats[2], tSubRace.StartingStats[2], tProfession.StartingStats[2]);
            tadvinit.InitialStr = AddUpStats(tRace.StartingStats[3], tSubRace.StartingStats[3], tProfession.StartingStats[3]);
            tadvinit.InitialDex = AddUpStats(tRace.StartingStats[4], tSubRace.StartingStats[4], tProfession.StartingStats[4]);
            tadvinit.InitialInt = AddUpStats(tRace.StartingStats[5], tSubRace.StartingStats[5], tProfession.StartingStats[5]);
            tadvinit.InitialPDamage = AddUpStats(tRace.StartingStats[6], tSubRace.StartingStats[6], tProfession.StartingStats[6]);
            tadvinit.InitialMDamage = AddUpStats(tRace.StartingStats[7], tSubRace.StartingStats[7], tProfession.StartingStats[7]);
            tadvinit.InitialPDefence = AddUpStats(tRace.StartingStats[8], tSubRace.StartingStats[8], tProfession.StartingStats[8]);
            tadvinit.InitialMDefence = AddUpStats(tRace.StartingStats[9], tSubRace.StartingStats[9], tProfession.StartingStats[9]);
            tadvinit.InitialInv = AddUpStats(tRace.StartingStats[10], tSubRace.StartingStats[10], tProfession.StartingStats[10]);
            
            tAdventurer = Instantiate(AdventurerPrefab);
            tAdventurer.GetComponent<AdventurerStats>().InitializeAdvStats(tadvinit);
            
            tAdventurer.GetComponent<CharacterEquipmentSlots>().EquipSet(tadvinit.profession.startingEquipment.equipmentSet);
            
            return tAdventurer;
        }

        private StatInitializer AddUpStats(StatInitializer racestat, StatInitializer subracestat, StatInitializer professionstat)
        {
            StatInitializer newstat = new StatInitializer();
            
            newstat.initialValue = racestat.initialValue + subracestat.initialValue + professionstat.initialValue;
            newstat.statgrowthmultiplier = racestat.statgrowthmultiplier + subracestat.statgrowthmultiplier + professionstat.statgrowthmultiplier;
            newstat.statmin = statmin;
            newstat.statmax = statmax;
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
                return null;
            }
            
            subrace = AvailableSubRaces[RNGMachine(0, AvailableSubRaces.Count)];
            
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


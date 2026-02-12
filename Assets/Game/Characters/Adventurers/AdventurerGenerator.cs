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
            //When I get around to adding faiths remember to fix this here <---------------------------------------------------x To Do
            tadvinit.faith = ConditionalTags.NoFaith;
            
            tadvinit.race = tRace;
            tadvinit.subRace = tSubRace;
            tadvinit.profession = tProfession;
            
            tadvinit.expMultiplier = tRace.expMultiplier + tSubRace.expMultiplier;
            
            //This is garbage but in favor of time I am setting it up like this for now.
            tadvinit.initialLvl = AddUpStats(tRace.StartingStats[0], tSubRace.StartingStats[0], tProfession.StartingStats[0]);
            tadvinit.initialHp = AddUpStats(tRace.StartingStats[1], tSubRace.StartingStats[1], tProfession.StartingStats[1]);
            tadvinit.initialMp = AddUpStats(tRace.StartingStats[2], tSubRace.StartingStats[2], tProfession.StartingStats[2]);
            tadvinit.initialStr = AddUpStats(tRace.StartingStats[3], tSubRace.StartingStats[3], tProfession.StartingStats[3]);
            tadvinit.initialDex = AddUpStats(tRace.StartingStats[4], tSubRace.StartingStats[4], tProfession.StartingStats[4]);
            tadvinit.initialInt = AddUpStats(tRace.StartingStats[5], tSubRace.StartingStats[5], tProfession.StartingStats[5]);
            tadvinit.initialPDamage = AddUpStats(tRace.StartingStats[6], tSubRace.StartingStats[6], tProfession.StartingStats[6]);
            tadvinit.initialMDamage = AddUpStats(tRace.StartingStats[7], tSubRace.StartingStats[7], tProfession.StartingStats[7]);
            tadvinit.initialPDefence = AddUpStats(tRace.StartingStats[8], tSubRace.StartingStats[8], tProfession.StartingStats[8]);
            tadvinit.initialMDefence = AddUpStats(tRace.StartingStats[9], tSubRace.StartingStats[9], tProfession.StartingStats[9]);
            tadvinit.initialInv = AddUpStats(tRace.StartingStats[10], tSubRace.StartingStats[10], tProfession.StartingStats[10]);
            
            tAdventurer = Instantiate(AdventurerPrefab);
            tAdventurer.GetComponent<AdventurerStats>().InitializeAdvStats(tadvinit);
            
            tAdventurer.GetComponent<CharacterEquipmentSlots>().EquipSet(tadvinit.profession.startingEquipment.equipmentSet);
            
            return tAdventurer;
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
            SO_RaceBase trace = new SO_RaceBase();
            if (AvailableRaces.Count < 0)
            {
                Debug.LogError("No Races Available");
                return null;
            }
            
            trace = AvailableRaces[RNGMachine(0, AvailableRaces.Count)];
            
            return trace;
        }

        private SO_SubRaceBase PickSubRace()
        {
            SO_SubRaceBase tsubrace = new SO_SubRaceBase();
            if (AvailableSubRaces.Count < 0)
            {
                Debug.LogError("No Sub Races Available");
                tsubrace = _noSubrace;
                return null;
            }

            if (RNGMachine(0, 100) > _SubracePercentChance)
            {
                tsubrace = _noSubrace;
            }
            else
            {
                tsubrace = AvailableSubRaces[RNGMachine(0, AvailableSubRaces.Count)];
            }
            
            return tsubrace;
        }

        private SO_AdventurerProfessionBase PickProfession()
        {
            SO_AdventurerProfessionBase tprofession  = new SO_AdventurerProfessionBase();
            if (AvailableProfessions.Count < 0)
            {
                Debug.LogError("No Professions Available");
                return null;
            }
            
            tprofession = AvailableProfessions[RNGMachine(0, AvailableProfessions.Count)];
            
            return tprofession;
        }

        private int RNGMachine(int min, int max)
        {
            return Random.Range(minInclusive: min, maxExclusive: max);
        }
    }
}


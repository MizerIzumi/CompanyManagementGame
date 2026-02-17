using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CompanyAdventurersList : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _companyAdventurers = new List<GameObject>();
        private CompanyStats _companyStats;
        public int adventurerCapacity = 1;

        private void Start()
        {
            _companyStats = gameObject.GetComponent<CompanyStats>();
            adventurerCapacity = (int)_companyStats.StatsDictionary[TargetTags.CompRecruitCapacity].Value;
            _companyStats.StatsDictionary[TargetTags.CompRecruitCapacity].onStatChanged += UpdateCapacity;
        }

        public bool TryRecruitAdventurer(GameObject adventurer)
        {
            if (!adventurer)
            {
                Debug.LogError("Adventurers can not be null!");
                return false;
            }

            if (_companyAdventurers.Count < adventurerCapacity)
            {
                _companyAdventurers.Add(adventurer);
                return true;
            }
            return false;
        }

        public void RemoveAdventurer(GameObject adventurer)
        {
            if (!adventurer)
            {
                Debug.LogError("Adventurers can not be null!");
                return;
            }
            
            _companyAdventurers.Remove(adventurer);
        }

        public List<GameObject> GetAdventurers()
        {
            return _companyAdventurers;
        }
        
        public void SortBy(TargetTags target)
        {
            //do this at some point
        }

        private void UpdateCapacity(Statistic stat)
        {
            adventurerCapacity = Mathf.FloorToInt(stat.Value);
        }
    }

}

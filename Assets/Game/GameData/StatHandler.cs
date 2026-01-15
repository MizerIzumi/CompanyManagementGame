using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StatHandler : MonoBehaviour
    {
        [SerializeField]
        protected string _name;

        //All Stats get added to the stats List
        public Dictionary<TargetTags, Statistic> StatsDictionary = new Dictionary<TargetTags, Statistic>();
        
        //ProgressBars that are linked to a stat get added to this Dictionary
        private Dictionary<Statistic, ProgressBar> _statBarsDict  = new Dictionary<Statistic, ProgressBar>();
        
        
        
        
        //List & Dictionary functions
        protected void AddStat(Statistic stat, TargetTags targetTagKey)
        {
            StatsDictionary.Add(targetTagKey, stat);
        }

        protected void AddStatWithBar(Statistic stat, TargetTags targetTagKey, ProgressBar bar)
        {
            AddStat(stat, targetTagKey);
            _statBarsDict.Add(stat, bar);
            
            bar.onBarReset += stat.IncrementStat;
            bar.onBarRegress += stat.DecrementStat;

            stat.onStatChanged += ResetAndRegressCapping;
        }
        
        
        //Stat Functions
        
        
        
        //Progress Bar Functions
        private void ResetAndRegressCapping(Statistic stat)
        {
            //Stops the bar resetting on max level
            _statBarsDict[stat].ResetOnFill = stat.Value < stat.StatMax;
                
            //Stops the bar regressing on min level
            _statBarsDict[stat].RegressBelowZero = stat.Value > stat.StatMin;
        }

        public ProgressBar GetStatBar(TargetTags targetTagKey)
        {
            return _statBarsDict[StatsDictionary[targetTagKey]];
        }
        
        public void IncreaseBar(TargetTags targetTagKey, float amount)
        {
            Statistic stat = StatsDictionary[targetTagKey];
            ProgressBar bar = _statBarsDict[stat];
            
            if (!(stat.Value >= stat.StatMax)) bar.IncreaseBar(amount);
        }
        
        public void DecreaseBar(TargetTags targetTagKey,float amount)
        {
            Statistic stat = StatsDictionary[targetTagKey];
            ProgressBar bar = _statBarsDict[stat];
            
            if (!(stat.Value < stat.StatMin)) bar.DecreaseBar(amount);
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string new_Name)
        {
            _name = new_Name;
        }
    }
}
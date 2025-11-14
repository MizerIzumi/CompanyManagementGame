using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StatHandler : MonoBehaviour
    {
        [SerializeField]
        protected string _name;

        //All Stats get added to the stats List
        public Dictionary<TagsEnum, Statistic> Stats = new Dictionary<TagsEnum, Statistic>();
        
        //ProgressBars that are linked to a stat get added to this Dictionary
        private Dictionary<Statistic, ProgressBar> _statBarsDict  = new Dictionary<Statistic, ProgressBar>();
        
        
        
        
        //List & Dictionary functions
        protected void AddStat(Statistic stat, TagsEnum tagKey)
        {
            Stats.Add(tagKey, stat);
        }

        protected void AddStatWithBar(Statistic stat, TagsEnum tagKey, ProgressBar bar)
        {
            AddStat(stat, tagKey);
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

        public ProgressBar GetStatBar(TagsEnum tagKey)
        {
            return _statBarsDict[Stats[tagKey]];
        }
        
        public void IncreaseBar(TagsEnum tagKey, float amount)
        {
            Statistic stat = Stats[tagKey];
            ProgressBar bar = _statBarsDict[stat];
            
            if (!(stat.Value >= stat.StatMax)) bar.IncreaseBar(amount);
        }
        
        public void DecreaseBar(TagsEnum tagKey,float amount)
        {
            Statistic stat = Stats[tagKey];
            ProgressBar bar = _statBarsDict[stat];
            
            if (!(stat.Value < stat.StatMin)) bar.DecreaseBar(amount);
        }

        /*
        public void IncreaseBarMultiplier(int statIndex, float amount)
        {
            Statistic stat = Stats[statIndex];
            ProgressBar bar = _statBarsDict[stat];
            
            bar.BarMultiplier += amount;
        }

        public void DecreaseBarMultiplier(int statIndex, float amount)
        {
            Statistic stat = Stats[statIndex];
            ProgressBar bar = _statBarsDict[stat];

            if (bar.BarMultiplier - amount <= 0.01f)
            {
                bar.BarMultiplier
            }
                
            bar.BarMultiplier -= amount;
        }
        */
    }
}
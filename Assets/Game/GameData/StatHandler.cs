using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Game
{
    public class StatHandler : MonoBehaviour
    {
        [SerializeField]
        protected string _name;

        public List<Statistic> Stats = new List<Statistic>();
        
        public Dictionary<Statistic, ProgressBar> StatBarsDict  = new Dictionary<Statistic, ProgressBar>();
        
        protected void AddStat(Statistic stat)
        {
            Stats.Add(stat);
        }

        protected void AddStatWithBar(Statistic stat, ProgressBar bar)
        {
            AddStat(stat);
            StatBarsDict.Add(stat, bar);
            
            bar.onBarReset += stat.IncrementStat;
            bar.onBarRegress += stat.DecrementStat;

            stat.onStatChanged += ResetAndRegressCapping;
        }
        
        private void ResetAndRegressCapping(Statistic stat)
        {
            //Stops the bar resetting on max level
            StatBarsDict[stat].ResetOnFill = stat.Value < stat.StatMax;
                
            //Stops the bar regressing on min level
            StatBarsDict[stat].RegressBelowZero = stat.Value > stat.StatMin;
        }

        public void IncreaseBarProgress(Statistic stat)
        {
            
        }
        
        public void DecreaseBarProgress(Statistic stat)
        {
            
        }
    }
}
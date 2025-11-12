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

        public List<Statistic> stats;
        
        public Dictionary<Statistic, ProgressBar> statBarsDict  = new Dictionary<Statistic, ProgressBar>();
        
        protected void AddStat(Statistic stat)
        {
            stats.Add(stat);
        }

        protected void AddStatWithBar(Statistic stat, ProgressBar bar)
        {
            AddStat(stat);
            statBarsDict.Add(stat, bar);
            
            bar.onBarReset += stat.IncrementStat;
            bar.onBarBelowZero += stat.DecrementStat;

            stat.onStatReachedMax += BarManagementUpper;
            stat.onStatReachedMin += BarManagementLower;
        }
        
        public void  BarManagementUpper(Statistic stat)
        {
            if (stat.value >= stat.statMin)
            {
                statBarsDict[stat].regressBelowZero = true;
            }
            if (stat.value >= stat.statMax)
            {
                statBarsDict[stat].resetOnFill = false;
            }
        }
        public void BarManagementLower(Statistic stat)
        {
            if (stat.value <= stat.statMax)
            {
                statBarsDict[stat].resetOnFill = true;
            }
            if (stat.value <= stat.statMin)
            {
                statBarsDict[stat].regressBelowZero = false;
            }
        }
    }
}
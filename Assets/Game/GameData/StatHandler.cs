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

        List<Statistic> stats;
        List<ProgressBar> bars;
        
        protected void AddStat(Statistic stat)
        {
            stats.Add(stat);
        }

        protected void AddStatWithBar(Statistic stat, ProgressBar bar)
        {
            stats.Add(stat);
            bars.Add(bar);
            stat.barIndex = bars.Count - 1;
            
            bar.onBarReset += stat.IncrementStat;
            bar.onBarBelowZero += stat.DecrementStat;
        }
        
        //public Dictionary<int, Statistic> Stats = new Dictionary<int, Statistic>();
    }
}
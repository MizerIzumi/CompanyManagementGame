using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CompanyStats : StatHandler
    {
        private const float MaxRepLVL = 2;
        private const float RepExpToLevel = 3;
        private const float MaxCompInvSize = 200;
        private const float MaxShopInvSize = 100;
        private const float MaxRecruitment = 40;
        private const float AlignmentBounds = 100;
        
        public void OnEnable()
        {
            //Adding the all the stats to the Stats dictionary
            
            StatInitializer fundsinit = new StatInitializer("Funds", 100f, 1, (float)Int32.MinValue, (float)Int32.MaxValue);
            Statistic FundsStat = new Statistic(fundsinit);
            AddStat(FundsStat, TargetTags.CompFunds);
            
            StatInitializer repinit = new StatInitializer("Reputation Level", 0f, 1, 0, MaxRepLVL);
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, RepExpToLevel, 0);
            Statistic RepLVLStat = new Statistic(repinit);
            AddStatWithBar(RepLVLStat, TargetTags.CompRepLevel, RepLVLBar);
            
            StatInitializer compinvinit = new StatInitializer("Company Inventory Size", 10, 1, 0, MaxCompInvSize);
            Statistic CompInvSizeStat = new Statistic(compinvinit);
            AddStat(CompInvSizeStat,  TargetTags.CompInvSize);
            
            StatInitializer shopinvinit = new StatInitializer("Shop Inventory Size", 3, 1, 0, MaxShopInvSize);
            Statistic ShopInvSizeStat = new Statistic(shopinvinit);
            AddStat(ShopInvSizeStat,  TargetTags.CompShopInvSize);
            
            StatInitializer aligninit = new StatInitializer("Alignment", 0, 1, -AlignmentBounds, AlignmentBounds);
            Statistic AlignmentStat = new Statistic(aligninit);
            AddStat(AlignmentStat,   TargetTags.CompAlignment);
            
            StatInitializer recinit = new StatInitializer("Recruitment Capacity", 4, 1, 1, MaxRecruitment);
            Statistic RecruitCapStat = new Statistic(recinit);
            AddStat(RecruitCapStat, TargetTags.CompRecruitCapacity);
        }
        
        public void Start()
        {
            /*
            foreach (var VARIABLE in StatsDictionary)
            {
                Debug.Log(VARIABLE.Value.DisplayName);
            }
            */
        }

        public void TestQuestComplete()
        {
            IncreaseBar(TargetTags.CompRepLevel, 1);
        }

        public void TestQuestFail()
        {
            DecreaseBar(TargetTags.CompRepLevel, 1);
        }
        
    }
}
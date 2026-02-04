using System;
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
            //Adding the all the stats to the Stats List/dictionary
            /*
            Statistic FundsStat = new Statistic("Funds", 0, Int32.MinValue, Int32.MaxValue);
            AddStat(FundsStat, TargetTags.CompFunds);
            
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, RepExpToLevel, 0);
            Statistic RepLVLStat = new Statistic("Reputation Level", 0, 0, MaxRepLVL);
            AddStatWithBar(RepLVLStat, TargetTags.RepLevel, RepLVLBar);
            
            Statistic CompInvSizeStat = new Statistic("Company Inventory Size", 10, 0, MaxCompInvSize);
            AddStat(CompInvSizeStat,  TargetTags.CompInvSize);
            
            Statistic ShopInvSizeStat = new Statistic("Shop Inventory Size", 3, 0, MaxShopInvSize);
            AddStat(ShopInvSizeStat,  TargetTags.ShopInvSize);
            
            Statistic AlignmentStat = new Statistic("Alignment", 0, -AlignmentBounds, AlignmentBounds);
            AddStat(AlignmentStat,   TargetTags.CompAlignment);
            
            Statistic RecruitCapStat = new Statistic("Recruitment Capacity", 0, 1, MaxRecruitment);
            AddStat(RecruitCapStat, TargetTags.RecruitCapacity);
            */
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
            IncreaseBar(TargetTags.RepLevel, 1);
        }

        public void TestQuestFail()
        {
            DecreaseBar(TargetTags.RepLevel, 1);
        }
        
    }
}
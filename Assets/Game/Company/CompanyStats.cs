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
            //Adding the all the stats to the Stats dictionary
            
            StatInitializer tfundsinit = new StatInitializer("Funds", 0f, 1, (float)Int32.MinValue, (float)Int32.MaxValue);
            Statistic FundsStat = new Statistic(tfundsinit);
            AddStat(FundsStat, TargetTags.CompFunds);
            
            StatInitializer trepinit = new StatInitializer("Reputation Level", 0f, 1, 0, MaxRepLVL);
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, RepExpToLevel, 0);
            Statistic RepLVLStat = new Statistic(trepinit);
            AddStatWithBar(RepLVLStat, TargetTags.RepLevel, RepLVLBar);
            
            StatInitializer tcompinvinit = new StatInitializer("Company Inventory Size", 10, 1, 0, MaxCompInvSize);
            Statistic CompInvSizeStat = new Statistic(tcompinvinit);
            AddStat(CompInvSizeStat,  TargetTags.CompInvSize);
            
            StatInitializer tshopinvinit = new StatInitializer("Shop Inventory Size", 3, 1, 0, MaxShopInvSize);
            Statistic ShopInvSizeStat = new Statistic(tshopinvinit);
            AddStat(ShopInvSizeStat,  TargetTags.ShopInvSize);
            
            StatInitializer taligninit = new StatInitializer("Alignment", 0, 1, -AlignmentBounds, AlignmentBounds);
            Statistic AlignmentStat = new Statistic(taligninit);
            AddStat(AlignmentStat,   TargetTags.CompAlignment);
            
            StatInitializer trecinit = new StatInitializer("Recruitment Capacity", 0, 1, 1, MaxRecruitment);
            Statistic RecruitCapStat = new Statistic(trecinit);
            AddStat(RecruitCapStat, TargetTags.RecruitCapacity);
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
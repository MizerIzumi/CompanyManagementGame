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
            
            Statistic FundsStat = new Statistic("Funds", 0, Int32.MinValue, Int32.MaxValue, 1, 1);
            AddStat(FundsStat, TagsEnum.CompFunds);
            
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, RepExpToLevel, 0);
            Statistic RepLVLStat = new Statistic("Reputation Level", 0, 0, MaxRepLVL, 1, 1);
            AddStatWithBar(RepLVLStat, TagsEnum.RepLevel, RepLVLBar);
            
            Statistic CompInvSizeStat = new Statistic("Company Inventory Size", 10, 0, MaxCompInvSize, 1, 1);
            AddStat(CompInvSizeStat,  TagsEnum.CompInvSize);
            
            Statistic ShopInvSizeStat = new Statistic("Shop Inventory Size", 3, 0, MaxShopInvSize, 1, 1);
            AddStat(ShopInvSizeStat,  TagsEnum.ShopInvSize);
            
            Statistic AlignmentStat = new Statistic("Alignment", 0, -AlignmentBounds, AlignmentBounds, 1, 1);
            AddStat(AlignmentStat,   TagsEnum.CompAlignment);
            
            Statistic RecruitCapStat = new Statistic("Recruitment Capacity", 0, 1, MaxRecruitment, 1, 1);
            AddStat(RecruitCapStat, TagsEnum.RecruitCapacity);
        }

        public void Start()
        {
            foreach (var VARIABLE in Stats)
            {
                Debug.Log(VARIABLE.Value.DisplayName);
            }
        }

        public void Update()
        {
            //TestQuestComplete();
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string new_Name)
        {
            name = new_Name;
        }

        public void TestQuestComplete()
        {
            IncreaseBar(TagsEnum.RepLevel, 1);
        }

        public void TestQuestFail()
        {
            DecreaseBar(TagsEnum.RepLevel, 1);
        }
        
    }
}
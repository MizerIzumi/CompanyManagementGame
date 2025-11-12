using System;

namespace Game
{
    public class CompanyStats : StatHandler
    {
        private const float MaxRepLVL = 99;
        private const float MaxCompInvSize = 200;
        private const float MaxShopInvSize = 100;
        private const float MaxRecruitment = 40;
        private const float AlignmentBounds = 100;
        
        public enum StatIndices
        {
            Funds,
            RepLVL,
            CompInvSize,
            ShopInvSize,
            Alignment,
            RecruitCapacity
        }
        
        public void OnEnable()
        {
            //Adding the all the stats to the Stats List/dictionary
            
            //0
            Statistic FundsStat = new Statistic("Funds", 0, Int32.MinValue, Int32.MaxValue, 1, 1);
            AddStat(FundsStat);
            
            //1
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, 100);
            Statistic RepLVLStat = new Statistic("Reputation Level", 0, 0, MaxRepLVL, 1, 1);
            AddStatWithBar(RepLVLStat, RepLVLBar);
            
            //2
            Statistic CompInvSizeStat = new Statistic("Company Inventory Size", 10, 0, MaxCompInvSize, 1, 1);
            AddStat(CompInvSizeStat);
            
            //3
            Statistic ShopInvSizeStat = new Statistic("Shop Inventory Size", 3, 0, MaxShopInvSize, 1, 1);
            AddStat(ShopInvSizeStat);
            
            //4
            Statistic AlignmentStat = new Statistic("Alignment", 0, -AlignmentBounds, AlignmentBounds, 1, 1);
            AddStat(AlignmentStat);
            
            //5
            Statistic RecruitCapStat = new Statistic("Alignment", 0, 1, MaxRecruitment, 1, 1);
            AddStat(RecruitCapStat);
        }

        public void Start()
        {
            
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
            statBarsDict[stats[(int)StatIndices.RepLVL]].IncreaseBar(1);
        }

        public void TestQuestFail()
        {
            statBarsDict[stats[(int)StatIndices.RepLVL]].DecreaseBar(1);
        }
        
    }
}
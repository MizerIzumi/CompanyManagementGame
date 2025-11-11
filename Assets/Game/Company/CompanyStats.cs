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
            //Adding the all the stats to the Stats dictionary
            Statistic FundsStat = new Statistic("Funds", 0, Int32.MinValue, Int32.MaxValue, 1, 1);
            AddStat(FundsStat);
            
            ProgressBar RepLVLBar = new ProgressBar(true, false, 1, 100);
            Statistic RepLVLStat = new Statistic("Reputation Level", 0, 0, MaxRepLVL, 1, 1);
            AddStatWithBar(RepLVLStat, RepLVLBar);
            
            Statistic CompInvSizeStat = new Statistic("Company Inventory Size", 10, 0, MaxCompInvSize, 1, 1);
            AddStat(CompInvSizeStat);
            
            Statistic ShopInvSizeStat = new Statistic("Shop Inventory Size", 3, 0, MaxShopInvSize, 1, 1);
            AddStat(ShopInvSizeStat);
            
            Statistic AlignmentStat = new Statistic("Alignment", 0, -AlignmentBounds, AlignmentBounds, 1, 1);
            AddStat(AlignmentStat);
            
            Statistic RecruitCapStat = new Statistic("Alignment", 0, 1, MaxRecruitment, 1, 1);
            AddStat(RecruitCapStat);
        }
        
        public string GetName()
        {
            return name;
        }

        public void SetName(string new_Name)
        {
            name = new_Name;
        }
        
        
    }
}
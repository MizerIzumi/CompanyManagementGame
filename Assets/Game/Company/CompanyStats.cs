

namespace Game
{
    public class CompanyStats : StatBlock
    {
        public ProgressBar reputationProg;

        private static float MaxRepLVL = 9;
        private static float StartingAlignment = 100;
        
        public enum StatNames
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
            reputationProg.onBarFilled += IncreaseRepLVL;
            
            //Adding the all the stats to the Stats dictionary
            Stats.Add((int)StatNames.Funds, 0.0f);
            Stats.Add((int)StatNames.RepLVL, 0.0f);
            Stats.Add((int)StatNames.CompInvSize, 0.0f);
            Stats.Add((int)StatNames.ShopInvSize, 0.0f);
            Stats.Add((int)StatNames.Alignment, StartingAlignment);
            Stats.Add((int)StatNames.RecruitCapacity, 0.0f);
        }

        public void OnDisable()
        {
            reputationProg.onBarFilled -= IncreaseRepLVL;
        }
        
        public string GetName()
        {
            return name;
        }

        public void SetName(string new_Name)
        {
            name = new_Name;
        }

        private void IncreaseRepLVL()
        {
            if (Stats[(int)StatNames.RepLVL] == MaxRepLVL)
            {
                reputationProg.ResetOnFill = false;
            }
            Stats[(int)StatNames.RepLVL]++;
        }
        
        
    }
}
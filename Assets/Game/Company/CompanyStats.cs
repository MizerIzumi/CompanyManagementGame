

namespace Game
{
    public class CompanyStats : StatBlock
    {
        public ProgressBar reputationProg;

        public float tempreputation = 0;
        
        private const float MaxRepLVL = 99;
        private const float StartingAlignment = 100;
        
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
            reputationProg.onBarReset += LevelUpRep;
            reputationProg.onBarBelowZero += LevelDownRepLVL;
            
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
            reputationProg.onBarReset -= LevelUpRep;
            reputationProg.onBarBelowZero -= LevelDownRepLVL;
        }
        
        public string GetName()
        {
            return name;
        }

        public void SetName(string new_Name)
        {
            name = new_Name;
        }


        private void LevelUpRep()
        {
            int repIndex = (int)StatNames.RepLVL;
            
            IncreaseStat(repIndex, 1, MaxRepLVL, reputationProg);
            
            tempreputation = Stats[repIndex];
        }

        private void LevelDownRepLVL()
        {
            int repIndex = (int)StatNames.RepLVL;
            
            DecreaseStat(repIndex, 1, MaxRepLVL, reputationProg);
            
            tempreputation = Stats[repIndex];
        }
        
        
        private void IncreaseStat(int statIndex, float increasAmount, float statMaxLevel, ProgressBar progressBar)
        {
            Stats[statIndex] += increasAmount;
            
            if (progressBar != null && Stats[statIndex] == statMaxLevel)
            {
                progressBar.ResetOnFill = false;
            }
        }
        
        private void DecreaseStat(int statIndex, float decreaseAmount, float statMaxLevel, ProgressBar progressBar)
        {
            if (progressBar != null && Stats[statIndex] == statMaxLevel)
            {
                progressBar.ResetOnFill = true;
            }
            
            Stats[statIndex] -= decreaseAmount;
        }
        
    }
}
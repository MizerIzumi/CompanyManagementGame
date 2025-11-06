

namespace Game
{
    public class CompanyStats : StatBlock
    {
        public ProgressBar reputationProg;

        public float tempreputation = 0;
        
        private const float MaxRepLVL = 99;
        private const float StartingAlignment = 100;
        
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
            reputationProg.onBarReset += LevelUpRep;
            reputationProg.onBarBelowZero += LevelDownRepLVL;
            
            //Adding the all the stats to the Stats dictionary
            Stats.Add((int)StatIndices.Funds, 0.0f);
            Stats.Add((int)StatIndices.RepLVL, 0.0f);
            Stats.Add((int)StatIndices.CompInvSize, 0.0f);
            Stats.Add((int)StatIndices.ShopInvSize, 0.0f);
            Stats.Add((int)StatIndices.Alignment, StartingAlignment);
            Stats.Add((int)StatIndices.RecruitCapacity, 0.0f);
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
            int repIndex = (int)StatIndices.RepLVL;
            
            IncreaseStat(repIndex,1);
            
            if (Stats[repIndex] == MaxRepLVL)
            {
                reputationProg.ResetOnFill = true;
            }
            
            tempreputation = Stats[repIndex];
        }
        
        private void LevelDownRepLVL()
        {
            int repIndex = (int)StatIndices.RepLVL;
            
            if (Stats[repIndex] == MaxRepLVL)
            {
                reputationProg.ResetOnFill = false;
            }
            
            DecreaseStat(repIndex, 1);
            
            tempreputation = Stats[repIndex];
        }
    }
}
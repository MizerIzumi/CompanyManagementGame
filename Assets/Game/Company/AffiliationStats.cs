

namespace Game
{
    
    //Fix shit here, need to get the events to trigger the right rank up for the affiliations
    
    public class AffiliationStats : StatBlock
    {
        private float _maxLevel;
        
        public ProgressBar TestAffiliationProgressBar;
        
        public enum AffiliationIndices
        {
            TestAffiliation
        }
        
        public void OnEnable()
        {
            TestAffiliationProgressBar.onBarReset += TestAffUp;
            
            //Adding the all the stats to the Stats dictionary
            Stats.Add((int)AffiliationIndices.TestAffiliation, 0.0f);
        }

        private void TestAffUp()
        {
            RankUp((int)AffiliationIndices.TestAffiliation);
        }

        private void RankUp(int AffiliationIndex)
        {
            Stats[AffiliationIndex] += 1;
        }

        private void RankDown(int AffiliationIndex)
        {
            Stats[AffiliationIndex] -= 1;
        }
    }
}
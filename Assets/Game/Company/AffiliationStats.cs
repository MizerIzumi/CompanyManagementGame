

namespace Game
{
    
    //Fix shit here, need to get the events to trigger the right rank up for the affiliations
    
    public class AffiliationStats : StatHandler
    {
        private float _maxLevel;
        
        public enum AffiliationIndices
        {
            TestAffiliation
        }
        
        public void OnEnable()
        {
            //Adding the all the stats to the Stats dictionary
            ProgressBar TestAffiliationProgressBar = new ProgressBar(true, true, 1, 10);
            Statistic TestAffiliationStatistic = new Statistic("TestAffiliation", 0, -10, 10, 1, 1);
            AddStatWithBar(TestAffiliationStatistic, TestAffiliationProgressBar);
        }
    }
}
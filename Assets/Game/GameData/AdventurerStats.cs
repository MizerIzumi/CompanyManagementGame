

using System.Numerics;

namespace Game
{
    public class AdventurerStats : StatHandler
    {
        public string AdventurerName;

        public TargetTags Alignment;
        public TargetTags Race;
        public TargetTags Sub_Race;
        public TargetTags Faith;
        
        public int MinStr = 1;
        public int MaxStr = 10;
        
        public void OnEnable()
        {
            //Statistic AdvStrength = new Statistic("Health", )
        }
        
    }
}
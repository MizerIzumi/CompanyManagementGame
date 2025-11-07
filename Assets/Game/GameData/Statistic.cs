

namespace Game
{
    public struct Statistic
    {
        public string displayName;
        public float value;
        public float statMultiplier;
        
        private ProgressBar _progressBar;
        
        public float progressMultiplier
        {
            get { return _progressBar.barMultiplier; }
            private set {_progressBar.barMultiplier = value;}
        }
        
        
        public Statistic(string displayName, float value, float statMultiplier, ProgressBar progressBar)
        {
            this.displayName = displayName;
            this.value = value;
            this.statMultiplier = statMultiplier;
            _progressBar = progressBar;
            
            _progressBar.onBarFilled += IncreseStat;
            _progressBar.onBarBelowZero += DecreseStat;
        }
        
        
        //Increase/Decrease the value of this stat
        public void  IncreseStat()
        {
            value += 1;
        }
        public void DecreseStat()
        {
            value -= 1;
        }

        //Increase/Decrease the multiplier of this stat
        public void IncreaseStatMultiplier(float amount)
        {
            statMultiplier += amount;
        }
        public void DecreaseStatMultiplier(float amount)
        {
            statMultiplier -= amount;
        }
        
        
        public float GetProgressValue()
        {
            return _progressBar.barValue;
        }
        
        //Increase/Decrease the progress bar attached to the stat
        public void IncreaseProgress(float amount)
        {
            _progressBar.IncreaseBar(amount);
        }
        public void DecreaseProgress(float amount)
        {
            _progressBar.DecreaseBar(amount);
        }
        
        //Increase/Decrease the multiplier of the progress bar
        public void IncreaseProgressMultiplier(float amount)
        {
            progressMultiplier += amount;
        }
        public void DecreaseProgressMultiplier(float amount)
        {
            progressMultiplier -= amount;
        }
    }
}


namespace Game
{
    public class Statistic
    {
        public delegate void OnStatChanged();
        public event OnStatChanged onStatChanged;
        public delegate void OnStatReachedMax(Statistic stat);
        public event OnStatReachedMax onStatReachedMax;
        public delegate void OnStatReachedMin(Statistic stat);
        public event OnStatReachedMin onStatReachedMin;
        
        
        public string displayName;

        private float _value;

        public float value
        {
            get { return _value * statMultiplier; }
            private set { _value = value; }
        }
        
        public float statMultiplier;
        public float statGrowthMultiplier;
        public float statMin;
        public float statMax;
        
        
        public Statistic(string displayname, float value, float statmin, float statmax, float statmultiplier, float statgrowthmultiplier)
        {
            displayName = displayname;
            this.value = value;
            statMin = statmin;
            statMax = statmax;
            statMultiplier = statmultiplier;
            statGrowthMultiplier = statgrowthmultiplier;
        }
        
        
        //Increase/Decrease the value of this stat
        public void IncreaseStat(float amount)
        {
            if (amount < 0) return;

            float mAmount = amount * statGrowthMultiplier;
            
            if (value + mAmount >= statMax)
            {
                value = statMax;
                onStatChanged?.Invoke();
                onStatReachedMax?.Invoke(this);
                return;
            }
            value += mAmount;
            onStatChanged?.Invoke();
        }
        public void DecreaseStat(float amount)
        {
            if (amount < 0) return;
            
            float mAmount = amount * statGrowthMultiplier;
            
            if (value - mAmount <= statMin)
            {
                value = statMin;
                onStatChanged?.Invoke();
                onStatReachedMin?.Invoke(this);
                return;
            }
            value -= mAmount;
            onStatChanged?.Invoke();
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
        
        //Increase/Decrease the growth multiplier of this stat
        public void IncreaseStatGrowthMultiplier(float amount)
        {
            statGrowthMultiplier += amount;
        }
        public void DecreaseStatGrowthMultiplier(float amount)
        {
            statGrowthMultiplier -= amount;
        }
        
        //Stat +/- 1
        public void  IncrementStat()
        {
            if (value >= statMax)
            {
                value = statMax;
                onStatChanged?.Invoke();
                onStatReachedMax?.Invoke(this);
                return;
            }
            
            value += 1 * statGrowthMultiplier;;
            onStatChanged?.Invoke();
        }
        public void DecrementStat()
        {
            if (value <= statMin)
            {
                value = statMin;
                onStatChanged?.Invoke();
                onStatReachedMin?.Invoke(this);
                return;
            }
            
            value -= 1;
            onStatChanged?.Invoke();
        }
        
        
        
        
        
        
        /*
         
        public void  IncrementStat()
        {
            if (value == statMin)
            {
                _progressBar.regressBelowZero = true;
            }
            
            value += 1 * statGrowthMultiplier;;
            
            if (value >= statMax)
            {
                _progressBar.resetOnFill = false;
                value = statMax;
            }
        }
        public void DecrementStat()
        {
            if (value == statMax)
            {
                _progressBar.resetOnFill = true;
            }
            
            value -= 1 * statGrowthMultiplier;;
            
            if (value <= statMin)
            {
                _progressBar.regressBelowZero = false;
                value = statMin;
            }
        }
         
         public void OnBarReset()
         {
         StatHandler.increment
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
        */
    }
}


namespace Game
{
    public class Statistic
    {
        public delegate void OnStatChanged(Statistic stat);
        public event OnStatChanged onStatChanged;
        public delegate void OnStatReachedMax(Statistic stat);
        public event OnStatReachedMax onStatReachedMax;
        public delegate void OnStatReachedMin(Statistic stat);
        public event OnStatReachedMin onStatReachedMin;
        
        
        public string DisplayName;

        private float _value;

        public float Value
        {
            get { return _value * StatMultiplier; }
            private set { _value = value; }
        }
        
        public float StatMultiplier;
        public float StatGrowthMultiplier;
        public float StatMin;
        public float StatMax;
        
        
        public Statistic(string displayname, float value, float statmin, float statmax, float statmultiplier, float statgrowthmultiplier)
        {
            DisplayName = displayname;
            Value = value;
            StatMin = statmin;
            StatMax = statmax;
            StatMultiplier = statmultiplier;
            StatGrowthMultiplier = statgrowthmultiplier;
        }
        
        
        //Increase/Decrease the value of this stat
        public void IncreaseStat(float amount)
        {
            if (amount < 0) return;

            float mAmount = amount * StatGrowthMultiplier;
            
            if (Value + mAmount >= StatMax)
            {
                Value = StatMax;
                onStatChanged?.Invoke(this);
                onStatReachedMax?.Invoke(this);
                return;
            }
            Value += mAmount;
            onStatChanged?.Invoke(this);
        }
        public void DecreaseStat(float amount)
        {
            if (amount < 0) return;
            
            float mAmount = amount * StatGrowthMultiplier;
            
            if (Value - mAmount <= StatMin)
            {
                Value = StatMin;
                onStatChanged?.Invoke(this);
                onStatReachedMin?.Invoke(this);
                return;
            }
            Value -= mAmount;
            onStatChanged?.Invoke(this);
        }

        //Increase/Decrease the multiplier of this stat
        public void IncreaseStatMultiplier(float amount)
        {
            StatMultiplier += amount;
        }
        public void DecreaseStatMultiplier(float amount)
        {
            StatMultiplier -= amount;
        }
        
        //Increase/Decrease the growth multiplier of this stat
        public void IncreaseStatGrowthMultiplier(float amount)
        {
            StatGrowthMultiplier += amount;
        }
        public void DecreaseStatGrowthMultiplier(float amount)
        {
            StatGrowthMultiplier -= amount;
        }
        
        //Stat +/- 1
        public void  IncrementStat()
        {
            if (Value + 1 * StatGrowthMultiplier >= StatMax)
            {
                Value = StatMax;
                onStatChanged?.Invoke(this);
                onStatReachedMax?.Invoke(this);
                return;
            }
            
            Value += 1 * StatGrowthMultiplier;
            onStatChanged?.Invoke(this);
        }
        public void DecrementStat()
        {
            if (Value - 1 <= StatMin)
            {
                Value = StatMin;
                onStatChanged?.Invoke(this);
                onStatReachedMin?.Invoke(this);
                return;
            }
            
            Value -= 1;
            onStatChanged?.Invoke(this);
        }
    }
}


namespace Game
{
    public class ProgressBar
    {
        public delegate void OnBarFilled();
        public event OnBarFilled onBarFilled;
        
        public delegate void OnBarEmpty();
        public event OnBarEmpty onBarEmpty;

        public delegate void OnBarReset();
        public event OnBarReset onBarReset;
        
        public delegate void OnBarRegress();
        public event OnBarRegress onBarRegress;

        public delegate void OnBarUpdate();
        public event OnBarUpdate onBarUpdate;


        public bool ResetOnFill = true;
        
        public bool RegressBelowZero = false;
        
        private float _barValue = 0;
        
        public float BarMultiplier = 1;

        public float BarMax = 10;
        
        public float BarMin = 0;

        public ProgressBar(bool resetonfill, bool regressbelowzero, float barmultiplier,  float barmax, float barmin)
        {
            ResetOnFill = resetonfill;
            RegressBelowZero = regressbelowzero;
            BarMultiplier = barmultiplier;
            BarMax = barmax;
            BarMin = barmin;
        }
        
        public float BarValue
        {
            get { return _barValue; }

            private set
            {
                //check if the value you are setting is greater than the bar maximum
                if (value >= BarMax)
                {
                    //Is the bar set to reset upon hitting maximum capacity?
                    if (ResetOnFill)
                    {
                        //Check how many times the bar gets filled with the given value and then try to set it again.
                        RecursiveOverflowCheck(value);
                        return;
                    }

                    _barValue = BarMax;
                    onBarUpdate?.Invoke();
                    BarFilled();
                    return;
                }
                //Check if the value you are setting is lower than the bar minimum
                if (value <= BarMin)
                {
                    //Is the bar set to regress upon going below minimum capacity?
                    if (RegressBelowZero && value < BarMin)
                    {
                        //Check how many times the bar regresses with the given value and then try to set it again
                        RecursiveUnderflowCheck(value);
                        return;
                    }
                    
                    _barValue = BarMin;
                    onBarUpdate?.Invoke();
                    BarEmpty();
                    return;
                }
                
                _barValue = value;
                onBarUpdate?.Invoke();
            }
        }
        
        private void RecursiveOverflowCheck(float value)
        {
            //This only ever gets called if the Progress bar is set to reset on overflow
            //Maybe look in to how this could be calculated without being a recursive function
            float overflowCheck = value - BarMax;

            if (overflowCheck >= 0)
            {
                BarFilled();
                onBarReset?.Invoke();
                RecursiveOverflowCheck(overflowCheck);
            }
            else
            {
                BarValue = value;
            }
        }
        
        private void RecursiveUnderflowCheck(float value)
        {
            //This only ever gets called if the Progress bar is set to regress
            float underflowCheck = value - BarMin;

            if (underflowCheck < BarMin)
            {
                BarEmpty();
                onBarRegress?.Invoke();
                RecursiveUnderflowCheck(underflowCheck);
            }
            else
            {
                BarValue = value;
            }
        }
        
        private void BarFilled()
        {
            onBarFilled?.Invoke();
            //The ? is essentialy a nullcheck
        }

        private void BarEmpty()
        {
            onBarEmpty?.Invoke();
        }
        
        
        public void IncreaseBar(float value)
        {
            float mValue = value * BarMultiplier;
            
            if (mValue == 0 || BarValue >= BarMax) return;
            
            BarValue += mValue;
        }

        public void DecreaseBar(float value)
        {
            float mValue = value * BarMultiplier;

            if (mValue == 0 || BarValue - mValue < BarMin)
            {
                if (RegressBelowZero)
                {
                    onBarRegress?.Invoke();
                    BarValue = BarMax - mValue;
                }
                return;
            }

            BarValue -= mValue;
        }
    }
}
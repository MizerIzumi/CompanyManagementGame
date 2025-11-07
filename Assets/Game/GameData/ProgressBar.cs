using UnityEngine;
using UnityEngine.Serialization;

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
        
        public delegate void OnBarBelowZero();
        public event OnBarBelowZero onBarBelowZero;

        public delegate void OnBarUpdate();
        public event OnBarUpdate onBarUpdate;


        public bool resetOnFill = true;
        
        public bool regressBelowZero = false;
        
        private float _barValue = 0;
        
        public float barMultiplier = 1;

        public float barMax = 10;

        //public AnimationCurve barCurve;

        public ProgressBar(bool resetonfill, bool regressbelowzero, float barmultiplier,  float barmax)
        {
            resetOnFill = resetonfill;
            regressBelowZero = regressbelowzero;
            barMultiplier = barmultiplier;
            barMax = barmax;
        }
        
        public float barValue
        {
            get { return _barValue; }

            private set
            {
                if (resetOnFill)
                {
                    if (value - barMax >= 0) RecursiveOverflowCheck(value);
                    else
                    {
                        _barValue = value;
                        onBarUpdate?.Invoke();
                    }
                }
                else
                {
                    if (value - barMax >= 0)
                    {
                        _barValue = barMax;
                        onBarUpdate?.Invoke();
                        BarFilled();
                    }
                    else
                    {
                        _barValue = 0;
                        onBarUpdate?.Invoke();
                    }
                }
            }
        }

        
        public float BarPercent()
        {
            return barValue / barMax;
        }

        
        private void RecursiveOverflowCheck(float value)
        {
            float overflowCheck = value - barMax;

            if (overflowCheck >= 0)
            {
                BarFilled();
                RecursiveOverflowCheck(overflowCheck);
            }
            else
            {
                barValue = value;
            }
        }
        
        private void BarFilled()
        {
            _barValue = 0;
            onBarFilled?.Invoke();
            //The ? is essentialy a nullcheck
            
            if (resetOnFill) onBarReset?.Invoke();
        }
        
        
        public void IncreaseBar(float value)
        {
            float mValue = value * barMultiplier;
            
            if (mValue == 0 || barValue <= barMax) return;
            
            barValue += mValue;
        }

        public void DecreaseBar(float value)
        {
            float mValue = value * barMultiplier;
            
            if (mValue == 0) return;

            if (regressBelowZero && barValue - mValue < 0)
            {
                onBarBelowZero?.Invoke();
                barValue = barMax - mValue;
                return;
            }

            barValue -= mValue;
        }
    }
}
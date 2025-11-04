using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class ProgressBar : MonoBehaviour
    {
        public delegate void OnBarFilled();
        public event OnBarFilled onBarFilled;

        public delegate void OnBarBelowZero();
        public event OnBarBelowZero onBarBelowZero;

        public delegate void OnBarUpdate();
        public event OnBarUpdate onBarUpdate;


        public bool ResetOnFill = true;
        
        public bool RegressBelowZero = false;
        
        [SerializeField] private float _barValue = 0;

        public float barMax = 5;

        public AnimationCurve barCurve;
        
        public float barValue
        {
            get { return _barValue; }

            private set
            {
                if (ResetOnFill)
                {
                    if (value - barMax >= 0) RecursiveOverflowCheck(value);
                    else
                    {
                        _barValue = value;
                    }
                }
                else
                {
                    if (value - barMax >= 0)
                    {
                        _barValue = barMax; 
                        BarFilled();
                    }
                    else
                    {
                        _barValue = 0;
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
        }
        
        public void IncreaseBar(float value)
        {
            if (value == 0 || barValue == barMax) return;
            
            barValue += value;
            onBarUpdate?.Invoke();
        }

        public void DecreaseBar(float value)
        {
            if (value == 0) return;
            
            if (RegressBelowZero && value - barValue < 0) onBarBelowZero?.Invoke();
            
            barValue -= value;
            onBarUpdate?.Invoke();
        }
    }
}
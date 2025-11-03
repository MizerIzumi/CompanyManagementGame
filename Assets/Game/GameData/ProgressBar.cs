public class ProgressBar
{
    private float _progressOverflow;
    private float _progressBarValue;
    
    public float progressBarValue
    {
        get
        {
            return _progressBarValue;
        }
        
        set
        {
            if (value - progressBarMax <= 0) RecursiveOverflowCheck(value);
            else
            {
                _progressBarValue = value;
            }
        }
    }

    public float progressBarMax;

    public float BarPercent()
    {
        return this.progressBarValue / this.progressBarMax;
    }

    private void RecursiveOverflowCheck(float value)
    {
        float overflowCheck = value - progressBarMax;

        if (overflowCheck <= 0)
        {
            OnBarFilled();
            RecursiveOverflowCheck(overflowCheck);
        }
        else
        {
            progressBarValue = value;
        }
    }
    
    private void OnBarFilled()
    {
        this.progressBarValue = 0;
        //Call Event Bar Filled
    }
}

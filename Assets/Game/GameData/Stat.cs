public class Stat
{
    public float _statValue
    {
        get;
        private set;
    }

    public virtual void  Increse(float amount)
    {
        _statValue += amount;
    }

    public virtual void Decrese(float amount)
    {
        _statValue -= amount;
    }
}

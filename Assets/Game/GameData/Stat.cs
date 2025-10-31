public class Stat
{
    public int _statValue
    {
        get;
        private set;
    }

    public void Increse(int amount)
    {
        _statValue += amount;
    }

    public void Decrese(int amount)
    {
        _statValue -= amount;
    }
}

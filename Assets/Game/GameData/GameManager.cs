using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int seed = 0;

    private void Awake()
    {
        if (seed == 0)
        {
            //Generates a very unique seed every time
            seed = System.Environment.TickCount + System.DateTime.Now.Millisecond + System.Guid.NewGuid().GetHashCode();
            Random.InitState(seed);
        }
        print("Game Seed: " + seed);
    }
}

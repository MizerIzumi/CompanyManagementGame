using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public int seed = 0;
	    public static GameManager Instance {get; private set;}
	    public TimeManager timeManager;
	    public ShopAndCompInv compAndShopInv;
	    
	    private void Awake()
	    {
			
		    if (Instance != null && Instance != this)
		    {
			    Destroy(this);
		    }
		    else
		    {
			    Instance = this;
		    }
		    
	        if (seed == 0)
	        {
	            //Generates a unique seed every time
	            seed = System.Environment.TickCount + System.DateTime.Now.Millisecond + System.Guid.NewGuid().GetHashCode();
	            Random.InitState(seed);
	        }
	        print("Game Seed: " + seed);
	    }

	}
}
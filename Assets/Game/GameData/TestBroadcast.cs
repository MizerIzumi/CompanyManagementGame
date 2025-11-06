using UnityEngine;

namespace Game
{
    public class TestBroadcast : MonoBehaviour
    {
        [SerializeField] public ProgressBar progressBar;
        [SerializeField] public CompanyStats compStats;

        //public string message;

        public void OnEnable()
        {
            progressBar.onBarFilled += PrintmessageBarProgression;
            progressBar.onBarBelowZero += PrintmessageBarRegression;
        }

        public void OnDisable()
        {
            progressBar.onBarFilled -= PrintmessageBarProgression;
            progressBar.onBarBelowZero -= PrintmessageBarRegression;
        }


        private void PrintmessageBarProgression()
        {
            Debug.unityLogger.Log("Levelup");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.Stats[(int)CompanyStats.StatIndices.RepLVL]);
            //Debug.unityLogger.Log(message);
        }
        
        private void PrintmessageBarRegression()
        {
            Debug.unityLogger.Log("Leveldown");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.Stats[(int)CompanyStats.StatIndices.RepLVL]);
            //Debug.unityLogger.Log(message);
        }
    }
}
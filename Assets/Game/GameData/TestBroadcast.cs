using UnityEngine;

namespace Game
{
    public class TestBroadcast : MonoBehaviour
    {
        [SerializeField] public CompanyStats compStats;

        //public string message;

        public void OnEnable()
        {
            ProgressBar bar = compStats.statBarsDict[compStats.stats[(int)CompanyStats.StatIndices.RepLVL]];
            
            bar.onBarUpdate += PrintmessageBarUpdate;
            bar.onBarReset += PrintmessageBarProgression;
            bar.onBarBelowZero += PrintmessageBarRegression;
        }

        public void OnDisable()
        {
            ProgressBar bar = compStats.statBarsDict[compStats.stats[(int)CompanyStats.StatIndices.RepLVL]];
            
            bar.onBarUpdate -= PrintmessageBarProgression;
            bar.onBarBelowZero -= PrintmessageBarRegression;
        }

        private void PrintmessageBarUpdate()
        {
            ProgressBar bar = compStats.statBarsDict[compStats.stats[(int)CompanyStats.StatIndices.RepLVL]];
            Debug.unityLogger.Log("RepExp: " + bar.barValue);
            //Debug.unityLogger.Log(message);
        }

        private void PrintmessageBarProgression()
        {
            Debug.unityLogger.Log("Levelup");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.stats[(int)CompanyStats.StatIndices.RepLVL]);
            //Debug.unityLogger.Log(message);
        }
        
        private void PrintmessageBarRegression()
        {
            Debug.unityLogger.Log("Leveldown");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.stats[(int)CompanyStats.StatIndices.RepLVL]);
            //Debug.unityLogger.Log(message);
        }
    }
}
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
            progressBar.onBarFilled += printmessage;
        }

        public void OnDisable()
        {
            progressBar.onBarFilled -= printmessage;
        }


        private void printmessage()
        {
            
            Debug.unityLogger.Log("Company RepLevel: " + compStats.Stats[(int)CompanyStats.StatNames.RepLVL]);
            //Debug.unityLogger.Log(message);
        }
    }
}
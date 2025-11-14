using UnityEngine;

namespace Game
{
    public class TestBroadcast : MonoBehaviour
    {
        [SerializeField] public CompanyStats compStats;

        public void OnEnable()
        {
            ProgressBar bar = compStats.GetStatBar(TagsEnum.RepLevel);
            
            bar.onBarUpdate += PrintmessageBarUpdate;
            bar.onBarReset += PrintmessageBarReset;
            bar.onBarRegress += PrintmessageBarRegress;
        }

        public void OnDisable()
        {
            ProgressBar bar = compStats.GetStatBar(TagsEnum.RepLevel);
            
            bar.onBarUpdate -= PrintmessageBarReset;
            bar.onBarRegress -= PrintmessageBarRegress;
        }

        private void PrintmessageBarUpdate()
        {
            ProgressBar bar = compStats.GetStatBar(TagsEnum.RepLevel);
            Debug.unityLogger.Log("RepExp: " + bar.BarValue);
        }

        private void PrintmessageBarReset()
        {
            Debug.unityLogger.Log("Levelup");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.Stats[TagsEnum.RepLevel].Value);
        }
        
        private void PrintmessageBarRegress()
        {
            Debug.unityLogger.Log("Leveldown");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.Stats[TagsEnum.RepLevel].Value);
        }
    }
}
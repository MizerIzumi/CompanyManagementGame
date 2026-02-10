using UnityEngine;

namespace Game
{
    public class TestBroadcast : MonoBehaviour
    {
        [SerializeField] public CompanyStats compStats;
        [SerializeField] public AdventurerStats advStats;
        
        public Modifier mod;
        
        
        public void OnEnable()
        {
            ProgressBar bar = compStats.GetStatBar(TargetTags.CompRepLevel);
            
            bar.onBarUpdate += PrintmessageBarUpdate;
            bar.onBarReset += PrintmessageBarReset;
            bar.onBarRegress += PrintmessageBarRegress;
            
            //mod.Operation.DoOperation();
        }

        public void OnDisable()
        {
            ProgressBar bar = compStats.GetStatBar(TargetTags.CompRepLevel);
            
            bar.onBarUpdate -= PrintmessageBarReset;
            bar.onBarRegress -= PrintmessageBarRegress;
        }

        private void PrintmessageBarUpdate()
        {
            ProgressBar bar = compStats.GetStatBar(TargetTags.CompRepLevel);
            Debug.unityLogger.Log("RepExp: " + bar.BarValue);
        }

        private void PrintmessageBarReset()
        {
            Debug.unityLogger.Log("Levelup");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.StatsDictionary[TargetTags.CompRepLevel].Value);
        }
        
        private void PrintmessageBarRegress()
        {
            Debug.unityLogger.Log("Leveldown");
            Debug.unityLogger.Log("Company RepLevel: " + compStats.StatsDictionary[TargetTags.CompRepLevel].Value);
        }
    }
}
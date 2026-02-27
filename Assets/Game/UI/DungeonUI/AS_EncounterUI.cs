using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game
{
    public class AS_EncounterUI : ActionStack.ActionBehavior
    {
        public DungeonManager  dungeonManager;
        
        [Header("Local References")]
        [SerializeField]
        private GameObject _encounterUI;
        [SerializeField]
        private TextMeshProUGUI _encounterNameText;
        [SerializeField]
        private TextMeshProUGUI _adventurerNameText;
        [SerializeField]
        private TextMeshProUGUI _encounterDescriptionText;
        [SerializeField] 
        private Button _buttonA;
        [SerializeField]
        private TextMeshProUGUI _optionAText;
        [SerializeField] 
        private Button _buttonB;
        [SerializeField]
        private TextMeshProUGUI _optionBText;
        [SerializeField] 
        private Button _buttonC;
        [SerializeField]
        private TextMeshProUGUI _optionCText;
        [SerializeField] 
        private Button _buttonD;
        [SerializeField]
        private TextMeshProUGUI _optionDText;
        
        private Encounter _encounter;
        private bool _isDone = false;


        public override void OnBegin(bool bFirstTime)
        {
            base.OnBegin(bFirstTime);
            _isDone = false;
            EnableUI();
        }

        public void EnableUI()
        {
            gameObject.SetActive(true);
            _encounterUI.gameObject.SetActive(true);
            UpdateEncounter();
        }

        public void DisableUI()
        {
            _encounterUI.gameObject.SetActive(false);
            UnsubscribeFromEvents();
        }
        
        public void SetEncounter(Encounter newEncounter)
        {
            _encounter = newEncounter;
        }

        private void UpdateEncounter()
        {
            UpdateDisplayedText();
            UpdateButtons();
        }

        private void UpdateDisplayedText()
        {
            _encounterNameText.text = _encounter.encounterData.encounterName;
            _adventurerNameText.text = "- " +_encounter.adventurer.GetName();
            _encounterDescriptionText.text = _encounter.encounterData.encounterDescription;
            _optionAText.text = _encounter.encounterData.optionA.optionDescription + "\\n" + _encounter.SuccessChance(_encounter.encounterData.optionA) + "%";
            _optionBText.text = _encounter.encounterData.optionB.optionDescription + "\\n" + _encounter.SuccessChance(_encounter.encounterData.optionB) + "%";
            _optionCText.text = _encounter.encounterData.optionC.optionDescription + "\\n" + _encounter.SuccessChance(_encounter.encounterData.optionC) + "%";
            _optionDText.text = _encounter.encounterData.optionD.optionDescription + "\\n" + _encounter.SuccessChance(_encounter.encounterData.optionD) + "%";
        }

        private void UpdateButtons()
        {
            _buttonA.onClick.AddListener(OptionA);
            _buttonB.onClick.AddListener(OptionB);
            _buttonC.onClick.AddListener(OptionC);
            _buttonD.onClick.AddListener(OptionD);
        }

        private void UnsubscribeFromEvents()
        {
            _buttonA.onClick.RemoveAllListeners();
            _buttonB.onClick.RemoveAllListeners();
            _buttonC.onClick.RemoveAllListeners();
            _buttonD.onClick.RemoveAllListeners();
        }
        
        private void OptionA()
        {
            _encounter.ChooseOption(_encounter.encounterData.optionA);
            dungeonManager.EncounterResolved(_encounter);
            Exit();
        }
        
        private void OptionB()
        {
            _encounter.ChooseOption(_encounter.encounterData.optionB);
            dungeonManager.EncounterResolved(_encounter);
            Exit();
        }
        
        private void OptionC()
        {
            _encounter.ChooseOption(_encounter.encounterData.optionC);
            dungeonManager.EncounterResolved(_encounter);
            Exit();
        }
        
        private void OptionD()
        {
            _encounter.ChooseOption(_encounter.encounterData.optionD);
            dungeonManager.EncounterResolved(_encounter);
            Exit();
        }

        public void Exit()
        {
            _isDone = true;
        }
        
        public override bool IsDone()
        {
            return _isDone;
        }

        public override void OnEnd()
        {
            base.OnEnd();
            DisableUI();
        }
    }
}

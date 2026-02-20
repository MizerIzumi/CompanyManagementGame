using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class TimeUI : MonoBehaviour
    {
        [Header("Time Display")]
        [SerializeField] 
        private TextMeshProUGUI _dateDisplayText;
        private TimeManager.DaySlot _day;
        private TimeManager.MonthSlot _month;
        private TimeManager _timeManager;
        [SerializeField]
        private Animator _timepieceAnimator;
        [SerializeField]
        private List<string> _timePieceAnimationNames = new List<string>
        {
            "TA5",
            "TA1",
            "TA2",
            "TA3",
            "TA4"
        };
        
        public void Start()
        {
            _timeManager = GameManager.Instance.timeManager;

            _timeManager.OnTimeSlotChanged += AdvanceTimeUI;
            _timeManager.OnDaySlotChanged += UpdateDay;
            _timeManager.OnMonthSlotChanged += UpdateMonth;
        
            _day = _timeManager.CurrentDaySlot;
            _month = _timeManager.CurrentMonthSlot;
            UpdateTextDisplay();
        }

        private void AdvanceTimeUI(TimeManager.TimeSlot timeSlot)
        {
            _timepieceAnimator.Play(_timePieceAnimationNames[(int)timeSlot], 0, 0.0f);
        }

        private void UpdateDay(TimeManager.DaySlot day)
        {
            _day = day;
            UpdateTextDisplay();
        }

        private void UpdateMonth(TimeManager.MonthSlot month)
        {
            _month = month;
            UpdateTextDisplay();
        }
    
        private void UpdateTextDisplay()
        {
            _dateDisplayText.text = _day.ToString() + " " + _timeManager.dayOfTheMonth + " | " + _month.ToString();
        }
    }
}



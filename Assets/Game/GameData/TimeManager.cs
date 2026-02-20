using System;
using UnityEngine;

namespace Game
{
    public class TimeManager : MonoBehaviour
    {
        public event Action<TimeSlot> OnTimeSlotChanged;
        public event Action<DaySlot> OnDaySlotChanged;
        public event Action<WeekSlot> OnWeekSlotChanged;
        public event Action<MonthSlot> OnMonthSlotChanged;
        public event Action OnNewYear;
	    
        public enum TimeSlot
        {
            Morning,
            Midday,
            Afternoon,
            Evening,
            Night
        }

        public enum DaySlot
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum WeekSlot
        {
            Week1,
            Week2,
            Week3,
            Week4
        }

        public enum MonthSlot
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        public TimeSlot CurrentTimeSlot { get; private set; } = TimeSlot.Morning;
        public DaySlot CurrentDaySlot { get; private set; } = DaySlot.Monday;
        public WeekSlot CurrentWeekSlot { get; private set; } = WeekSlot.Week1;
        public MonthSlot CurrentMonthSlot { get; private set; } = MonthSlot.Spring;
        
        // 5 time slots per day, 7 days in a week, 4 weeks in a month and 4 months in a year
        //This means 28 days in a month and 112 days in a year

        public int totalYearsPassed = 0;
        public int totalDaysPassed = 0;
        public int dayOfTheMonth = 1;


        public void SkipDay()
        {
            if (CurrentTimeSlot == TimeSlot.Morning)
            {
                AdvanceDay();
            }
            while (CurrentTimeSlot != TimeSlot.Morning)
            {
                AdvanceTime();
            }
        }

        public void SkipWeek()
        {
            if (CurrentDaySlot == DaySlot.Monday)
            {
                SkipDay();
            }
            while (CurrentDaySlot != DaySlot.Monday)
            {
                SkipDay();
            }
        }

        public void SkipMonth()
        {
            if (CurrentWeekSlot == WeekSlot.Week1)
            {
                SkipWeek();
            }

            while (CurrentWeekSlot != WeekSlot.Week1)
            {
                SkipWeek();
            }
        }
        
        
        public void AdvanceTime()
        {
            int next = ((int)CurrentTimeSlot + 1) % Enum.GetValues(typeof(TimeSlot)).Length;
            if ((int)(TimeSlot)next == 0)
            {
                AdvanceDay();
            }
            SetTimeSlot((TimeSlot)next);
        }

        private void SetTimeSlot(TimeSlot newSlot)
        {
            CurrentTimeSlot = newSlot;
            OnTimeSlotChanged?.Invoke(CurrentTimeSlot);
        }

        private void AdvanceDay()
        {
            int next = ((int)CurrentDaySlot + 1) % Enum.GetValues(typeof(DaySlot)).Length;
            if ((int)(DaySlot)next == 0)
            {
                AdvanceWeek();
            }
            totalDaysPassed++;
            dayOfTheMonth = (dayOfTheMonth + 1) % 29;
            if (dayOfTheMonth == 0) dayOfTheMonth = 1;
            
            SetDaySlot((DaySlot)next);
        }

        private void SetDaySlot(DaySlot newSlot)
        {
            CurrentDaySlot = newSlot;
            OnDaySlotChanged?.Invoke(CurrentDaySlot);
        }

        private void AdvanceWeek()
        {
            int next = ((int)CurrentWeekSlot + 1) % Enum.GetValues(typeof(WeekSlot)).Length;
            if ((int)(WeekSlot)next == 0)
            {
                AdvanceMonth();
            }
            SetWeekSlot((WeekSlot)next);
        }

        private void SetWeekSlot(WeekSlot newSlot)
        {
            CurrentWeekSlot = newSlot;
            OnWeekSlotChanged?.Invoke(CurrentWeekSlot);
        }

        private void AdvanceMonth()
        {
            int next = ((int)CurrentMonthSlot + 1) % Enum.GetValues(typeof(MonthSlot)).Length;
            if ((int)(MonthSlot)next == 0)
            {
                totalYearsPassed++;
                OnNewYear?.Invoke();
            }
            SetMonthSlot((MonthSlot)next);
        }

        private void SetMonthSlot(MonthSlot newSlot)
        {
            CurrentMonthSlot = newSlot;
            OnMonthSlotChanged?.Invoke(CurrentMonthSlot);
        }
    }
}

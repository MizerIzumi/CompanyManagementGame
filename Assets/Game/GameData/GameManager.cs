using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
    public int seed = 0;
    
    // 5 time slots per day, 7 days in a week, 4 weeks in a month and 4 months in a year
    //This means 28 days in a month and 112 days in a year
    
    private void Awake()
    {
        if (seed == 0)
        {
            //Generates a unique seed every time
            seed = System.Environment.TickCount + System.DateTime.Now.Millisecond + System.Guid.NewGuid().GetHashCode();
            Random.InitState(seed);
        }
        print("Game Seed: " + seed);
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
	    print("Time changed to: " + CurrentTimeSlot);
    }

    private void AdvanceDay()
    {
	    int next = ((int)CurrentDaySlot + 1) % Enum.GetValues(typeof(DaySlot)).Length;
	    if ((int)(DaySlot)next == 0)
	    {
		    AdvanceWeek();
	    }
	    SetDaySlot((DaySlot)next);
    }

    private void SetDaySlot(DaySlot newSlot)
    {
	    CurrentDaySlot = newSlot;
	    OnDaySlotChanged?.Invoke(CurrentDaySlot);
	    print("Current day: " + CurrentDaySlot);
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
	    print("Current week: " + CurrentWeekSlot);
    }

    private void AdvanceMonth()
    {
	    int next = ((int)CurrentMonthSlot + 1) % Enum.GetValues(typeof(MonthSlot)).Length;
	    if ((int)(MonthSlot)next == 0)
	    {
		    OnNewYear?.Invoke();
	    }
	    SetMonthSlot((MonthSlot)next);
    }

    private void SetMonthSlot(MonthSlot newSlot)
    {
	    CurrentMonthSlot = newSlot;
	    OnMonthSlotChanged?.Invoke(CurrentMonthSlot);
	    print("Current month: " + CurrentMonthSlot);
    }
}

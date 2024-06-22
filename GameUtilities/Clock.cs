public class Clock
{
    public int Year { get; set; } = 448;
    public int Month { get; set; } = 3;
    public int Day { get; set; } = 6;
    public string TimeOfDay { get; set; } = "Morning";
    public void AdvanceClock(int NumberOfDays = 0)
    {
        HandleTimeOfDay(NumberOfDays);
        HandleDay();
        HandleMonth();
    }
    public void HandleTimeOfDay(int NumberOfDays)
    {
        if(NumberOfDays == 0)
        {
            if(TimeOfDay == "Morning")
            {
                TimeOfDay = "Evening";
            }
            else
            {
                TimeOfDay = "Morning";
                Day++;
            }
        }
        else
        {
            TimeOfDay = "Morning";
            Day+=NumberOfDays;
        }
    }
    public void HandleDay()
    {
        if(Day > 28)
        {
            Month++;
            Day = Day-28;
        }
    }
    public void HandleMonth()
    {
        if(Month > 16)
        {
            Year++;
            Month = Month-16;
        }
    }
    public void ShowClock(bool Pause)
    {
        Console.WriteLine($"{TimeOfDay} on day {Day} of the {Month}{GetMonthPostScript()} month, in year {Year}");
        if(Pause)
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
    private string GetMonthPostScript()
    {
        int Digit = 0;
        string PostScript = string.Empty;
        if(Month<10)
        {
            Digit = Month;
        }
        else if(Month<20)
        {
            Digit = Month-10;
        }
        else
        {
            Digit = Month-20;
        }
        switch(Digit)
        {
            default: PostScript = "th"; break;
            case 1 : PostScript = "st"; break;
            case 2 : PostScript = "nd"; break;
            case 3 : PostScript = "rd"; break;
            
        }
        if(Month == 11)
        {
            PostScript = "th";
        }
        else if(Month == 12)
        {
            PostScript = "th";
        }
        else if(Month == 13)
        {
            PostScript = "th";
        }
        return PostScript;
    }
}
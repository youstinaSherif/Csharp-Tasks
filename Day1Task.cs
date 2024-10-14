using System;

public class Duration
{
    private int hours;
    private int minutes;
    private int seconds;
    
    public Duration(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        NormalizeTime();
    }

    public Duration(int totalSeconds)
    {
        this.hours = totalSeconds / 3600;
        this.minutes = (totalSeconds % 3600) / 60;
        this.seconds = totalSeconds % 60;
    }

    private void NormalizeTime()
    {
        if (seconds >= 60)
        {
            minutes += seconds / 60;
            seconds %= 60;
        }

        if (minutes >= 60)
        {
            hours += minutes / 60;
            minutes %= 60;
        }
    }

    public string GetString()
    {
        string result = "";

        if (hours > 0)
        {
            result += $"Hours: {hours}, ";
        }

        if (minutes > 0 || hours > 0)
        {
            result += $"Minutes: {minutes}, ";
        }

        result += $"Seconds: {seconds}";

        return result;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Duration D1 = new Duration(1, 10, 15);
        Console.WriteLine(D1.GetString());
        
        Duration D2 = new Duration(3600);
        Console.WriteLine(D2.GetString());
        
        Duration D3 = new Duration(7800);
        Console.WriteLine(D3.GetString());
        
        Duration D4 = new Duration(666);
        Console.WriteLine(D4.GetString());
    }
}

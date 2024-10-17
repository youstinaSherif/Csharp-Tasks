using System;

public class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Normalize();
    }
    
    private void Normalize()
    {
        Minutes += Seconds / 60;
        Seconds %= 60;

        Hours += Minutes / 60;
        Minutes %= 60;
    }

    public override string ToString()
    {
        return $"{Hours}H:{Minutes}M:{Seconds}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Duration other)
        {
            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }
        return false;
    }

    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
    }

    public static Duration operator +(Duration d, int seconds)
    {
        return new Duration(d.Hours, d.Minutes, d.Seconds + seconds);
    }

    public static Duration operator +(int seconds, Duration d)
    {
        return d + seconds;
    }

    public static Duration operator ++(Duration d)
    {
        return new Duration(d.Hours, d.Minutes + 1, d.Seconds);
    }
    
    public static Duration operator --(Duration d)
    {
        return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
    }
    
    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
    }

    private int ToTotalSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Duration D1 = new Duration(2, 30, 45);
        Duration D2 = new Duration(1, 45, 15);
        
        Duration D3 = D1 + D2; 
        Console.WriteLine(D3); 
        
        D3 = 666 + D3; 
        Console.WriteLine(D3); 

        D3 = D1++; 
        Console.WriteLine(D3); 

        D3 = --D2; 
        Console.WriteLine(D3); 

        if (D1 <= D2)
        {
            Console.WriteLine("D1 is less than or equal to D2.");
        }
        else
        {
            Console.WriteLine("D1 is greater than D2.");
        }
    }
}

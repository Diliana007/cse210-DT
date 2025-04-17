using System;

public class Cycling : Activity
{
    // Unique attribute for Cycling: the provided speed.
    private double _speed; // in kilometers per hour (kph)

    public Cycling(string date, int duration, double speed)
        : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // Compute the distance using the provided speed and duration.
        double hours = _duration / 60.0;
        return _speed * hours;
    }

    public override double GetSpeed() => _speed;

    public override double GetPace()
    {
        // Pace (min per km) is total duration divided by the computed distance.
        return _duration / GetDistance();
    }

    // Overriding GetSummary to display a Cycling-specific summary.
    public override string GetSummary()
    {
        return $"{_date} Cycling ({_duration} min): Distance: {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
// This class represents a cycling activity. It inherits from the Activity class and implements the methods to calculate distance, speed, and pace specific to cycling.
// The GetSummary method is overridden to provide a detailed summary of the cycling activity, including the date, duration, distance, speed, and pace.

using System;

public class Running : Activity
{
    // Unique attribute for Running: the distance covered.
    private double _distance; // in kilometers

    public Running(string date, int duration, double distance)
        : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        // Speed in kph = distance / (duration in hours)
        double hours = _duration / 60.0;
        return _distance / hours;
    }

    public override double GetPace() => _duration / _distance;

    // Overriding GetSummary to include the activity type.
    public override string GetSummary()
    {
        return $"{_date} Running ({_duration} min): Distance: {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
// This class represents a running activity. It inherits from the Activity class and implements the methods to calculate distance, speed, and pace specific to running.
// The GetSummary method is overridden to provide a detailed summary of the running activity, including the date, duration, distance, speed, and pace.
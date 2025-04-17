using System;

public class Swimming : Activity
{
    // Unique attribute for Swimming: number of laps.
    private int _laps;
    // Each lap is 50 meters, which converts to 0.05 kilometers.
    private const double LapDistance = 50.0 / 1000.0; // 0.05 km per lap

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapDistance;

    public override double GetSpeed()
    {
        double hours = _duration / 60.0;
        return GetDistance() / hours;
    }

    public override double GetPace() => _duration / GetDistance();

    // Overriding GetSummary to produce a Swimming-specific summary.
    public override string GetSummary()
    {
        return $"{_date} Swimming ({_duration} min): Distance: {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
// This class represents a swimming activity. It inherits from the Activity class and implements the methods to calculate distance, speed, and pace specific to swimming.
// The GetSummary method is overridden to provide a detailed summary of the swimming activity, including the date, duration, distance, speed, and pace.

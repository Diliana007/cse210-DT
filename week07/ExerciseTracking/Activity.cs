using System;

public abstract class Activity
{
    // Protected members so that derived classes can access them.
    protected string _date;
    protected int _duration; // Duration in minutes

    public Activity(string date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    // Abstract methods that must be implemented by derived classes.
    public abstract double GetDistance(); // Returns distance in kilometers.
    public abstract double GetSpeed();    // Returns speed in kilometers per hour (kph).
    public abstract double GetPace();     // Returns pace in minutes per kilometer.

    // Virtual method for summary. This can be overridden if needed.
    public virtual string GetSummary()
    {
        return $"{_date} ({_duration} min): Distance: {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
// This class serves as a base class for different types of activities. It contains common properties and methods that can be shared across derived classes.
// The class includes an abstract method for calculating distance, speed, and pace, which must be implemented by any derived classes.
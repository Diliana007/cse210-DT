using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Create one instance of each activity type.
        Activity running = new Running("03 Nov 2022", 30, 4.8);
        Activity cycling = new Cycling("03 Nov 2022", 45, 20.0);
        Activity swimming = new Swimming("03 Nov 2022", 60, 30);

        // Add all activities to a single list.
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Iterate over the list and output the summary for each activity.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
// This program creates instances of different types of activities (Running, Cycling, Swimming) and stores them in a list. It then iterates over the list to print a summary of each activity, demonstrating polymorphism in action. Each activity type provides its own implementation of the GetSummary method, allowing for a unified interface while maintaining specific behavior.
// The program showcases the use of inheritance and polymorphism in C# by allowing different activity types to be treated uniformly while still providing their own specific details.
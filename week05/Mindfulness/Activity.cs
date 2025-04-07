using System;
using System.Threading;

public abstract class Activity
{
    protected int duration;
    protected string name;
    protected string description;

    public void Run()
    {
        ShowStartingMessage();
        PrepareToBegin();
        PerformActivity();
        ShowEndingMessage();
    }

    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting{name}");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds:");
        duration = int.Parse(Console.ReadLine());
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {name} for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        } 
        Console.WriteLine();
    }
    protected abstract void PerformActivity();

}
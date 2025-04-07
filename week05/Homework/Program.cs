using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading; 

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1.Breathing Activity");
            Console.WriteLine("2.Reflection Activity");
            Console.WriteLine("3.ListingActivity");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Choose an activity:");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch(choice)
            {
                case "1":
                    activity=new BreathingActivity();
                    break;
                case "2":
                    activity=new ReflectionActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.Please try again.");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.Run();
        }
    }
}

abstract class Activity

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

class BreathingActivity : Activity

{
    public BreathingActivity()

    {
        name = "Breathing Activity";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int remainingTime = duration;
        while (remainingTime > 0)
        {
            Console.WriteLine("Breath in...");
            ShowCountdown(4);
            remainingTime -= 4;
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string>prompts = new List<string>

    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
        
    };

    private List<string> questions = new List<string>

    {
        "Why was this experience meaninful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not a successful",
        "What is your favorite thing about this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection Activity";
        description = "This activity will help you to reflect on times in your life when you have shown strength and resilence.This will help you recognize the power you have and how you can use it in other aspects of your life.";

    }

    protected override void PerformActivity()

    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in:");
        ShowCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now < endTime)

        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(questions);
            ShowSpinner(5);
        }

    }

}

class ListingActivity : Activity

{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you are helped this week?",
        "When you have felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity()
    {
        name = "Listing Activity";
        description = "This actiity will help you reflect on the good things in your life by having you list as many things as you can in a certain area,";
        
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now <endTime)
        {
            Console.Write(">");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}
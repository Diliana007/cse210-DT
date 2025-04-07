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
                case  "3":
                    activity=new ListingActivity();
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
        while(DateTime.Now < endTime)
        {
            Console.Write(">");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}
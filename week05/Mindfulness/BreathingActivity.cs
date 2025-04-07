public class BreathingActivity : Activity

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
            Console.WriteLine("Breath out...");
            ShowCountdown(4);
            remainingTime -= 8;
        }
    }
}


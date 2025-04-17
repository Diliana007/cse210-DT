 namespace EternalQuest // ChecklistGoal class (requires multiple completions)
 {
    public class ChecklistGoal : Goal
    {
        public int CurrentCount { get; private set; }
        public int TargetCount { get; }
        public int BonusPoints { get; }

        public ChecklistGoal(string name, string description, int points, 
                            int targetCount, int bonusPoints) 
            : base(name, description, points)
        {
            TargetCount = targetCount;
            CurrentCount = 0;
            BonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
                
                if (CurrentCount == TargetCount)
                {
                    IsComplete = true;
                    Points += BonusPoints; // Apply bonus
                }
            }
        }

        public override string GetProgress() => IsComplete ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
        public override string GetDisplayString() => $"{GetProgress()} {Name} ({Description}) -- Currently completed: {CurrentCount}/{TargetCount}";
    }
} // This class represents a goal that requires multiple completions. It inherits from the Goal class and overrides the necessary methods to provide its own functionality. The RecordEvent method increments the current count and checks if the goal is complete. The GetProgress method returns a string indicating the current progress, and the GetDisplayString method formats the display string for the checklist goal.
// The ChecklistGoal class is a concrete implementation of the Goal class, representing a goal that can be completed multiple times. It includes properties for the current count, target count, and bonus points. The RecordEvent method increments the current count and checks if the goal is complete, applying bonus points if applicable. The GetProgress method returns a string indicating the current progress, and the GetDisplayString method formats the display string for the checklist goal.
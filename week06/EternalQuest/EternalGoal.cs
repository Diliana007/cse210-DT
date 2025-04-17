namespace EternalQuest
{
public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            // Eternal goals never complete
        }

        public override string GetProgress() => "[∞]";
        public override string GetDisplayString() => $"{GetProgress()} {Name} ({Description})";
    }
}
// This class represents a goal that can be completed multiple times. It inherits from the Goal class and overrides the necessary methods to provide its own functionality. The RecordEvent method is intentionally left empty, as eternal goals do not complete. The GetProgress method returns a string indicating that the goal is eternal, and the GetDisplayString method formats the display string for the eternal goal.

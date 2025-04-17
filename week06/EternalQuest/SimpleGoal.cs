namespace EternalQuest
{
    // SimpleGoal class (one-time completion)
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
            }
        }

        public override string GetProgress() => IsComplete ? "[X]" : "[ ]";
        public override string GetDisplayString() => $"{GetProgress()} {Name} ({Description})";
    }
}
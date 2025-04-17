using System;
namespace EternalQuest // Base abstract Goal class
{
    public abstract class Goal
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; protected set; }

        protected Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        public abstract void RecordEvent();
        public abstract string GetProgress();
        public abstract string GetDisplayString();
    }
} 
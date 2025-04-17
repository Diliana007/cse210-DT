namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalPoints;
        private int _level;
        private List<string> _achievements;

        private Dictionary<int, string> _levelNames = new Dictionary<int, string>
        {
            {1, "Beginner"}, {5, "Novice"}, {10, "Intermediate"},
            {20, "Advanced"}, {30, "Expert"}, {50, "Master"}
        };

        public GoalManager()
        {
            _goals = new List<Goal>();
            _totalPoints = 0;
            _level = 1;
            _achievements = new List<string>();
        }

        public void Start()
        {
            LoadData();

            while (true)
            {
                DisplayStatus();

                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Goal Event");
                Console.WriteLine("4. Save Progress");
                Console.WriteLine("5. Load Progress");
                Console.WriteLine("6. Quit");

                Console.Write("Select a choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveData();
                        break;
                    case "5":
                        LoadData();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ListGoals()
        {
            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
            }

            if (_achievements.Count > 0)
            {
                Console.WriteLine("\nAchievements:");
                foreach (var achievement in _achievements)
                {
                    Console.WriteLine($"★ {achievement}");
                }
            }

            Console.ReadKey();
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                Console.ReadKey();
                return;
            }

            ListGoals();
            Console.Write("\nWhich goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                Goal selectedGoal = _goals[goalIndex];
                int pointsBefore = selectedGoal.Points;
                selectedGoal.RecordEvent();

                _totalPoints += pointsBefore;

                CheckLevelUp();
                CheckAchievements();

                Console.WriteLine($"\nCongratulations! You earned {pointsBefore} points!");

                if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete)
                {
                    Console.WriteLine($"Bonus achieved! You earned an additional {checklist.BonusPoints} points!");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }

            Console.ReadKey();
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("goals.txt"))
                {
                    writer.WriteLine(_totalPoints);
                    writer.WriteLine(_level);
                    writer.WriteLine(string.Join("|", _achievements));

                    foreach (Goal goal in _goals)
                    {
                        string goalType = goal.GetType().Name;
                        string goalData = $"{goalType},{goal.Name},{goal.Description},{goal.Points},{goal.IsComplete}";

                        if (goal is ChecklistGoal checklist)
                        {
                            goalData += $",{checklist.CurrentCount},{checklist.TargetCount},{checklist.BonusPoints}";
                        }

                        writer.WriteLine(goalData);
                    }
                }

                Console.WriteLine("Progress saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void LoadData()
        {
            if (!File.Exists("goals.txt")) return;

            try
            {
                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    _totalPoints = int.Parse(reader.ReadLine());
                    _level = int.Parse(reader.ReadLine());
                    _achievements = new List<string>(reader.ReadLine().Split('|'));

                    _goals = new List<Goal>();
                    while (!reader.EndOfStream)
                    {
                        string[] goalParts = reader.ReadLine().Split(',');
                        string goalType = goalParts[0];

                        string name = goalParts[1];
                        string description = goalParts[2];
                        int points = int.Parse(goalParts[3]);
                        bool isComplete = bool.Parse(goalParts[4]);

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                var simpleGoal = new SimpleGoal(name, description, points);
                                if (isComplete) simpleGoal.RecordEvent();
                                _goals.Add(simpleGoal);
                                break;

                            case "EternalGoal":
                                _goals.Add(new EternalGoal(name, description, points));
                                break;

                            case "ChecklistGoal":
                                int current = int.Parse(goalParts[5]);
                                int target = int.Parse(goalParts[6]);
                                int bonus = int.Parse(goalParts[7]);

                                var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                                for (int i = 0; i < current; i++) checklistGoal.RecordEvent();
                                _goals.Add(checklistGoal);
                                break;
                        }
                    }
                }

                Console.WriteLine("Progress loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }

            Console.ReadKey();
        }

        private void CheckLevelUp()
        {
            int requiredPoints = _level * 1000;
            if (_totalPoints >= requiredPoints)
            {
                _level++;
                string levelTitle = _levelNames.ContainsKey(_level) ? _levelNames[_level] : "Legendary";
                Console.WriteLine($"\n★ LEVEL UP! You are now level {_level} ({levelTitle}) ★");

                _achievements.Add($"Reached Level {_level}");
            }
        }

        private void CheckAchievements()
        {
            int completedCount = _goals.Count(g => g.IsComplete);

            if (completedCount >= 3 && !_achievements.Contains("Triple Goal Achiever"))
            {
                _achievements.Add("Triple Goal Achiever");
                Console.WriteLine("★ Earned Achievement: Triple Goal Achiever!");
            }

            if (completedCount >= 10 && !_achievements.Contains("Deca-Goal Master"))
            {
                _achievements.Add("Deca-Goal Master");
                Console.WriteLine("★ Earned Achievement: Deca-Goal Master!");
            }

            if (_totalPoints >= 5000 && !_achievements.Contains("5000 Points Club"))
            {
                _achievements.Add("5000 Points Club");
                Console.WriteLine("★ Earned Achievement: 5000 Points Club!");
            }
        }

        private void DisplayStatus()
        {
            Console.WriteLine($"Total Points: {_totalPoints}");
            string levelTitle = _levelNames.ContainsKey(_level) ? _levelNames[_level] : "Legendary";
            Console.WriteLine($"Level: {_level} ({levelTitle})");

            int pointsToNextLevel = _level * 1000 - _totalPoints;
            if (pointsToNextLevel <= 0)
            {
                Console.WriteLine("★ You are at max level! No more levels to achieve.");
            }
            else
            {
                Console.WriteLine($"Points to next level: {pointsToNextLevel}");
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("\nCreating a new goal...");
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (requires multiple completions)");

            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int points))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name ?? "Unnamed", description ?? "No description", points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name ?? "Unnamed", description ?? "No description", points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid input for target.");
                        return;
                    }

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid input for bonus.");
                        return;
                    }

                    _goals.Add(new ChecklistGoal(name ?? "Unnamed", description ?? "No description", points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
            Console.WriteLine("Goal created successfully!");
            Console.WriteLine("Press Enter to continue...");
            ReadInput();
        }

        private string ReadInput()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Console input is not available. Using default value.");
                return "Default";
            }
        }
    }
}
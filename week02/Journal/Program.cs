using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
       Journal journal = new Journal();
       PromptGenerator promptGenerator = new PromptGenerator();
       bool exitApp = false; //Controls the loop
       string choice; // Stores the user's choice

       while (!exitApp)
       {
            //Dispaly the menu
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Display the Journal.");
            Console.WriteLine("3. Save the Journal to a file.");
            Console.WriteLine("4.Load the Journal from a file");
            Console.WriteLine("0.Quit");
            Console.WriteLine("What would you like to do?");

            choice = Console.ReadLine(); // Read user input

            // Handle user choice
            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.WriteLine($"Your choice is: {choice}. Write a new enty.");
                    string response = Console.ReadLine();
                    string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
                    // Add logic for writting a new entry
                    Entry newEntry = new Entry
                    {
                        _date = currentDate,
                        _promptText = prompt,
                        _entryText = response
                    };
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case "2":
                    Console.WriteLine($"Your choice is: {choice}.Display the Journal.");
                    journal.DisplayAll();
                    // Add logic for displaying the journal
                    break;

                case "3":
                    Console.WriteLine($"Your choice is: {choice}.Save the Journal to a file.");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully!\n");
                    // Add logic for saving the Journal
                    break;

                case "4":
                    Console.WriteLine($"Your choice is: {choice}.Load the Journal from a file.");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully!\n");
                    // Add logic for loading the Journal
                    break;

                case "0":
                    Console.WriteLine($"Your choice is: {choice}.Exit.");
                    exitApp = true; // Set exitApp to true to end the loop
                    break;
                default:
                    Console.WriteLine("Invalid choice try again."); // Handle invalid input
                    break;  
            }
        }

        Console.WriteLine("Aplication has exited.");
        
    }

}
using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
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
                    Console.WriteLine($"Your choice is: {choice}. Write a new enty.");
                    // Add logic for writting a new entry
                    break;
                case "2":
                    Console.WriteLine($"Your choice is: {choice}.Display the Journal.");
                    // Add logic for displaying the journal
                    break;
                case "3":
                    Console.WriteLine($"Your choice is: {choice}.Save the Journal to a file.");
                    // Add logic for saving the Journal
                    break;
                case "4":
                    Console.WriteLine($"Your choice is: {choice}.Load the Journal from a file.");
                    // Add logic for loading the Journal
                    break;
                case "0":
                    Console.WriteLine($"Your choice is: {choice}.Exit.");
                    exitApp = true; // Set exitApp to true to end the loop
                    break;
                default:
                    Console.WriteLine("Invalid choice try again."); // Handle invalid inputn
                    break;  
            }
        }

        Console.WriteLine("Aplication has exited");
        
    }

}
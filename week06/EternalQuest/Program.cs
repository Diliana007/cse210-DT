//Exceed requirements by leveling system, achivements and badges and visual feedback
using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("This program helps you track and achieve your personal goals.");

            try
            {
                GoalManager manager = new GoalManager();
                manager.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using Eternal Quest. Goodbye!");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
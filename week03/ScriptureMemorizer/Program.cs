using System;

class Program
{
    static void Main(string[] args)
    {
       Reference reference = new Reference("Proverbs", 3,5,6);
       Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding");

       while (!scripture.IsCompletelyHidden())
       {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2); // Hide two random words per turn
       }

       Console.WriteLine("\nProgram Ended. Final Scripture:");
       Console.WriteLine(scripture.GetDisplayText());

    }
}
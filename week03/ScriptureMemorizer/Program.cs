using System;

class Program
{
    static void Main(string[] args)
    {
       Reference reference = new Reference("Proverbs", 3,5,6);
       Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding");

       while (!scripture.IsCompletelyHidden())
        {
            while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nEnter the number of words to hide or type 'quit' to exit:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            if (int.TryParse(input, out int numberToHide) && numberToHide > 0)
            {
                scripture.HideRandomWords(numberToHide); // Hides user-specified number of words
            }
            else
            {
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
}

        }

       Console.WriteLine("\nProgram Ended. Final Scripture:");
       Console.WriteLine(scripture.GetDisplayText());
       Console.WriteLine($"Progress: {scripture.GetHiddenPercentage():F2}% of words hidden\n");
        }
    }
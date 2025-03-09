using System;
using System.Collections.Generic;

class Program
{ 
    static void Main(string[] args)
    {    
        List<int> numbers = new List<int>(); // Create empty list to store numbers
        int userNumber = -1; //Initialize with dummy value to enter loop

        while (userNumber !=0) //Loop until user enter 0
        {
            Console.Write("Enter a number (0 to quit): " ); //show prompt
            string userResponse = Console.ReadLine(); //Get user input  as string
            userNumber = int.Parse(userResponse); //Convert input to integer

            if (userNumber !=0)// only add non Zero numbers
            {
                numbers.Add(userNumber); // Add numbers to the list
            }

            int sum = 0; // Reset sum for each interaction
            foreach (int number in numbers) // Loop through all numbers
            {
                sum += number;   // Acummulate total summ
            } 
            Console.WriteLine($"The sum is: {sum}"); // Show current sum

            if (numbers.Count > 0) //Safety check for empty list
            {
                int max = numbers[0]; // start with first number as max
                foreach (int number in numbers)// Check all numbers 
                {
                  if  (number > max) // Compare with current max
                  {
                       max = number; //Update max if larger number found
                  }
                } 
                Console.WriteLine($"The max is: {max}");// Show current
            }
        }  
    
    }

}
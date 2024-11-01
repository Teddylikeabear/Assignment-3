using System; 
using System.Collections.Generic;

namespace Assignment_3
{
    public class NumberToWordsDictionary
    {
        // Dictionary to store words for numbers from 0 to 19, and multiples of 10 up to 90
        private static readonly Dictionary<int, string> NumWords = new Dictionary<int, string>
    {
        { 0, "Zero" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" },
        { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" },
        { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" },
        { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" },
        { 18, "Eighteen" }, { 19, "Nineteen" }, { 20, "Twenty" }, { 30, "Thirty" },
        { 40, "Forty" }, { 50, "Fifty" }, { 60, "Sixty" }, { 70, "Seventy" },
        { 80, "Eighty" }, { 90, "Ninety" }
    };

        // Method to convert a number into words
        public static string ConvertToWords(int number)
        {
            if(number == 0)
        return NumWords[0];

            string words = "";

            for (int placeValue = 1000; placeValue > 0; placeValue /= 10)
            {
                if (placeValue == 1000 && number >= 1000)
                {
                    // Handle thousands place
                    words += NumWords[number / 1000] + " Thousand";
                    number %= 1000;
                    if (number > 0)
                        words += " ";
                }
                else if (placeValue == 100 && number >= 100)
                {
                    // Handle hundreds place
                    words += NumWords[number / 100] + " Hundred";
                    number %= 100;
                    if (number > 0)
                        words += " ";
                }
                else if (placeValue == 10 && number >= 20)
                {
                    // Handle tens place for numbers 20 and above
                    words += NumWords[number / 10 * 10];
                    number %= 10;
                    if (number > 0)
                        words += "-";
                }
                else if (number > 0 && NumWords.ContainsKey(number))
                {
                    // Handle numbers less than 20 or single digits
                    words += NumWords[number];
                    break;
                }
            }

            return words;
        }

        public static void Main()
        {
            // Prompt the user 
            Console.Write("Enter a number (up to 4 digits): ");

            // Read user input and convert it to  int
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 0 && number <= 9999)
            {
                
                Console.WriteLine("In words: " + ConvertToWords(number));
            }
            else
            {
                // Handle invalid input
                Console.WriteLine("Please enter a valid number between 0 and 9999.");
            }
        }

    }
}
using System;

namespace DCIT318Assignment1
{
    class GradeCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Grade Calculator ============");
            Console.WriteLine("Enter a numerical grade between 0 and 100:");
            
            // Read user input
            string input = Console.ReadLine();
            
            // Try to parse the input as a double
            double grade;
            if (double.TryParse(input, out grade))
            {
                // Validate grade range
                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Error: Grade must be between 0 and 100.");
                }
                else
                {
                    // Determine letter grade
                    string letterGrade = GetLetterGrade(grade);
                    Console.WriteLine("Grade: " + grade);
                    Console.WriteLine("Letter Grade: " + letterGrade);
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid numerical grade.");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Converts a numerical grade to a letter grade
        /// </summary>
        /// <param name="grade">Numerical grade between 0 and 100</param>
        /// <returns>Letter grade (A, B, C, D, or F)</returns>
        static string GetLetterGrade(double grade)
        {
            if (grade >= 90)
                return "A";
            else if (grade >= 80)
                return "B";
            else if (grade >= 70)
                return "C";
            else if (grade >= 60)
                return "D";
            else
                return "F";
        }
    }
}

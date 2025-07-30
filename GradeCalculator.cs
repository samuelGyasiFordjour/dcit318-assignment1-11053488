using System;

namespace DCIT318Assignment1
{
    class GradeCalculator
    {
        static void Main(string[] args)
        {
            try
            {
                ShowWelcomeMessage();
                RunMainMenu();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Critical Error: The system is out of memory. The program will exit.");
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Critical Error: Stack overflow occurred. The program will exit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical Error: " + ex.Message);
                Console.WriteLine("The program will exit.");
            }
            finally
            {
                try
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    // Silent catch for console operations that might fail
                    System.Threading.Thread.Sleep(2000); // Wait 2 seconds before exit
                }
            }
        }
        
        /// <summary>
        /// Displays welcome message
        /// </summary>
        static void ShowWelcomeMessage()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("       WELCOME TO GRADE CALCULATOR         ");
            Console.WriteLine("============================================");
            Console.WriteLine();
        }
        
        /// <summary>
        /// Runs the main menu system
        /// </summary>
        static void RunMainMenu()
        {
            bool continueProgram = true;
            
            while (continueProgram)
            {
                try
                {
                    // Display menu options
                    Console.WriteLine("============ MAIN MENU ============");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Calculate Grade");
                    Console.WriteLine("2. View Grade Scale");
                    Console.WriteLine("3. Exit Application");
                    Console.WriteLine("===================================");
                    Console.Write("Enter your choice (1-3): ");
                    
                    string choice = Console.ReadLine();
                    
                    // Handle null or empty input
                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("Error: Please enter a valid option (1-3).");
                        Console.WriteLine();
                        continue;
                    }
                    
                    choice = choice.Trim();
                    
                    switch (choice)
                    {
                        case "1":
                            CalculateGrade();
                            break;
                        case "2":
                            ShowGradeScale();
                            break;
                        case "3":
                            Console.WriteLine("Thank you for using Grade Calculator!");
                            continueProgram = false;
                            break;
                        default:
                            Console.WriteLine("Error: Invalid option. Please enter 1, 2, or 3.");
                            break;
                    }
                    
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred in the main menu: " + ex.Message);
                    Console.WriteLine("Returning to main menu...");
                    Console.WriteLine();
                }
            }
        }
        
        /// <summary>
        /// Handles grade calculation functionality
        /// </summary>
        static void CalculateGrade()
        {
            bool continueCalculating = true;
            
            while (continueCalculating)
            {
                try
                {
                    Console.WriteLine("============ Grade Calculator ============");
                    Console.WriteLine("Enter a numerical grade between 0 and 100:");
                    
                    // Read user input with null check
                    string input = Console.ReadLine();
                    
                    // Check for null or empty input
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty. Please enter a numerical grade.");
                        continue;
                    }
                    
                    // Try to parse the input as a double
                    double grade;
                    if (double.TryParse(input, out grade))
                    {
                        // Check for special values
                        if (double.IsNaN(grade))
                        {
                            Console.WriteLine("Error: Invalid number format. Please enter a valid numerical grade.");
                            continue;
                        }
                        
                        if (double.IsInfinity(grade))
                        {
                            Console.WriteLine("Error: Number is too large. Please enter a grade between 0 and 100.");
                            continue;
                        }
                        
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
                            Console.WriteLine("Performance: " + GetPerformanceDescription(letterGrade));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid numerical grade.");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: Invalid input format. Please enter a numerical value.");
                    Console.WriteLine("Details: " + ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error: The number entered is too large or too small.");
                    Console.WriteLine("Details: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: Invalid argument provided.");
                    Console.WriteLine("Details: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    Console.WriteLine("The calculation will continue...");
                }
                
                try
                {
                    // Ask user if they want to calculate another grade
                    Console.WriteLine("\nDo you want to calculate another grade? (y/n): ");
                    string choice = Console.ReadLine();
                    
                    // Handle null input for choice
                    if (choice == null)
                    {
                        Console.WriteLine("No input received. Returning to main menu...");
                        continueCalculating = false;
                    }
                    else
                    {
                        choice = choice.ToLower().Trim();
                        if (choice != "y" && choice != "yes")
                        {
                            continueCalculating = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading user choice: " + ex.Message);
                    Console.WriteLine("Returning to main menu...");
                    continueCalculating = false;
                }
                
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Displays the grading scale
        /// </summary>
        static void ShowGradeScale()
        {
            try
            {
                Console.WriteLine("============ GRADING SCALE ============");
                Console.WriteLine("A: 90-100  (Excellent)");
                Console.WriteLine("B: 80-89   (Good)");
                Console.WriteLine("C: 70-79   (Average)");
                Console.WriteLine("D: 60-69   (Below Average)");
                Console.WriteLine("F: 0-59    (Fail)");
                Console.WriteLine("======================================");
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying grade scale: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Gets performance description for a letter grade
        /// </summary>
        /// <param name="letterGrade">The letter grade</param>
        /// <returns>Performance description</returns>
        static string GetPerformanceDescription(string letterGrade)
        {
            try
            {
                switch (letterGrade)
                {
                    case "A": return "Excellent";
                    case "B": return "Good";
                    case "C": return "Average";
                    case "D": return "Below Average";
                    case "F": return "Fail";
                    default: return "Unknown";
                }
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }
        

        /// <summary>
        /// Converts a numerical grade to a letter grade
        /// </summary>
        /// <param name="grade">Numerical grade between 0 and 100</param>
        /// <returns>Letter grade (A, B, C, D, or F)</returns>
        static string GetLetterGrade(double grade)
        {
            try
            {
                // Additional validation for special double values
                if (double.IsNaN(grade))
                    return "Invalid";
                
                if (double.IsInfinity(grade))
                    return "Invalid";
                
                // Ensure grade is within valid range
                if (grade < 0 || grade > 100)
                    return "Out of Range";
                
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
            catch (Exception ex)
            {
                Console.WriteLine("Error in grade calculation: " + ex.Message);
                return "Error";
            }
        }
    }
}

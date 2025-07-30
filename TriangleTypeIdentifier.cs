using System;

class TriangleTypeIdentifier
{
    static void Main()
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
        Console.WriteLine("================================================");
        Console.WriteLine("    WELCOME TO TRIANGLE TYPE IDENTIFIER        ");
        Console.WriteLine("================================================");
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
                Console.WriteLine("1. Identify Triangle Type");
                Console.WriteLine("2. View Triangle Information");
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
                        IdentifyTriangleType();
                        break;
                    case "2":
                        ShowTriangleInformation();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using Triangle Type Identifier!");
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
    /// Handles triangle type identification functionality
    /// </summary>
    static void IdentifyTriangleType()
    {
        bool continueIdentifying = true;
        
        while (continueIdentifying)
        {
            try
            {
                Console.WriteLine("============ Triangle Type Identifier ============");
                Console.WriteLine("Enter the lengths of the three sides of the triangle:");
                
                // Get the three sides
                double side1 = GetValidSideInput("Enter the length of the first side: ");
                if (side1 == -1) continue; // Invalid input, restart
                
                double side2 = GetValidSideInput("Enter the length of the second side: ");
                if (side2 == -1) continue; // Invalid input, restart
                
                double side3 = GetValidSideInput("Enter the length of the third side: ");
                if (side3 == -1) continue; // Invalid input, restart
                
                // Validate that the sides can form a valid triangle
                if (!IsValidTriangle(side1, side2, side3))
                {
                    Console.WriteLine("Error: The entered sides cannot form a valid triangle.");
                    Console.WriteLine("The sum of any two sides must be greater than the third side.");
                    continue;
                }
                
                // Display the entered sides
                Console.WriteLine("\nSides entered: " + side1 + ", " + side2 + ", " + side3);
                
                // Determine and display triangle type
                string triangleType = DetermineTriangleType(side1, side2, side3);
                DisplayTriangleResult(triangleType, side1, side2, side3);
                
                // Calculate and display additional properties
                DisplayTriangleProperties(side1, side2, side3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.WriteLine("The identification will continue...");
            }
            
            try
            {
                // Ask user if they want to analyze another triangle
                Console.WriteLine("\nDo you want to analyze another triangle? (y/n): ");
                string choice = Console.ReadLine();
                
                // Handle null input for choice
                if (choice == null)
                {
                    Console.WriteLine("No input received. Returning to main menu...");
                    continueIdentifying = false;
                }
                else
                {
                    choice = choice.ToLower().Trim();
                    if (choice != "y" && choice != "yes")
                    {
                        continueIdentifying = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading user choice: " + ex.Message);
                Console.WriteLine("Returning to main menu...");
                continueIdentifying = false;
            }
            
            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// Gets valid side input from user
    /// </summary>
    /// <param name="prompt">The prompt message</param>
    /// <returns>Valid side length or -1 if invalid</returns>
    static double GetValidSideInput(string prompt)
    {
        try
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Input cannot be empty. Please enter a positive number.");
                return -1;
            }
            
            double side;
            if (double.TryParse(input, out side))
            {
                if (side <= 0)
                {
                    Console.WriteLine("Error: Side length must be a positive number.");
                    return -1;
                }
                
                if (double.IsNaN(side) || double.IsInfinity(side))
                {
                    Console.WriteLine("Error: Invalid number format.");
                    return -1;
                }
                
                return side;
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
                return -1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading input: " + ex.Message);
            return -1;
        }
    }
    
    /// <summary>
    /// Validates if three sides can form a triangle
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    /// <returns>True if valid triangle, false otherwise</returns>
    static bool IsValidTriangle(double side1, double side2, double side3)
    {
        return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
    }
    
    /// <summary>
    /// Determines the type of triangle
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    /// <returns>Triangle type as string</returns>
    static string DetermineTriangleType(double side1, double side2, double side3)
    {
        try
        {
            if (side1 == side2 && side2 == side3)
            {
                return "Equilateral";
            }
            else if (side1 == side2 || side1 == side3 || side2 == side3)
            {
                return "Isosceles";
            }
            else
            {
                return "Scalene";
            }
        }
        catch (Exception)
        {
            return "Unknown";
        }
    }
    
    /// <summary>
    /// Displays triangle identification results
    /// </summary>
    /// <param name="triangleType">Type of triangle</param>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    static void DisplayTriangleResult(string triangleType, double side1, double side2, double side3)
    {
        try
        {
            Console.WriteLine("Triangle Type: " + triangleType);
            
            switch (triangleType)
            {
                case "Equilateral":
                    Console.WriteLine("All three sides are equal.");
                    break;
                case "Isosceles":
                    Console.WriteLine("Two sides are equal.");
                    // Show which sides are equal
                    if (side1 == side2)
                        Console.WriteLine("Sides " + side1 + " and " + side2 + " are equal.");
                    else if (side1 == side3)
                        Console.WriteLine("Sides " + side1 + " and " + side3 + " are equal.");
                    else
                        Console.WriteLine("Sides " + side2 + " and " + side3 + " are equal.");
                    break;
                case "Scalene":
                    Console.WriteLine("No sides are equal.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error displaying results: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Displays triangle properties
    /// </summary>
    /// <param name="side1">First side</param>
    /// <param name="side2">Second side</param>
    /// <param name="side3">Third side</param>
    static void DisplayTriangleProperties(double side1, double side2, double side3)
    {
        try
        {
            Console.WriteLine("\nTriangle properties:");
            
            // Calculate perimeter
            double perimeter = side1 + side2 + side3;
            Console.WriteLine("- Perimeter: " + perimeter.ToString("F2"));
            
            // Calculate area using Heron's formula
            double s = perimeter / 2; // semi-perimeter
            double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
            Console.WriteLine("- Area: " + area.ToString("F2") + " square units");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calculating properties: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Displays triangle information
    /// </summary>
    static void ShowTriangleInformation()
    {
        try
        {
            Console.WriteLine("============ TRIANGLE INFORMATION ============");
            Console.WriteLine("Triangle Types:");
            Console.WriteLine();
            Console.WriteLine("1. EQUILATERAL TRIANGLE");
            Console.WriteLine("   - All three sides are equal");
            Console.WriteLine("   - All angles are 60 degrees");
            Console.WriteLine("   - Example: sides 5, 5, 5");
            Console.WriteLine();
            Console.WriteLine("2. ISOSCELES TRIANGLE");
            Console.WriteLine("   - Two sides are equal");
            Console.WriteLine("   - Two angles are equal");
            Console.WriteLine("   - Example: sides 5, 5, 8");
            Console.WriteLine();
            Console.WriteLine("3. SCALENE TRIANGLE");
            Console.WriteLine("   - No sides are equal");
            Console.WriteLine("   - All angles are different");
            Console.WriteLine("   - Example: sides 3, 4, 5");
            Console.WriteLine();
            Console.WriteLine("Triangle Inequality Rule:");
            Console.WriteLine("The sum of any two sides must be greater than the third side.");
            Console.WriteLine("=============================================");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error displaying triangle information: " + ex.Message);
        }
    }
}

using System;

class TriangleTypeIdentifier
{
    static void Main()
    {
        bool continueProgram = true;
        
        while (continueProgram)
        {
            // Display program title
            Console.WriteLine("Triangle Type Identifier");
            Console.WriteLine("========================");
            
            try
            {
                // Prompt user for the three sides of the triangle
                Console.Write("Enter the length of the first side: ");
                double side1 = double.Parse(Console.ReadLine());
                
                Console.Write("Enter the length of the second side: ");
                double side2 = double.Parse(Console.ReadLine());
                
                Console.Write("Enter the length of the third side: ");
                double side3 = double.Parse(Console.ReadLine());
                
                // Validate that all sides are positive
                if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                {
                    Console.WriteLine("Error: All sides must be positive numbers.");
                }
                // Validate that the sides can form a valid triangle
                // Triangle inequality theorem: sum of any two sides must be greater than the third side
                else if ((side1 + side2 <= side3) || (side1 + side3 <= side2) || (side2 + side3 <= side1))
                {
                    Console.WriteLine("Error: The entered sides cannot form a valid triangle.");
                    Console.WriteLine("The sum of any two sides must be greater than the third side.");
                }
                else
                {
                    // Display the entered sides
                    Console.WriteLine($"\nSides entered: {side1}, {side2}, {side3}");
                    
                    // Determine triangle type
                    string triangleType;
                    
                    if (side1 == side2 && side2 == side3)
                    {
                        triangleType = "Equilateral";
                        Console.WriteLine($"Triangle Type: {triangleType}");
                        Console.WriteLine("All three sides are equal.");
                    }
                    else if (side1 == side2 || side1 == side3 || side2 == side3)
                    {
                        triangleType = "Isosceles";
                        Console.WriteLine($"Triangle Type: {triangleType}");
                        Console.WriteLine("Two sides are equal.");
                        
                        // Show which sides are equal
                        if (side1 == side2)
                            Console.WriteLine($"Sides {side1} and {side2} are equal.");
                        else if (side1 == side3)
                            Console.WriteLine($"Sides {side1} and {side3} are equal.");
                        else
                            Console.WriteLine($"Sides {side2} and {side3} are equal.");
                    }
                    else
                    {
                        triangleType = "Scalene";
                        Console.WriteLine($"Triangle Type: {triangleType}");
                        Console.WriteLine("No sides are equal.");
                    }
                    
                    // Additional information about the triangle
                    Console.WriteLine($"\nTriangle properties:");
                    Console.WriteLine($"- Perimeter: {side1 + side2 + side3:F2}");
                    
                    // Calculate area using Heron's formula
                    double s = (side1 + side2 + side3) / 2; // semi-perimeter
                    double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
                    Console.WriteLine($"- Area: {area:F2} square units");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers for the triangle sides.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The numbers entered are too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            
            // Ask user if they want to continue
            Console.WriteLine("\nDo you want to analyze another triangle? (y/n): ");
            string choice = Console.ReadLine().ToLower().Trim();
            
            if (choice != "y" && choice != "yes")
            {
                continueProgram = false;
                Console.WriteLine("Thank you for using Triangle Type Identifier!");
            }
            
            Console.WriteLine(); // Add blank line for better readability
        }
        
        // Keep console open
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

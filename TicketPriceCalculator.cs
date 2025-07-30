using System;

class TicketPriceCalculator
{
    static void Main()
    {
        // Display program title
        Console.WriteLine("Movie Theater Ticket Price Calculator");
        Console.WriteLine("=====================================");
        
        // Prompt user for age
        Console.Write("Please enter your age: ");
        
        try
        {
            // Read and parse age input
            int age = int.Parse(Console.ReadLine());
            
            // Validate age input
            if (age < 0)
            {
                Console.WriteLine("Error: Age cannot be negative. Please enter a valid age.");
                return;
            }
            
            // Calculate ticket price based on age
            decimal ticketPrice;
            string discountCategory = "";
            
            if (age <= 12)
            {
                ticketPrice = 7.00m; // Child discount
                discountCategory = " (Child Discount)";
            }
            else if (age >= 65)
            {
                ticketPrice = 7.00m; // Senior citizen discount
                discountCategory = " (Senior Citizen Discount)";
            }
            else
            {
                ticketPrice = 10.00m; // Regular price
                discountCategory = " (Regular Price)";
            }
            
            // Display the result
            Console.WriteLine($"\nAge: {age}");
            Console.WriteLine($"Ticket Price: GHC{ticketPrice:F2}{discountCategory}");
            
            // Additional information
            if (age <= 12)
            {
                Console.WriteLine("You qualify for the child discount!");
            }
            else if (age >= 65)
            {
                Console.WriteLine("You qualify for the senior citizen discount!");
            }
            else
            {
                Console.WriteLine("Regular ticket price applies.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number for age.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The age entered is too large. Please enter a reasonable age.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        
        // Keep console open
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

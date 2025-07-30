using System;

class TicketPriceCalculator
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
        Console.WriteLine("    WELCOME TO TICKET PRICE CALCULATOR         ");
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
                Console.WriteLine("1. Calculate Ticket Price");
                Console.WriteLine("2. View Pricing Information");
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
                        CalculateTicketPrice();
                        break;
                    case "2":
                        ShowPricingInformation();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using Ticket Price Calculator!");
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
    /// Handles ticket price calculation functionality
    /// </summary>
    static void CalculateTicketPrice()
    {
        bool continueCalculating = true;
        
        while (continueCalculating)
        {
            try
            {
                Console.WriteLine("============ Ticket Price Calculator ============");
                Console.WriteLine("Please enter your age:");
                
                // Read user input with null check
                string input = Console.ReadLine();
                
                // Check for null or empty input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty. Please enter your age.");
                    continue;
                }
                
                // Try to parse the input as an integer
                int age;
                if (int.TryParse(input, out age))
                {
                    // Validate age input
                    if (age < 0)
                    {
                        Console.WriteLine("Error: Age cannot be negative. Please enter a valid age.");
                    }
                    else if (age > 150)
                    {
                        Console.WriteLine("Error: Please enter a realistic age.");
                    }
                    else
                    {
                        // Calculate ticket price based on age
                        decimal ticketPrice;
                        string discountCategory = "";
                        string discountMessage = "";
                        
                        if (age <= 12)
                        {
                            ticketPrice = 7.00m; // Child discount
                            discountCategory = " (Child Discount)";
                            discountMessage = "You qualify for the child discount!";
                        }
                        else if (age >= 65)
                        {
                            ticketPrice = 7.00m; // Senior citizen discount
                            discountCategory = " (Senior Citizen Discount)";
                            discountMessage = "You qualify for the senior citizen discount!";
                        }
                        else
                        {
                            ticketPrice = 10.00m; // Regular price
                            discountCategory = " (Regular Price)";
                            discountMessage = "Regular ticket price applies.";
                        }
                        
                        // Display the result
                        Console.WriteLine("\nAge: " + age);
                        Console.WriteLine("Ticket Price: GHC" + ticketPrice.ToString("F2") + discountCategory);
                        Console.WriteLine(discountMessage);
                        
                        // Additional savings information
                        if (age <= 12 || age >= 65)
                        {
                            decimal savings = 10.00m - ticketPrice;
                            Console.WriteLine("You save: GHC" + savings.ToString("F2") + " compared to regular price!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number for age.");
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
                // Ask user if they want to calculate another ticket price
                Console.WriteLine("\nDo you want to calculate another ticket price? (y/n): ");
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
    /// Displays pricing information
    /// </summary>
    static void ShowPricingInformation()
    {
        try
        {
            Console.WriteLine("============ PRICING INFORMATION ============");
            Console.WriteLine("Regular Price:          GHC10.00");
            Console.WriteLine("Child Discount (≤12):   GHC7.00  (Save GHC3.00)");
            Console.WriteLine("Senior Discount (≥65):  GHC7.00  (Save GHC3.00)");
            Console.WriteLine();
            Console.WriteLine("Age Categories:");
            Console.WriteLine("• Child: 12 years and below");
            Console.WriteLine("• Adult: 13 to 64 years");
            Console.WriteLine("• Senior: 65 years and above");
            Console.WriteLine("============================================");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error displaying pricing information: " + ex.Message);
        }
    }
}

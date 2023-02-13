using System;
using System.Linq;

namespace Password_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Setting the minimum and maximum length for password
            int minLength = 8;
            int maxLength = 20;

            //Declaring variable for password input 
            string passwordEntered;

            //Setting validity score to 0
            int validityScore = 0;

            //Declaring variable for another password entry
            string enterAnotherPassword;

            // Welcome and instructions
            Title();
            Requirements();

            // Prompting user to enter 1st password
            Console.Write("Please enter a password: ");

            // Taking value from input and assigning it to the passwordEntered variable
            passwordEntered = Console.ReadLine();
            Console.WriteLine();

            // If the password entered is over 8 characters, +1
            if (passwordEntered.Length >= minLength)
            {
                validityScore++;
            }

            // If the password entered is under 20 characters, +1
            if (passwordEntered.Length <= maxLength)
            {
                validityScore++;
            }

            // If the password entered contains any upper characters, +1
            if (passwordEntered.Any(Char.IsUpper))
            {
                validityScore++;
            }

            // If the password entered contains any lower characters, +1
            if (passwordEntered.Any(Char.IsLower))
            {
                validityScore++;
            }

            // If the password entered contains any digits, +1
            if (passwordEntered.Any(Char.IsDigit))
            {
                validityScore++;
            }

            // If the password entered contains any special characters, +1
            if (passwordEntered.Any(Char.IsSymbol) || passwordEntered.Any(Char.IsPunctuation))
            {
                validityScore++;
            }

            // While the password is not strong
            while (validityScore != 6)
            {
                // Ask the user whether they would like to enter another password to add validity
                Console.Write("Do you want to enter another password to add validity? (Yes / No): ");

                // Take value and assign it to enterAnotherPassword
                enterAnotherPassword = Console.ReadLine();

                // If enterAnotherPassword is Yes, then restart requirements
                if (enterAnotherPassword == "yes" || enterAnotherPassword == "Yes")
                {
                    // Set validity score to 0 so that it is not interfered with first input
                    validityScore = 0;

                    // Clear the console so that the user doesn't get confused with previous input
                    Console.Clear();

                    // Show the requirements for clearness
                    Requirements();

                    // Prompt user to enter another password
                    Console.Write("Please enter another password: ");

                    // Take value and assign it to passwordEntered
                    passwordEntered = Console.ReadLine();
                    Console.WriteLine();

                    // Run all tests a second time
                    if (passwordEntered.Length >= minLength)
                    {
                        validityScore++;
                    }

                    if (passwordEntered.Length <= maxLength)
                    {
                        validityScore++;
                    }

                    if (passwordEntered.Any(Char.IsUpper))
                    {
                        validityScore++;
                    }

                    if (passwordEntered.Any(Char.IsLower))
                    {
                        validityScore++;
                    }

                    if (passwordEntered.Any(Char.IsDigit))
                    {
                        validityScore++;
                    }

                    if (passwordEntered.Any(Char.IsSymbol) || passwordEntered.Any(Char.IsPunctuation))
                    {
                        validityScore++;
                    }

                    // Verdict statement depending on score
                    switch (validityScore)
                    {
                        case 5:
                            Console.WriteLine("Verdict: This is a strong password");
                            break;

                        case 4:
                            Console.WriteLine("Verdict: This is an average password.. try and make it stronger");
                            break;

                        case 3:
                            Console.WriteLine("Verdict: This is a weak password");
                            break;

                        case 2:
                        case 1:
                            Console.WriteLine("Verdict: This is an extremely weak password");
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }   

                // If the user doesn't want to enter another password, exit the program
                else if (enterAnotherPassword == "no" || enterAnotherPassword == "No")
                {
                    Console.WriteLine();
                    Console.WriteLine("Click enter to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            // Showing verdict if password entered first time is strong
            Console.WriteLine("Verdict: This is an extremely strong password");
            Console.WriteLine();

            // Exit program when complete
            Console.WriteLine();
            Console.WriteLine("Click enter to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        // Function for Title
        static void Title()
        {
            Console.WriteLine("Welcome to the Password Validity Checker");
            Console.WriteLine();
        }

        // Function for Requirements
        static void Requirements()
        {
            Console.WriteLine("We will check your password for the following requirements in order to see how strong your password is:");
            Console.WriteLine();
            Console.WriteLine("- Minimum 8 characters");
            Console.WriteLine("- Maximum 20 characters");
            Console.WriteLine("- At least 1x upper case letter");
            Console.WriteLine("- At least 1x lower case letter");
            Console.WriteLine("- At least 1x digit");
            Console.WriteLine("- At least 1x special character");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

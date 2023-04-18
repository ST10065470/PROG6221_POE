using System;
using static System.Formats.Asn1.AsnWriter;

namespace PROG6221_POE
{
    public class ErrorControl
    {
        public ErrorControl()
        {
        }

        /*
        Displays an error message prompting the user to try again after entering invalid input.
        */
        public void IncorrectEntryPrompt()
        {
            // Set text text colour to red
            Console.ForegroundColor = ConsoleColor.Red;
            // Clear the current console line
            ClearCurrentConsoleLine();
            Console.Write("Invalid Entry! Press Try Again");// Display the error message to the user
                                                            // Show a loading animation using the red text colour
            LoadingAnimation(Console.ForegroundColor);
            // Clear the current console line
            ClearCurrentConsoleLine();
            // Move the cursor to the start of the next line
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            // Reset the console text colour to default
            Console.ResetColor();
        }

        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1); //Setting the cursor position to the begining of the current line
            Console.Write(new string(' ', Console.WindowWidth + 100));//Printing blank spaces for the length of the console + 100 characters over the existing text
            Console.SetCursorPosition(0, Console.CursorTop - 1); //Setting the cursor position to the begining of the current line
        }

        //A method which prints a loadign animation when called
        public void LoadingAnimation(ConsoleColor colour)
        {
            //Setting the colour of the text
            Console.ForegroundColor = colour;
            //A for loop which runs 3 times to print 3 '.' characters
            for (int pos = 0; pos < 3; pos++)
            {
                Thread.Sleep(400);//Making the thread pause for 400 milliseconds, creating the animation effect
                Console.Write(".");
            }
            Thread.Sleep(400);
        }

        // Check if the user's answer contains "y" or "n"
        public int CheckYesOrNo(string answer)
        {
            if (answer.ToLower().Contains("y")) // if answer contains "y"
            {
                return 1; // return 1
            }
            else if (answer.ToLower().Contains("n")) // else if answer contains "n"
            {
                return 2; // return 2
            }
            else // else
            {
                IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                return 0; // return 0
            }
        }

        // Check if the user's input is empty
        public Boolean CheckForNull(string userInput)
        {
            if (userInput.Equals("")) // if user input is empty
            {
                IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                return false; // return false
            }
            else // else
            {
                return true; // return true
            }
        }

        // Check if the user's input is a number
        public Boolean CheckForPositiveNumber(string userInput)
        {
            try
            {
                if (double.Parse(userInput) >= 0) // try to parse user input as a double and check if the number is greater than 0
                {
                    return true; // return true if successful
                }
                else
                {
                    IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                    return false; // return false
                }
                
            }
            catch (Exception ex) // catch any exception
            {
                IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                return false; // return false
            }
        }

        // Check if the user's input is a valid unit of measurement
        public string CheckSelectUnit(string userInput)
        {
            switch (userInput)
            {
                case "1":
                case "teaspoon":
                case "teaspoon(s)":
                    return "Teaspoon(s)";
                case "2":
                case "tablespoon":
                case "tablespoon(s)":
                    return "Tablespoon(s)";
                case "3":
                case "cup":
                case "cup(s)":
                    return "Cups(s)";
                case "4":
                case "gram":
                case "gram(s)":
                    return "Gram(s)";

                case "5":
                case "kilogram":
                case "kilogram(s)":
                    return "Kilogram(s)";
                case "6":
                case "custom unit":
                case "custom":
                    return "Custom Unit";

                default:
                    IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                    return "Invalid"; // return "Invalid"
            }

            switch (userInput)
            {
                // if user input is "1", "teaspoon", or "teaspoon(s)"
                case "1":
                case "teaspoon":
                case "teaspoon(s)":
                    return "Teaspoon(s)"; // return "Teaspoon(s)"
                //if user input is "2", "tablespoon", or "tablespoon(s)"
                case "2":
                case "tablespoon":
                case "tablespoon(s)":
                    return "Tablespoon(s)"; // return "Tablespoon(s)"
                // if user input is "3", "cup", or "cup(s)"
                case "3":
                case "cup":
                case "cup(s)":
                    return "Cup(s)"; // return "Cup(s)"
                // else if user input is "4", "gram", or "gram(s)"
                case "4":
                case "gram":
                case "gram(s)":
                    return "Gram(s)"; // return "Gram(s)"
                //if if user input is "5", "kilogram", or "kilogram(s)"
                case "5":
                case "kilogram":
                case "kilograms":
                    return "Kilogram(s)"; // return "Kilogram(s)"
                default:
                    IncorrectEntryPrompt(); // call IncorrectEntryPrompt method
                    return "Invalid"; // return "Invalid"
            }
        }

        public double CheckSetScale(string userInput)
        {
            switch (userInput) 
            { 
                // If the user input contains '1' or is equal to 'default'
                case "1":
                case "default":
                    return 1;
                // If the user input contains '2' or is equal to 'double'
                case "2":
                case "double":
                    return 2;
                // If the user input contains '3' or is equal to 'triple'
                case "3":
                case "triple":
                    return 3;
                // If the user input contains '4', is equal to 'half', or is equal to '0.5'
                case "4":
                case "half":
                case "0.5":
                    return 0.5;
                default:
                    // Prompt the user that their entry is incorrect
                    IncorrectEntryPrompt();
                    // Return 0 as a default value
                    return 0;
            }
        }

        public Boolean CheckSetScaleMenuChoice(string userInput)
        {
            // Check if the user input is '1) reset scale'
            if ("1) reset scale".Contains(userInput))
            {
                return true;
            }
            // Check if the user input is '2) Return To Menu'
            else if ("2) Return To Menu".Contains(userInput))
            {
                return false;
            }
            else
            {
                // Prompt the user that their entry is incorrect
                IncorrectEntryPrompt();
                // Return true as a default value
                return true;
            }
        }

        public Boolean CheckForRecipe(string recipeNum, int numRecipes)
        {
            // Parse the recipe number as an integer
            int recipeIndex = int.Parse(recipeNum);

            // Check if the recipe number is less than or equal to the number of recipes available
            if (recipeIndex <= numRecipes)
            {
                return true;
            }
            else
            {
                // Prompt the user that their entry is incorrect
                IncorrectEntryPrompt();
                // Return false as a default value
                return false;
            }
        }

    }
}
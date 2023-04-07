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

        public int CheckYesOrNo(string answer)
        {
            if (answer.ToLower().Contains("y"))
            {
                return 1;
            }
            else if (answer.ToLower().Contains("n"))
            {
                return 2;
            }
            else
            {
                IncorrectEntryPrompt();
                return 0;
            }
        }

        public Boolean CheckForNull(string userInput)
        {
            if (userInput.Equals(""))
            {
                IncorrectEntryPrompt();
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean CheckForNumber(string userInput)
        {

            try
            {
                double.Parse(userInput);
                return true;
            }
            catch (Exception ex)
            {
                IncorrectEntryPrompt();
                return false;
            }
        }

        public string CheckSelectUnit(string userInput)
        {
            if (userInput.Equals("1") || userInput.Equals("teaspoon") || userInput.Equals("teaspoon(s)"))
            {
                return "Teaspoon(s)";
            }
            else if (userInput.Equals("2") || userInput.Equals("tablespoon") || userInput.Equals("tablespoon(s)"))
            {
                return "Tablespoon(s)";
            }
            else if (userInput.Equals("3") || userInput.Equals("cup") || userInput.Equals("cup(s)"))
            {
                return "Cup(s)";
            }
            else if (userInput.Equals("4") || userInput.Equals("gram") || userInput.Equals("gram(s)"))
            {
                return "Gram(s)";
            }
            else if (userInput.Equals("5") || userInput.Equals("kilogram") || userInput.Equals("kilogram(s)"))
            {
                return "Kilogram(s)";
            }
            else
            {
                IncorrectEntryPrompt();
                return "Invalid";
            }
        }

        public double CheckSetScale(string userInput)
        {
            if (userInput.Contains("1") || userInput.Equals("default"))
            {
                return 1;
            }
            else if (userInput.Contains("2") || userInput.Equals("double"))
            {
                return 2;
            }
            else if (userInput.Contains("3") || userInput.Equals("triple"))
            {
                return 3;
            }
            else if (userInput.Contains("4") || userInput.Equals("half") || userInput.Equals("0.5"))
            {
                return 0.5;
            }
            else
            {
                IncorrectEntryPrompt();
                return 0;
            }
        }

        public Boolean CheckSetScaleMenuChoice(string userInput)
        {
            if ("1) reset scale".Contains(userInput))
            {
                return true;
            }
            else if ("2) Return To Menu".Contains(userInput))
            {
                return false;
            }
            else
            {
                IncorrectEntryPrompt();
                return true;
            }
        }
    }
}


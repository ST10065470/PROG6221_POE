using System;
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
            loadingAnimation(Console.ForegroundColor);
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
        public void loadingAnimation(ConsoleColor colour)
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
    }
}


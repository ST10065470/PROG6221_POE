// russellschwedhelm
// ST10065470@vcconnect.edu.za
using System;
namespace PROG6221_POE
{
	public class Animations
	{
		public Animations()
		{
		}
        public void PrintMessage(string messageType, string message)
        {
            Program program = new Program();
            if (messageType.Equals("negative"))
            {
                program.PrintTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message);
                loadingAnimation(Console.ForegroundColor);
                Console.ResetColor();
            }
            else
            {
                program.PrintTitle();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message);
                loadingAnimation(Console.ForegroundColor);
                Console.ResetColor();
            }
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


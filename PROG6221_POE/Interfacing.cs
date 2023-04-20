//Ethan Schoonbee ST10036509
//PROG6221 POE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;
using System.Runtime.InteropServices;

namespace PROG6221_POE
{
    public class Interfacing
    {

        public static void run()
        {

            mainLoop();

        }//end public run method





        protected static void printTitle()
        {
            //variable declarations:
            string[] arrTitlePieces = { "██╗░░░██╗░░░░░░██████╗░███████╗░█████╗░██╗██████╗░███████╗\r\n",
                                        "██║░░░██║░░░░░░██╔══██╗██╔════╝██╔══██╗██║██╔══██╗██╔════╝\r\n",
                                        "██║░░░██║█████╗██████╔╝█████╗░░██║░░╚═╝██║██████╔╝█████╗░░\r\n",
                                        "██║░░░██║╚════╝██╔══██╗██╔══╝░░██║░░██╗██║██╔═══╝░██╔══╝░░\r\n",
                                        "╚██████╔╝░░░░░░██║░░██║███████╗╚█████╔╝██║██║░░░░░███████╗\r\n",
                                        "░╚═════╝░░░░░░░╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝╚═╝░░░░░╚══════╝\r\n"};
                                         
            //change color of forground text
            ForegroundColor = ConsoleColor.DarkCyan;

            //display title pieces one by one and wait 0.2s between prints
            for (int i = 0; i < arrTitlePieces.Length; i++) 
            {

                Write(arrTitlePieces[i],ForegroundColor);
                Thread.Sleep(300);

            }//end for-loop

        }//end printTitle method





        protected static void printMenu()
        {
            //variable declarations:
            string[] arrMenuOptions = { "1) Add a NEW recipe.\r\n",
                                        "2) Recipe Book.\r\n",
                                        "3) Exit\r\n"};

            Thread.Sleep(500);
            Write("==========================================================\r\n" +
                  "            SELECT AN OPTION BELOW TO PROCEED\r\n" +
                  "==========================================================\r\n");
            Thread.Sleep(500);

            for (int i = 0;i < arrMenuOptions.Length;i++)
            {

                Write(arrMenuOptions[i]);
                Thread.Sleep(300);

            }//end for-loop

            Write("\n>> ");

        }//end printMenu method





        protected static void mainLoop()
        {
            //variable declarations:
            string userChoice = "";

            printTitle();
            printMenu();

            userChoice = ReadLine();

            while ((userChoice != "1") && (userChoice != "2") && (userChoice != "3"))
            {

                Coloration(ConsoleColor.Red, "\nAn Error Occured...\r\n\n");
                Coloration(ConsoleColor.Red, "Press any key to continue...");
                ReadKey();
                Clear();

                printTitle();
                printMenu();

                userChoice = ReadLine();

            }//end while-loop

            switch (userChoice)
            {

                case "1":
                {

                    Write("1");
                    break;

                }
                case "2":
                {

                    Write("2");
                    break;

                }
                case "3":
                {

                    Write("3");
                    break;

                }

            }//end switch

        }//end mainLoop method





        protected static void Coloration(ConsoleColor color, string message)
        {
            //variable declarations:
            var originalColor = Console.ForegroundColor;
            
            //keep track of original color
            Console.ForegroundColor = color;
            //print message with new color
            Console.WriteLine(message);
            //return console to oringal color
            Console.ForegroundColor = originalColor;

        }//end Coloration method
    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
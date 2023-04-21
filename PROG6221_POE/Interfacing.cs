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
        //GLOBAL variable declarations:
        protected static bool hasStoredRecipe = true;//SET TO FALSE!!


        public static void run()
        {

            mainLoop();

        }//end public run method





        protected static void printTitle(int time)
        {
            //variable declarations:
            string[] arrTitlePieces = { "██╗░░░██╗░░░░░░██████╗░███████╗░█████╗░██╗██████╗░███████╗\r\n",
                                        "██║░░░██║░░░░░░██╔══██╗██╔════╝██╔══██╗██║██╔══██╗██╔════╝\r\n",
                                        "██║░░░██║█████╗██████╔╝█████╗░░██║░░╚═╝██║██████╔╝█████╗░░\r\n",
                                        "██║░░░██║╚════╝██╔══██╗██╔══╝░░██║░░██╗██║██╔═══╝░██╔══╝░░\r\n",
                                        "╚██████╔╝░░░░░░██║░░██║███████╗╚█████╔╝██║██║░░░░░███████╗\r\n",
                                        "░╚═════╝░░░░░░░╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝╚═╝░░░░░╚══════╝\r\n"};
                                         

            //display title pieces one by one and wait 0.2s between prints
            for (int i = 0; i < arrTitlePieces.Length; i++) 
            {

                Coloration(ConsoleColor.DarkCyan, arrTitlePieces[i]);
                Thread.Sleep(time);

            }//end for-loop

        }//end printTitle method





        protected static void printMenu()
        {
            //variable declarations:
            string[] arrMenuOptions = { "1) Add A New Recipe\r\n",
                                        "2) Recipe Book\r\n",
                                        "3) Exit\r\n"};

            Thread.Sleep(300);
            Write("==========================================================\r\n" +
                  "            SELECT AN OPTION BELOW TO PROCEED\r\n" +
                  "==========================================================\r\n");
            Thread.Sleep(500);

            for (int i = 0;i < arrMenuOptions.Length;i++)
            {

                Write(arrMenuOptions[i]);
                Thread.Sleep(200);

            }//end for-loop

            Write("\n>> ");

        }//end printMenu method





        protected static void mainLoop()
        {
            //variable declarations:
            string userChoice = "";
            string hintMessage = "HINT : Make Sure Your Input Is A Number Which Corrolates To An Option Above\n" +
                                 "Example : [1] >> Add A New Recipe\n";

            printTitle(100);
            printMenu();

            userChoice = ReadLine();

            while ((userChoice != "1") && (userChoice != "2") && (userChoice != "3"))
            {

                printError(hintMessage);
                Clear();

                printTitle(50);
                printMenu();

                userChoice = ReadLine();

            }//end while-loop

            switch (userChoice)
            {

                case "1":
                {

                    overwriteConfirmation();
                    Write("1");
                    break;

                }
                case "2":
                {

                    displayRecipes();
                    Write("2");
                    break;

                }
                case "3":
                {
                    
                    exitApplication();
                    Write("3");
                    break;

                }

            }//end switch

        }//end mainLoop method





        protected static void overwriteConfirmation()
        {
            //variable declariations:
            string hintMessage = "HINT : Make Sure Your Input Is A Character Which Corrolates To An Option Above\n" +
                                 "Example : [y] >> You Want To Continue\n";
            string messageYesNo = "\n\nBy Creating A New Recipe All Previous Recipe Data Will Be Lost\n" +
                                  "Do You Wish To Continue? [y]/[n]\n";
            string userSelectionKey = "";


            if (hasStoredRecipe == false)
            {

                //addRecipe();

            }//end if
            else
            {

                Thread.Sleep(300);

                Coloration(ConsoleColor.DarkYellow, messageYesNo);
                Write("\n>> ");

                userSelectionKey = ReadLine();

                while ( (userSelectionKey.ToLower() != "n") && (userSelectionKey.ToLower() != "y") )
                {

                    printError(hintMessage);

                    Coloration(ConsoleColor.DarkYellow, messageYesNo);
                    Write("\n>> ");

                    userSelectionKey = ReadLine();

                }//end while-loop (validInput)


                switch (userSelectionKey.ToLower())
                {

                    case "n":
                        {

                            Clear();
                            mainLoop();
                            Write("NO");
                            break;

                        }
                    case "y":
                        {

                            addRecipe();
                            Write("YES");
                            ReadKey();//REMOVE
                            break;

                        }

                }//end switch


            }//end else


        }//end addRecipe method


        protected static void addRecipe()
        {



        }//end addRecipe method





        protected static void displayRecipes()
        {



        }//edn displayRecipes method





        protected static void Coloration(ConsoleColor color, string message)
        {
            //variable declarations:
            var originalColor = Console.ForegroundColor;

            //keep track of original color
            Console.ForegroundColor = color;
            //print message with new color
            Console.Write(message);
            //return console to oringal color
            Console.ForegroundColor = originalColor;

        }//end Coloration method





        protected static void printError(string hint)
        {

            Coloration(ConsoleColor.Red, "An Error Occured...\r\n");
            Coloration(ConsoleColor.DarkGray, hint);
            Write("Press Any Key To Continue...");
            ReadKey();

        }//end printError method





        protected static void exitApplication()
        {

            Clear();

            Coloration(ConsoleColor.Red, "Exiting Program");

            for (int i = 0; i < 3; i++) 
            {
                
                Coloration(ConsoleColor.Red, ".");
                Thread.Sleep(500);

            }//end for-loop

            Thread.Sleep(500);
            Environment.Exit(0);

        }//end exitApplication method
    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
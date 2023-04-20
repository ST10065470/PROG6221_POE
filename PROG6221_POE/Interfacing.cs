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

            printTitle();
            printMenu();

        }//end public run method

        protected static void printTitle()
        {

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

            Write(">> \r\n");

        }//end printMenu method

    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
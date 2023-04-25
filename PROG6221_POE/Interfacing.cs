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
        private List<Recipe> listRecipes = new List<Recipe>();

        public void run()
        {

            mainLoop();

        }//end public run method





        protected void printTitle(int time)
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





        protected void printMenu()
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





        protected void mainLoop()
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
                    if (listRecipes.Count() > 0)
                    {
                            overwriteConfirmation();
                            break;
                    }//end if

                    addRecipe();
                    break;

                }
                case "2":
                {

                    displayRecipes();
                    break;

                }
                case "3":
                {
                    
                    exitApplication();
                    break;

                }

            }//end switch

        }//end mainLoop method





        protected void overwriteConfirmation()
        {
            //variable declariations:
            string hintMessage = "HINT : Make Sure Your Input Is A Character Which Corrolates To An Option Above\n" +
                                 "Example : [y] >> You Want To Continue\n";
            string messageYesNo = "\n\nBy Creating A New Recipe All Previous Recipe Data Will Be Lost\n" +
                                  "Do You Wish To Continue? [y]/[n]\n";
            string userSelectionKey = "";


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

                            listRecipes.Clear();
                            addRecipe();
                            break;

                        }

                }//end switch

        }//end addRecipe method


        protected void addRecipe()
        {
            //declare variables:
            string recipeName = "", userInput = "", stepDescription = "";
            int numIngredients = -1;
            int numSteps = -1;
            string ingredientName = "", ingredientUnitOfMeasure = "";
            double ingredientQuantity = -1;

            Recipe newRecipe;

            do
            {

                Write("Enter The Name For Your Recipe >> ");
                recipeName = ReadLine();

            } while (string.IsNullOrEmpty(recipeName));

            do
            {

                Write("\n\nHow Many Ingredients Do You Wish To Add >> ");
                userInput = ReadLine().ToLower();

                numIngredients = (int)checkPositiveInteger(userInput);

            } while (numIngredients == -1);

            if (numIngredients == 0)
            {

                printError("No Ingredients To Be Added - Cannot Create Recipe");
                Clear();
                mainLoop();

            }


            do
            {

                Write("\n\nHow Many Steps Do You Wish To Add >> ");
                userInput = ReadLine().ToLower();

                numSteps = (int)checkPositiveInteger(userInput);

            } while (numSteps == -1);

            if (numSteps == 0)
            {

                printError("No Ingredients To Be Added - Cannot Create Recipe");
                Clear();
                mainLoop();

            }

            newRecipe = new Recipe(recipeName, numSteps, numIngredients);

            for (int ingredientIndex = 0; ingredientIndex < numIngredients; ingredientIndex++)
            {

                do
                {

                    Write("\n\nEnter The Name Of Ingredient [" + (ingredientIndex + 1) + "] >> ");
                    ingredientName = ReadLine();

                } while (string.IsNullOrEmpty(ingredientName));

                Write("\n\nEnter The Unit Of Measurement For " + ingredientName + " : \n");
                WriteLine("1) Teaspoon(s)\n" +
                          "2) Tablespoon(s)\n" +
                          "3) Cup(s)\n" +
                          "4) Gram(s)\n" +
                          "5) Kilogram(s)\n");

                do
                {

                    Write("\n>> ");
                    userInput = ReadLine().ToLower();

                    ingredientUnitOfMeasure = checkUnitOfMeasure(userInput);

                } while (ingredientUnitOfMeasure.Equals("Not Valid"));

                do
                {

                    Write("\nEnter The Quantity For " + ingredientName + " >> ");
                    userInput = ReadLine().ToLower();

                    ingredientQuantity = checkPositiveInteger(userInput);

                } while (ingredientQuantity == -1);

                newRecipe.addIngredient(ingredientName, ingredientUnitOfMeasure, ingredientQuantity);

            }//end for-loop



            for (int stepIndex = 0 ; stepIndex < numSteps; stepIndex++)
            {

                Write("\n\n");

                do
                {

                    Write("Enter Step Number " + (stepIndex + 1) + " >> ");
                    stepDescription = ReadLine();

                } while (string.IsNullOrEmpty(stepDescription));

                newRecipe.addStep(stepDescription);

            }//end for-loop

            listRecipes.Add(newRecipe);

            Coloration(ConsoleColor.DarkGreen, "\nRecipe "+ recipeName + " Saved Successfully!");
            Write("\n\nPress Any Key To Continue...");
            ReadKey();
            Clear();
            mainLoop();

        }//end addRecipe method





        protected void displayRecipes()
        {

            if (listRecipes.Count() == 0)
            {

                printError("There Are No Recipes Saved!\n\n");
                Clear();
                mainLoop();

            }
            else
            {



            }


        }//edn displayRecipes method


        protected void Coloration(ConsoleColor color, string message)
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





        protected void printError(string hint)
        {

            Coloration(ConsoleColor.Red, "An Error Occured...\r\n");
            Coloration(ConsoleColor.DarkGray, hint);
            Write("Press Any Key To Continue...");
            ReadKey();

        }//end printError method


        protected double checkPositiveInteger(string userInput)
        {
            try
            {

                double input = double.Parse(userInput);
                if (input >= 0)
                {

                    return input; 

                }
                else
                {

                    throw new Exception();

                }
            }//end try
            catch
            {

                    return -1; 

            }//end catch 

        }

        public string checkUnitOfMeasure(string userInput)
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
                    return "Cup(s)";


                case "4":
                case "gram":
                case "gram(s)":
                    return "Gram(s)";


                case "5":
                case "kilogram":
                case "kilogram(s)":
                    return "Kilogram(s)";


                default:
                    printError("Invalid Entry Please Select Form One Of The Options Above");
                    return "Invalid";
            }
        }

        protected void exitApplication()
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
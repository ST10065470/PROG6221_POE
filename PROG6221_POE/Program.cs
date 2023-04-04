using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace PROG6221_POE;
class Program
{
    //A list which stores created recipes
    private List<Recipe> recipeList = new List<Recipe>();
    //----------------------------------------------------------------------------\\
    static void Main(string[] args)
    {
        Program run = new Program();
        run.Menu();
    }

    //----------------------------------------------------------------------------\\

    /* This method clears the console, resets the console colours to their defaults,
    and prints the programme title and a separator. */
    public void PrintTitle()
    {
        // Clear the console.
        Console.Clear();

        // Reset the console colours to their defaults.
        Console.ResetColor();

        // Print the programme title.
        Console.WriteLine("RECIPE BOOK PROGRAMME");

        // Print a line to separate the title.
        Console.WriteLine("---------------------");
    }


    //----------------------------------------------------------------------------\\

    public void Menu()
    {
        int menuSelection = 0;

        // Print the programme title and menu options.
        PrintTitle();
        Console.WriteLine("1) Enter New Recipe" +
                          "\n2) Display Recipe" +
                          "\n3) Delete Recipe" +
                          "\n4) Exit");
        Console.Write("\nEnter Your Numeric Selection: ");

        // Attempt to parse the user's menu selection as an integer.
        try
        {
            menuSelection = int.Parse(Console.ReadLine());
        }
        catch
        {
        }

        // Execute the appropriate action based on the user's selection.
        switch (menuSelection)
        {
            case 1:
                // If the user selects option 1, create a new recipe.
                PrintTitle();
                CreateRecipe();
                break;
            case 2:
                // If the user selects option 2, display a recipe.
                DisplayRecipe();
                break;
            case 3:
                // If the user selects option 3, delete a recipe.
                DeleteRecipe();
                break;
            case 4:
                // If the user selects option 4, exit the programme.
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                // If the user enters an invalid selection, prompt them to try again.
                IncorrectEntryPrompt();
                Console.Clear();
                Menu();
                break;
        }

        // After the selected action is executed, the menu displays again.
        Menu();
    }

    //----------------------------------------------------------------------------\\

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


    //----------------------------------------------------------------------------\\

    /*
    Deletes a recipe from the list of saved recipes, after prompting the user for confirmation.
    If there are no saved recipes to delete, an error message is displayed and the method exits.
    */
    public void DeleteRecipe()
    {
        // Print the title of the recipe book
        PrintTitle();

        // Initialize variables for user input and confirmation flag
        Boolean confirmInputCorrect = false;
        string userInput;

        // Check if there are any saved recipes
        if (recipeList.Count == 0)
        {
            // Display an error message if there are no saved recipes
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No Recipes Saved");
            loadingAnimation(Console.ForegroundColor);
            return;
        }

        do
        {
            // Print the title of the recipe book
            PrintTitle();

            // Prompt the user for confirmation to delete the saved recipe
            Console.Write("Are You Sure You Want To Delete The Saved Recipe (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            // If the user confirms deletion, clear the list of saved recipes
            if (userInput.Equals("y"))
            {
                // Delete the saved recipe and display a success message
                Console.ForegroundColor = ConsoleColor.Green;
                recipeList.Clear();
                PrintTitle();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Recipe Deleted");
                loadingAnimation(Console.ForegroundColor);
                Console.ResetColor();
                confirmInputCorrect = true;
            }
            // If the user cancels deletion, clear the console and exit the method
            else if (userInput.Equals("n"))
            {
                Console.Clear();
                confirmInputCorrect = true;
            }
            // If the user enters invalid input, display an error message
            else
            {
                IncorrectEntryPrompt();
            }
            //Repeat if incorrect input was entered
        } while (confirmInputCorrect == false);
    }


    //----------------------------------------------------------------------------\\

    public void CreateRecipe()
    {
        string userInput;
        string recipeName;
        int numIngredients;
        int numSteps;
        Boolean confirmInputCorrect;

        if (recipeList.Count() > 0)
        {
            Console.WriteLine("A Recipe Is Already Present In Storage. " +
                              "To Add A New Recipe, Storage Must Be Cleared");
            do
            {
                Console.Write("Would You Like To Continue (Y/N): ");
                userInput = Console.ReadLine().ToLower();
                confirmInputCorrect = false;

                if (userInput.Equals("y"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    recipeList.Clear();
                    Console.Write("\nRecipe Deleted");
                    loadingAnimation(Console.ForegroundColor);
                    confirmInputCorrect = true;
                    PrintTitle();
                }
                else if (userInput.Equals("n"))
                {
                    return;
                }
                else
                {
                    IncorrectEntryPrompt();
                }

            } while (confirmInputCorrect == false);
        }

        Recipe newRecipe;

        do
        {
            Console.Write("Please Enter The Name Of The New Recipe: ");
            recipeName = Console.ReadLine();

            if (recipeName.Equals(""))
            {
                IncorrectEntryPrompt();
                PrintTitle();
            }
        } while (recipeName.Equals(""));


        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + recipeName);
            Console.WriteLine();
            Console.Write("How Many Ingredients Do You Want To Add: ");
            confirmInputCorrect = int.TryParse(Console.ReadLine(), out numIngredients);

            if (numIngredients == 0)
            {
                ClearCurrentConsoleLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("No Ingredients To Be Added. Create Recipe Aborted");
                loadingAnimation(Console.ForegroundColor);
                return;
            }

            else if (confirmInputCorrect == false)
            {
                IncorrectEntryPrompt();
            }

        } while (confirmInputCorrect == false);


        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + recipeName);
            Console.WriteLine();
            Console.Write("How Many Steps Do You Want To Add: ");
            confirmInputCorrect = int.TryParse(Console.ReadLine(), out numSteps);

            if (numSteps == 0)
            {
                ClearCurrentConsoleLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("No Steps To Be Added. Create Recipe Aborted");
                loadingAnimation(Console.ForegroundColor);
                return;
            }

            else if (confirmInputCorrect == false)
            {
                IncorrectEntryPrompt();
            }

        } while (confirmInputCorrect == false);

        newRecipe = new Recipe(recipeName, numIngredients, numSteps);

        string ingrerdientName;
        double ingredientQuantity = 0;
        string ingredientUnitOfMeasurement = "";

        for (int ingredient = 0; ingredient < numIngredients; ingredient++)
        {
            do
            {
                PrintTitle();
                Console.WriteLine("Recipe: " + recipeName);
                Console.Write("\nPlease Enter The Name Of The Ingrediant: ");
                ingrerdientName = Console.ReadLine();
                if (ingrerdientName.Equals(""))
                {
                    IncorrectEntryPrompt();
                }

            } while (ingrerdientName.Equals(""));

            Console.WriteLine();


            Console.Write("Please Select The Unit Of Measurement For \""
                      + ingrerdientName + "\": ");
            Console.WriteLine("\n1) Teaspoon(s)" +
                              "\n2) Tablespoon(s)" +
                              "\n3) Cup(s)" +
                              "\n4) Gram(s)" +
                              "\n5) Kilogram(s)");
            Console.WriteLine();
            do
            {
                Console.Write("Enter Your Selection: ");
                userInput = (Console.ReadLine() + "   ").ToLower().Substring(0, 2);

                confirmInputCorrect = false;

                switch (userInput)
                {
                    case "1 ":
                    case "1)":
                    case "te":
                        ingredientUnitOfMeasurement = "Teaspoon(s)";
                        confirmInputCorrect = true;
                        break;
                    case "2 ":
                    case "2)":
                    case "ta":
                        ingredientUnitOfMeasurement = "Tablespoon(s)";
                        confirmInputCorrect = true;
                        break;
                    case "3 ":
                    case "3)":
                    case "cu":
                        ingredientUnitOfMeasurement = "Cup(s)";
                        confirmInputCorrect = true;
                        break;
                    case "4 ":
                    case "4)":
                    case "gr":
                        ingredientUnitOfMeasurement = "Gram(s)";
                        confirmInputCorrect = true;
                        break;
                    case "5 ":
                    case "5)":
                    case "ki":
                        ingredientUnitOfMeasurement = "Kilogram(s)";
                        confirmInputCorrect = true;
                        break;
                    default:
                        IncorrectEntryPrompt();
                        break;
                }

            } while (confirmInputCorrect == false);

            Console.WriteLine();

            do
            {
                Console.Write("Please Enter The Quantity For \""
                              + ingrerdientName + "\" (x.xx): ");
                confirmInputCorrect = double.TryParse(Console.ReadLine(),
                                                out ingredientQuantity);

                if (confirmInputCorrect == false)
                {
                    IncorrectEntryPrompt();
                }
                else
                {
                    confirmInputCorrect = true;
                }
            } while (confirmInputCorrect == false);

            newRecipe.addIngredient(ingrerdientName, ingredientUnitOfMeasurement,
                                    ingredientQuantity);

        }
        for (int step = 0; step < numSteps; step++)
        {
            string stepInfo;

            PrintTitle();
            Console.WriteLine("Recipe: " + newRecipe.RecipeName);
            Console.WriteLine();
            do
            {
                Console.Write("Please Enter Step Number " + (step + 1) + ": ");
                stepInfo = Console.ReadLine();

                if (stepInfo.Equals(""))
                {
                    IncorrectEntryPrompt();
                }
            } while (stepInfo.Equals(""));

            newRecipe.addStep(stepInfo);
        }

        recipeList.Add(newRecipe);
        PrintTitle();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Recipe Saved");
        loadingAnimation(Console.ForegroundColor);
    }



    //----------------------------------------------------------------------------\\
    // This method displays a selected recipe with ingredients being scaled
    public void DisplayRecipe()
    {
        // Print title of the application.
        PrintTitle();

        // Initialise variables for recipe selection and scale.
        int recipeNum = 1;
        int recipeIndex = 0;
        double recipeScale = 0;
        Boolean confirmInputCorrect = false;
        string userInput;

        // Check if there are any recipes saved.
        if (recipeList.Count == 0)
        {
            // Display an error message and return to the.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No Recipes Saved");
            loadingAnimation(Console.ForegroundColor);
            return;
        }

        // Prompt the user to select a recipe.
        Console.WriteLine("Please Select The Recipe You Want To Display:");

        // Display the list of recipes.
        foreach (Recipe recipe in recipeList)
        {
            Console.WriteLine(recipeNum + ") " + recipe.RecipeName);
            recipeNum++;
        }

        // Get the user's recipe selection.
        do
        {
            Console.Write("\nEnter Your Numeric Selection: ");

            try
            {
                recipeIndex = int.Parse(Console.ReadLine()) - 1;
                confirmInputCorrect = true;
            }
            catch
            {
                IncorrectEntryPrompt();
            }

        } while (confirmInputCorrect == false);

        // Display the selected recipe.
        PrintTitle();
        Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");

        // Prompt the user to select a scale factor.
        Console.Write("Select Your Scale:" +
                          "\n1) Default (1x)" +
                          "\n2) Double (2x)" +
                          "\n3) Triple (3x)" +
                          "\n4) Half (0.5)");
        Console.WriteLine();
        recipeScale = setScale();

        // Display the recipe with the chosen scale factor.
        PrintTitle();
        Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
        Console.WriteLine(recipeList[recipeIndex].displayRecipe(recipeScale));

        // Allow the user to reset the scale or return to the menu.
        confirmInputCorrect = false;

        do
        {
            Console.WriteLine("\nWould You Like To:" +
                              "\n1) Reset Scale" +
                              "\n2) Return To Menu");
            userInput = (Console.ReadLine()).ToLower();
            PrintTitle();

            if ("1) reset scale".Contains(userInput))
            {
                // Reset the scale and display the recipe with the new scale factor.
                PrintTitle();
                Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
                Console.Write("Select Your Scale:" +
                                  "\n1) Default (1x)" +
                                  "\n2) Double (2x)" +
                                  "\n3) Triple (3x)" +
                                  "\n4) Half (0.5)");
                recipeScale = setScale();

                PrintTitle();
                Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
                Console.WriteLine(recipeList[recipeIndex].displayRecipe(recipeScale));
            }
            else if ("2) Return To Menu".Contains(userInput))
            {
                // Return to the menu.
                return;
            }
            else
            {
                IncorrectEntryPrompt();
            }
        } while (true);
    }

    //----------------------------------------------------------------------------\\
    //A method that clears the currect line where the curos sits of text
    public static void ClearCurrentConsoleLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1); //Setting the cursor position to the begining of the current line
        Console.Write(new string(' ', Console.WindowWidth + 100));//Printing blank spaces for the length of the console + 100 characters over the existing text
        Console.SetCursorPosition(0, Console.CursorTop - 1); //Setting the cursor position to the begining of the current line
    }

    //----------------------------------------------------------------------------\\
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

    //----------------------------------------------------------------------------\\
    // A  method that sets the recipe scale and returns it as a double data type
    public double setScale()
    {
        //Variables
        string scale;//Store user input for the scale
        double recipeScale = 1;//Store the recipe scale
        Boolean confirmInputCorrect = false;//A boolean used to indicate whether the user input is correct or not

        //A do-while loop to prompt the user to enter the scale until the input is correct
        do
        {
            // Prompt the user to enter their selection of scale
            Console.Write("\nEnter Your Selection Of Scale: ");
            // Read the user input from the console, convert it to lowercase, and trim it to 2 characters
            scale = (Console.ReadLine() + "  ").ToLower().Substring(0, 2);

            // Start a switch statement to set the appropriate scale based on user input
            switch (scale)
            {
                // If the user input matches any of these cases, set the recipe scale to 0.5
                case "4 ":
                case "0.":
                case "ha":
                    recipeScale = 0.5;
                    confirmInputCorrect = true;
                    break;
                // If the user input matches any of these cases, set the recipe scale to 1
                case "1 ":
                case "de":
                    recipeScale = 1;
                    confirmInputCorrect = true;
                    break;
                // If the user input matches any of these cases, set the recipe scale to 2
                case "2 ":
                case "do":
                    recipeScale = 2;
                    confirmInputCorrect = true;
                    break;
                // If the user input matches any of these cases, set the recipe scale to 3
                case "3 ":
                case "tr":
                    recipeScale = 3;
                    confirmInputCorrect = true;
                    break;
                // If the user input does not match any of the cases, call the IncorrectEntryPrompt() method
                default:
                    IncorrectEntryPrompt();
                    break;
            }

            // Continue the loop until the user input is correct
        } while (confirmInputCorrect == false);

        // Return the recipe scale as a double
        return recipeScale;
    }
}
//----------------------------------------------------------------------------\\


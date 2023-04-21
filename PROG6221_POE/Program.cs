using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace PROG6221_POE
{
    class Program
    {
        //A list which stores created recipes
        private List<Recipe> recipeList = new List<Recipe>();

        ErrorControl errorControl = new ErrorControl();
        Animations animation = new Animations();
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
                    DisplayRecipeAction();
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
                    errorControl.IncorrectEntryPrompt();
                    Console.Clear();
                    Menu();
                    break;
            }

            // After the selected action is executed, the menu displays again.
            Menu();
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

            // Initialize variables for user input
            string userInput;
            int checkedUserInput;

            // Check if there are any saved recipes
            if (recipeList.Count == 0)
            {
                // Display an error message if there are no saved recipes
                animation.PrintMessage("negative", "No Recipes Saved");
                return;
            }

            do
            {
                // Print the title of the recipe book
                PrintTitle();

                // Prompt the user for confirmation to delete the saved recipe
                Console.Write("Are You Sure You Want To Delete The Saved Recipe (Y/N): ");
                userInput = Console.ReadLine().ToLower();

                checkedUserInput = errorControl.CheckYesOrNo(userInput);

                switch (checkedUserInput)
                {
                    case 1:
                        // Delete the saved recipe and display a success message
                        recipeList.Clear();
                        animation.PrintMessage("positive", "Recipe Deleted");
                        break;
                    default:
                        break;
                }
                //Repeat if incorrect input was entered
            } while (checkedUserInput == 0);
        }


        //----------------------------------------------------------------------------\\
        public void CreateRecipe()
        {
            string userInput;
            string recipeName;
            int numIngredients;
            int numSteps;
            int checkedUserInput;

            // Check if there is already a recipe in the storage
            if (recipeList.Count() > 0)
            {
                // Print a message and prompt the user to continue or not
                Console.WriteLine("A Recipe Is Already Present In Storage. To Add A New Recipe, Storage Must Be Cleared\n");
                do
                {
                    Console.Write("Would You Like To Continue (Y/N): ");
                    userInput = Console.ReadLine().ToLower();
                    checkedUserInput = errorControl.CheckYesOrNo(userInput);

                    // Depending on the user's input, perform an action
                    switch (checkedUserInput)
                    {
                        case 1:
                            recipeList.Clear();
                            animation.PrintMessage("positive", "Recipe Deleted");
                            break;
                        case 2:
                            return;
                        default:
                            break;
                    }

                } while (checkedUserInput == 0);
            }

            // Declare a new recipe object
            Recipe newRecipe;

            // Prompt the user to enter the name of the new recipe and check if it's not null
            do
            {
                PrintTitle();
                Console.Write("Please Enter The Name Of The New Recipe: ");
                recipeName = Console.ReadLine();
            } while (errorControl.CheckForNull(recipeName) == false);

            // Prompt the user to enter the number of ingredients and check if it's a number
            do
            {
                PrintTitle();
                Console.WriteLine("Recipe: " + recipeName);
                Console.WriteLine();
                Console.Write("How Many Ingredients Do You Want To Add: ");
                userInput = Console.ReadLine();
            } while (errorControl.CheckForPositiveNumber(userInput) == false);

            // Convert the user input to an integer
            numIngredients = int.Parse(userInput);

            // If the number of ingredients is 0, print an error message and abort creating the recipe
            if (numIngredients == 0)
            {
                animation.PrintMessage("negative", "No Ingredients To Be Added. Create Recipe Aborted");
                return;
            }

            // Prompt the user to enter the number of steps and check if it's a number
            do
            {
                PrintTitle();
                Console.WriteLine("Recipe: " + recipeName);
                Console.WriteLine();
                Console.Write("How Many Steps Do You Want To Add: ");
                userInput = Console.ReadLine();
            } while (errorControl.CheckForPositiveNumber(userInput) == false);

            // Convert the user input to an integer
            numSteps = int.Parse(userInput);

            // If the number of steps is 0, print an error message and abort creating the recipe
            if (numSteps == 0)
            {
                animation.PrintMessage("negative", "No Steps To Be Added. Create Recipe Aborted");
                return;
            }

            // Create a new recipe object with the given name, number of ingredients and steps
            newRecipe = new Recipe(recipeName, numIngredients, numSteps);

            // Declare and initialize the variables for the ingredients
            string ingredientName;
            double ingredientQuantity = 0;
            string ingredientUnitOfMeasurement = "";

            // Loop through the ingredients and prompt the user to enter their name, unit of measurement and quantity
            for (int ingredient = 0; ingredient < numIngredients; ingredient++)
            {
                // Do this whule the user input is null
                do
                {
                    PrintTitle();
                    Console.WriteLine("Recipe: " + recipeName);
                    Console.Write("\nPlease Enter The Name Of The Ingrediant: ");
                    ingredientName = Console.ReadLine();
                } while (errorControl.CheckForNull(ingredientName) == false);

                Console.WriteLine();


                Console.Write("Please Select The Unit Of Measurement For \""
                          + ingredientName + "\": ");
                Console.WriteLine("\n1) Teaspoon(s)" +
                                  "\n2) Tablespoon(s)" +
                                  "\n3) Cup(s)" +
                                  "\n4) Gram(s)" +
                                  "\n5) Kilogram(s)" +
                                  "\n6) Custom Unit" +
                                  "\n");

                // Do this while the user input does not fall within the range 1 - 6
                do
                {
                    Console.Write("Enter Your Selection: ");
                    userInput = Console.ReadLine().ToLower();

                    ingredientUnitOfMeasurement = errorControl.CheckSelectUnit(userInput);

                } while (ingredientUnitOfMeasurement.Equals("Invalid"));

                //If the user chose option 6 above
                if (ingredientUnitOfMeasurement == "Custom Unit")
                {
                    ingredientUnitOfMeasurement = SetCustomScale();
                }

                Console.WriteLine();

                //Do this while the user input is not a valid number. ie. < 0
                do
                {
                    Console.Write("Please Enter The Quantity For \""
                                  + ingredientName + "\" (x.xx): ");
                    userInput = Console.ReadLine();
                } while (errorControl.CheckForPositiveNumber(userInput) == false);

                //Converting the stirng to a double after error checking to ensure that it is a numeric value
                ingredientQuantity = double.Parse(userInput);

                newRecipe.addIngredient(ingredientName, ingredientUnitOfMeasurement,
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
                } while (errorControl.CheckForNull(stepInfo) == false);

                newRecipe.addStep(stepInfo);
            }

            recipeList.Add(newRecipe);
            animation.PrintMessage("positive", "Recipe Saved");
        }



        //----------------------------------------------------------------------------\\
        // This method displays a selected recipe with ingredients being scaled
        public void DisplayRecipeAction()
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
                animation.PrintMessage("negative", "No Recipes Saved");
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

            Console.WriteLine();
            // Get the user's recipe selection.
            do
            {
                Console.Write("Enter Your Numeric Selection: ");
                userInput = Console.ReadLine();
            } while (errorControl.CheckForPositiveNumber(userInput) == false
                     || errorControl.CheckForRecipe(userInput, recipeList.Count) == false);

            recipeIndex = int.Parse(userInput) - 1;

            do
            {
                PrintTitle();
                Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
                Console.WriteLine("Select Your Scale:" +
                                  "\n1) Default (1x)" +
                                  "\n2) Double (2x)" +
                                  "\n3) Triple (3x)" +
                                  "\n4) Half (0.5)" +
                                  "\n");

                do
                {
                    // Prompt the user to enter their selection of scale
                    Console.Write("Enter Your Selection Of Scale: ");
                    // Read the user input from the console, convert it to lowercase, and trim it to 2 characters
                    userInput = Console.ReadLine().ToLower();

                    recipeScale = errorControl.CheckSetScale(userInput);
                } while (recipeScale == 0);

                PrintTitle();
                Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
                Console.WriteLine(recipeList[recipeIndex].DisplayRecipe(recipeScale));

                Console.WriteLine("\nWould You Like To:" +
                      "\n1) Reset Scale" +
                      "\n2) Return To Menu" +
                      "\n");
                Console.Write("Enter Your Numeric Selection: ");
                userInput = Console.ReadLine();
            } while (errorControl.CheckSetScaleMenuChoice(userInput));
        }

        //----------------------------------------------------------------------------\\
        public string SetCustomScale()
        {
            string unitOfMeasurement;
            PrintTitle();
            Console.Write("Please Enter The Singluar Form Of Your Unit Of Measurement: ");
            unitOfMeasurement = Console.ReadLine();

            Console.Write("Please Enter The Plural Form Of Your Unit Of Measurement: ");
            unitOfMeasurement += "/" + Console.ReadLine();

            return unitOfMeasurement;
        }
    }
}
//----------------------------------------------------------------------------\\


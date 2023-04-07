using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace PROG6221_POE;
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

        if (recipeList.Count() > 0)
        {
            Console.WriteLine("A Recipe Is Already Present In Storage. " +
                              "To Add A New Recipe, Storage Must Be Cleared");
            do
            {
                Console.Write("Would You Like To Continue (Y/N): ");
                userInput = Console.ReadLine().ToLower();
                checkedUserInput = errorControl.CheckYesOrNo(userInput);

                switch (checkedUserInput)
                {
                    case 1:
                        animation.PrintMessage("positive", "\nRecipe Deleted");
                        break;
                    default:
                        break;
                }

            } while (checkedUserInput == 0);
        }

        Recipe newRecipe;

        do
        {
            PrintTitle();
            Console.Write("Please Enter The Name Of The New Recipe: ");
            recipeName = Console.ReadLine();
        } while (errorControl.CheckForNull(recipeName) == false);

        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + recipeName);
            Console.WriteLine();
            Console.Write("How Many Ingredients Do You Want To Add: ");
            userInput = Console.ReadLine();
        } while (errorControl.CheckForNumber(userInput) == false);


        numIngredients = int.Parse(userInput);

        if (numIngredients == 0)
        {
            animation.PrintMessage("negative", "No Ingredients To Be Added. " +
                                   "Create Recipe Aborted"); //Might need another clear line
            return;
        }

        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + recipeName);
            Console.WriteLine();
            Console.Write("How Many Steps Do You Want To Add: ");
            userInput = Console.ReadLine();
        } while (errorControl.CheckForNumber(userInput) == false);

        numSteps = int.Parse(userInput);

        if (numSteps == 0)
        {
            animation.PrintMessage("negative", "No Steps To Be Added. Create Recipe Aborted");
            return;
        }

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
            } while (errorControl.CheckForNull(ingrerdientName) == false);

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
                userInput = Console.ReadLine().ToLower();

                ingredientUnitOfMeasurement = errorControl.CheckSelectUnit(userInput);

            } while (ingredientUnitOfMeasurement.Equals("Invalid"));

            Console.WriteLine();

            do
            {
                Console.Write("Please Enter The Quantity For \""
                              + ingrerdientName + "\" (x.xx): ");
                userInput = Console.ReadLine();
            } while (errorControl.CheckForNumber(userInput) == false);

            ingredientQuantity = double.Parse(userInput);

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
            } while (errorControl.CheckForNull(stepInfo) == false);

            newRecipe.addStep(stepInfo);
        }

        recipeList.Add(newRecipe);
        animation.PrintMessage("positive", "Recipe Saved");
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

        // Get the user's recipe selection.
        do
        {
            Console.Write("\nEnter Your Numeric Selection: ");
            userInput = Console.ReadLine();
        } while (errorControl.CheckForNumber(userInput) == false);

        recipeIndex = int.Parse(userInput) - 1;

        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
            Console.WriteLine("Select Your Scale:" +
                              "\n1) Default (1x)" +
                              "\n2) Double (2x)" +
                              "\n3) Triple (3x)" +
                              "\n4) Half (0.5)");
            recipeScale = setScale();

            PrintTitle();
            Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
            Console.WriteLine(recipeList[recipeIndex].displayRecipe(recipeScale));

            Console.WriteLine("\nWould You Like To:" +
                  "\n1) Reset Scale" +
                  "\n2) Return To Menu");
            userInput = Console.ReadLine();
        } while (errorControl.CheckSetScaleMenuChoice(userInput));
    }

    //----------------------------------------------------------------------------\\
    // A  method that sets the recipe scale and returns it as a double data type
    public double setScale()
    {
        //Variables
        string scale;//Store user input for the scale
        double recipeScale = 1;//Store the recipe scale

        //A do-while loop to prompt the user to enter the scale until the input is correct
        Console.WriteLine();
        do
        {
            // Prompt the user to enter their selection of scale
            Console.Write("Enter Your Selection Of Scale: ");
            // Read the user input from the console, convert it to lowercase, and trim it to 2 characters
            scale = Console.ReadLine().ToLower();

            recipeScale = errorControl.CheckSetScale(scale);
        } while (recipeScale == 0);

        // Return the recipe scale as a double
        return recipeScale;
    }
}
//----------------------------------------------------------------------------\\


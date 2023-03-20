namespace PROG6221_POE;
class Program
{
    private List<Recipe> recipeList = new List<Recipe>();

    static void Main(string[] args)
    {
        Program run = new Program();
        run.Menu();
    }

    public void printTitle()
    {
        Console.WriteLine("RECIPE BOOK PROGRAMME" +
                  "\n---------------------");
    }

    public void Menu()
    {
        int menuSelection = 0;

        printTitle();

        Console.WriteLine("1) Enter New Recipe" +
                          "\n2) Display Recipe" +
                          "\n3) Delete Recipe" +
                          "\n4) Exit");
        Console.Write("\n\nEnter Your Numeric Selection: ");

        try
        {
            menuSelection = int.Parse(Console.ReadLine());
        }
        catch
        {
            incorrectEntryPrompt();
            Menu();
        }

        switch (menuSelection)
        {
            case 1:
                Console.Clear();
                printTitle();
                createRecipe();
                break;
            case 2:
                Console.Clear();
                printTitle();
                break;
            case 3:
                Console.Clear();
                printTitle();
                recipeList.Clear();
                Console.WriteLine("All Recipes Have Been Deleted");
                break;
            case 4:
                Console.Clear();
                Environment.Exit(0);
                break;
        }
        Menu();
    }

    public void incorrectEntryPrompt()
    {
        Console.WriteLine("\nInvalid Entry! Please Try Again.");
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
        Console.Clear();
    }

    public void createRecipe()
    {
        int numIngredients = 0;
        Boolean conditionPass = false;
        Boolean? isThereAnIngrediantToAdd;

        if (recipeList.Count > 0)
        {
            Console.WriteLine("A Recipe Is Already Present In Storage. " +
                              "To Add A New Recipe, Storage Must Be Cleared");
            Console.Write("Would You Like To Continue (Y/N): ");


            if (Console.ReadLine().ToLower().Equals("y"))
            {
                recipeList.Clear();
            }
            else
            {
                return;
            }
        }
        Console.Write("Please Enter The Name Of The New Recipe: ");
        Recipe newRecipe = new Recipe(Console.ReadLine());

        do
        {
            Console.Write("\nDo You Have An Ingrediant To Add (Y/N): ");

            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.Clear();
                printTitle();

                string ingerdiantName;
                double ingrediantQuantity;
                string ingrediantUnitOfMeasurement;

                Console.Write("\nPlease Enter The Name Of The Ingrediant: ");
                ingerdiantName = Console.ReadLine();

                Console.Write("\nPlease Enter The Unit Of Measurement For \""
                              + ingerdiantName + "\": ");
                ingrediantUnitOfMeasurement = Console.ReadLine();

                Console.Write("\nPlease Enter The Quantity For\""
                              + ingerdiantName + "\": ");

                newRecipe.addIngredient();
            }
            isThereAnIngrediantToAdd = true;
        } while (isThereAnIngrediantToAdd == true);
    }

    public void displayRecipe()
    {
        int recipeNum = 1;
        Console.WriteLine("Please Select The Recipe You Want To Display");


        foreach (Recipe recipe in recipeList)
        {
            Console.WriteLine(recipeNum + ") " + recipe.RecipeName);
            recipeNum++;
        }
    }

}


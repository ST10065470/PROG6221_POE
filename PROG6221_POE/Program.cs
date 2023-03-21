namespace PROG6221_POE;
class Program
{
    private List<Recipe> recipeList = new List<Recipe>();

    static void Main(string[] args)
    {
        Program run = new Program();
        run.Menu();
    }

    public void PrintTitle()
    {
        Console.WriteLine("RECIPE BOOK PROGRAMME" +
                  "\n---------------------");
    }

    public void Menu()
    {
        int menuSelection = 0;

        PrintTitle();

        Console.WriteLine("1) Enter New Recipe" +
                          "\n2) Display Recipe" +
                          "\n3) Delete Recipe" +
                          "\n4) Exit");
        Console.Write("\nEnter Your Numeric Selection: ");

        try
        {
            menuSelection = int.Parse(Console.ReadLine());
        }
        catch
        {
            
        }

        switch (menuSelection)
        {
            case 1:
                Console.Clear();
                PrintTitle();
                CreateRecipe();
                break;
            case 2:
                Console.Clear();
                PrintTitle();
                break;
            case 3:
                DeleteRecipe();
                break;
            case 4:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                IncorrectEntryPrompt();
                Console.Clear();
                Menu();
                break;
        }
        Menu();
    }

    public void IncorrectEntryPrompt()
    {
        ClearCurrentConsoleLine();
        Console.Write("Invalid Entry! Press Try Again.");
        Thread.Sleep(1000);
        Console.SetCursorPosition(0, Console.CursorTop);
    }

    public void DeleteRecipe()
    {
        Console.Clear();
        PrintTitle();

        Boolean confirmInputCorrect = false;
        string userInput;

        do
        {
            Console.Write("Are You Sure You Want To Delete The Saved Recipe (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("y"))
        {
            recipeList.Clear();
            Console.WriteLine("\nRecipe Deleted!");
            Thread.Sleep(1000);
            confirmInputCorrect = true;
        }
        else if (userInput.Equals("n"))
        {
            Console.Clear();
                confirmInputCorrect = true;
        }
        else
        {
            IncorrectEntryPrompt();
        }
        } while (confirmInputCorrect == false);
    }

    public void CreateRecipe()
    {
        int numIngredients = 0;
        Boolean? conditionPass = false;
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
            else if (Console.ReadLine().ToLower().Equals("n"))
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
                PrintTitle();

                string ingerdiantName;
                double ingrediantQuantity = 0;
                string ingrediantUnitOfMeasurement;

                Console.Write("\nPlease Enter The Name Of The Ingrediant: ");
                ingerdiantName = Console.ReadLine();

                Console.Write("\nPlease Enter The Unit Of Measurement For \""
                              + ingerdiantName + "\": ");
                ingrediantUnitOfMeasurement = Console.ReadLine();

                while (conditionPass == false)
                {
                    Console.Write("\nPlease Enter The Quantity For\""
                                  + ingerdiantName + "\" (x.xx): ");
                    conditionPass = double.TryParse(Console.ReadLine(),
                                                    out ingrediantQuantity);
                    if (conditionPass == false)
                    {
                        Console.WriteLine("Wrong");
                        Console.Write("\b");
                    }
                }

                newRecipe.addIngredient(ingerdiantName, ingrediantUnitOfMeasurement, ingrediantQuantity);
            }
            isThereAnIngrediantToAdd = true;
        } while (isThereAnIngrediantToAdd == true);
    }

    public void DisplayRecipe()
    {
        int recipeNum = 1;
        Console.WriteLine("Please Select The Recipe You Want To Display");


        foreach (Recipe recipe in recipeList)
        {
            Console.WriteLine(recipeNum + ") " + recipe.RecipeName);
            recipeNum++;
        }
    }

    public static void ClearCurrentConsoleLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }
}


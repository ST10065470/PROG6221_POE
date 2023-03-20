using System.Security.Cryptography.X509Certificates;

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
                break;
            case 4:
                Console.Clear();
                Environment.Exit(0);
                break;
        }

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
        Console.Write("Please Enter The Name Of The New Recipe");
        Recipe newRecipe = new Recipe(Console.ReadLine());
    }
    
}


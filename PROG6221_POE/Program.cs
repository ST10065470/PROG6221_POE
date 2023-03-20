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

    public void Menu()
    {
        int menuSelection = 0;

        Console.WriteLine("RECIPE BOOK PROGRAMME" +
                          "\n---------------------");
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
        }

        switch (menuSelection)
        {
            case 1:
                createRecipe();
                break;
            case 2:
                break;
            case 3:
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
        Menu();
    }

    public void createRecipe()
    {
        Recipe newRecipe = new Recipe();
    }
    
}


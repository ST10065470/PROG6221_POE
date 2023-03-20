namespace PROG6221_POE;
class Program
{
    static void Main(string[] args)
    {
        Program run = new Program();
        run.Menu();
    }

    public void Menu()
    {
        Console.WriteLine("RECIPE BOOK PROGRAMME" +
                          "\n---------------------");
        Console.WriteLine("1) Enter New Recipe" +
                          "\n2) Display Recipe" +
                          "\n3) Delete Recipe");
    }
}


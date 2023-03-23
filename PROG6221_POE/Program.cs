using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace PROG6221_POE;
class Program
{
    private List<Recipe> recipeList = new List<Recipe>();
    //----------------------------------------------------------------------------\\
    static void Main(string[] args)
    {
        Program run = new Program();
        run.Menu();
    }

    //----------------------------------------------------------------------------\\

    public void PrintTitle()
    {
        Console.Clear();
        Console.WriteLine("RECIPE BOOK PROGRAMME");
        Console.WriteLine("---------------------");
    }

    //----------------------------------------------------------------------------\\

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
                PrintTitle();
                CreateRecipe();
                break;
            case 2:
                DisplayRecipe();
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

    //----------------------------------------------------------------------------\\

    public void IncorrectEntryPrompt()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        ClearCurrentConsoleLine();
        Console.Write("Invalid Entry! Press Try Again");
        loadingAnimation(Console.ForegroundColor);
        ClearCurrentConsoleLine();
        Console.SetCursorPosition(0, Console.CursorTop + 1);
    }

    //----------------------------------------------------------------------------\\

    public void DeleteRecipe()
    {
        PrintTitle();

        Boolean confirmInputCorrect = false;
        string userInput;

        if (recipeList.Count() == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No Recipes Saved");
            loadingAnimation(Console.ForegroundColor);
            return;
        }

        do
        {
            Console.Write("Are You Sure You Want To Delete The Saved Recipe (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("y"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                recipeList.Clear();
                PrintTitle();
                Console.Write("Recipe Deleted");
                loadingAnimation(Console.ForegroundColor);
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

    //----------------------------------------------------------------------------\\

    public void CreateRecipe()
    {
        string userInput;
        string recipeName;
        int numIngredients;
        int numSteps;
        int stepCount = 1;
        Boolean confirmInputCorrect = false;

        if (recipeList.Count() > 0)
        {
            Console.WriteLine("A Recipe Is Already Present In Storage. " +
                              "To Add A New Recipe, Storage Must Be Cleared");
            do
            {
                Console.Write("Would You Like To Continue (Y/N): ");
                userInput = Console.ReadLine().ToLower();

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

            if (confirmInputCorrect == false)
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

            if (confirmInputCorrect == false)
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

            do
            {
                Console.Write("Please Select The Unit Of Measurement For \""
                          + ingrerdientName + "\": ");
                Console.WriteLine("\n1) Teaspoon(s)" +
                                  "\n2) Tablespoon(s)" +
                                  "\n3) Cup(s)" +
                                  "\n4) Gram(s)" +
                                  "\n5) Kilogram(s)");
                Console.Write("\nEnter Your Selection: ");
                userInput = (Console.ReadLine() + " ").ToLower().Substring(0, 2);

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
                Console.Write("Please Enter Step Number " + stepCount + ": ");
                stepInfo = Console.ReadLine();

                if (stepInfo.Equals(""))
                {
                    IncorrectEntryPrompt();
                }
            } while (stepInfo.Equals(""));

            newRecipe.addStep(stepInfo);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        recipeList.Add(newRecipe);
        PrintTitle();
        Console.Write("Recipe Saved");
        loadingAnimation(Console.ForegroundColor);
    }



    //----------------------------------------------------------------------------\\

    public void DisplayRecipe()
    {
        PrintTitle();

        int recipeNum = 1;
        int recipeIndex = 0;
        double recipeScale = 0;
        Boolean confirmInputCorrect = false;
        string userInput;

        if (recipeList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No Recipes Saved");
            loadingAnimation(Console.ForegroundColor);
            return;
        }

        Console.WriteLine("Please Select The Recipe You Want To Display:");

        foreach (Recipe recipe in recipeList)
        {
            Console.WriteLine(recipeNum + ") " + recipe.RecipeName);
            recipeNum++;
        }

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

        PrintTitle();
        Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
        Console.Write("Select Your Scale:" +
                          "\n1) Default (1x)" +
                          "\n2) Double (2x)" +
                          "\n3) Triple (3x)" +
                          "\n4) Half (0.5)");
        //Console.Write("\nEnter Your Selection Of Scale: ");
        Console.WriteLine();
        recipeScale = setScale();

        PrintTitle();
        Console.WriteLine("Recipe: " + recipeList[recipeIndex].RecipeName + "\n");
        Console.WriteLine(recipeList[recipeIndex].displayRecipe(recipeScale));

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
                return;
            }
            else
            {
                IncorrectEntryPrompt();
            }
        } while (true);
    }

    //----------------------------------------------------------------------------\\

    public static void ClearCurrentConsoleLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    //----------------------------------------------------------------------------\\

    public void loadingAnimation(ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        for (int pos = 0; pos < 3; pos++)
        {
            Thread.Sleep(400);
            Console.Write(".");
        }
        Thread.Sleep(400);
        Console.ForegroundColor = ConsoleColor.White;
    }

    //----------------------------------------------------------------------------\\
    public double setScale()
    {
        string scale;
        double recipeScale = 1;
        Boolean confirmInputCorrect = false;

        do
        {
            Console.Write("\nEnter Your Selection Of Scale: ");
            scale = (Console.ReadLine() + "  ").ToLower().Substring(0, 2);

            switch (scale)
            {
                case "4 ":
                case "0.":
                case "ha":
                    recipeScale = 0.5;
                    confirmInputCorrect = true;
                    break;
                case "1 ":
                case "de":
                    recipeScale = 1;
                    confirmInputCorrect = true;
                    break;
                case "2 ":
                case "do":
                    recipeScale = 2;
                    confirmInputCorrect = true;
                    break;
                case "3 ":
                case "tr":
                    recipeScale = 3;
                    confirmInputCorrect = true;
                    break;
                default:
                    IncorrectEntryPrompt();
                    break;
            }

        } while (confirmInputCorrect == false);

        return recipeScale;
    }

}
//----------------------------------------------------------------------------\\


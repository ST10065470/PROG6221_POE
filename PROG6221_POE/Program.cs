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
        ClearCurrentConsoleLine();
        Console.Write("Invalid Entry! Press Try Again");
        loadingAnimation();
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
            Console.Write("No Recipes Saved");
            loadingAnimation();
            return;
        }

        do
        {
            Console.Write("Are You Sure You Want To Delete The Saved Recipe (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("y"))
            {
                recipeList.Clear();
                PrintTitle();
                Console.Write("Recipe Deleted");
                loadingAnimation();
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
        Boolean isThereAnIngrediantToAdd = true;
        Boolean isThereAStepToAdd = true;
        string userInput;
        Boolean confirmInputCorrect = false;
        int stepCount = 1;

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
                    recipeList.Clear();
                    Console.Write("\nRecipe Deleted");
                    loadingAnimation();
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
            newRecipe = new Recipe(Console.ReadLine());
            if (newRecipe.RecipeName.Equals(""))
            {
                IncorrectEntryPrompt();
                PrintTitle();
            }
        } while (newRecipe.RecipeName.Equals(""));
        

        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + newRecipe.RecipeName);
            Console.WriteLine();
            Console.Write("Do You Have An Ingrediant To Add (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("y"))
            {
                string ingerdiantName;
                double ingrediantQuantity = 0;
                string ingrediantUnitOfMeasurement = "";

                Console.WriteLine();

                do
                {
                    Console.Write("Please Enter The Name Of The Ingrediant: ");
                    ingerdiantName = Console.ReadLine();
                    if (ingerdiantName.Equals(""))
                    {
                        IncorrectEntryPrompt();
                    }
                    
                } while (ingerdiantName.Equals(""));

                Console.WriteLine();

                do
                {
                    Console.Write("Please Select The Unit Of Measurement For \""
                              + ingerdiantName + "\": ");
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
                            ingrediantUnitOfMeasurement = "Teaspoon(s)";
                            confirmInputCorrect = true;
                            break;
                        case "2 ":
                        case "2)":
                        case "ta":
                            ingrediantUnitOfMeasurement = "Tablespoon(s)";
                            confirmInputCorrect = true;
                            break;
                        case "3 ":
                        case "3)":
                        case "cu":
                            ingrediantUnitOfMeasurement = "Cup(s)";
                            confirmInputCorrect = true;
                            break;
                        case "4 ":
                        case "4)":
                        case "gr":
                            ingrediantUnitOfMeasurement = "Gram(s)";
                            confirmInputCorrect = true;
                            break;
                        case "5 ":
                        case "5)":
                        case "ki":
                            ingrediantUnitOfMeasurement = "Kilogram(s)";
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
                                  + ingerdiantName + "\" (x.xx): ");
                    confirmInputCorrect = double.TryParse(Console.ReadLine(),
                                                    out ingrediantQuantity);

                    if (confirmInputCorrect == false)
                    {
                        IncorrectEntryPrompt();
                    }
                    else
                    {
                        confirmInputCorrect = true;
                    }
                } while (confirmInputCorrect == false);

                newRecipe.addIngredient(ingerdiantName, ingrediantUnitOfMeasurement,
                                        ingrediantQuantity);
            }

            else if (userInput.Equals("n"))
            {
                if (newRecipe.IngredientsList.Count == 0)
                {
                    Console.Write("\nNo Ingredients Added! New Recipe Did Not Save");
                    recipeList.Clear();
                    loadingAnimation();
                    return;
                }
                Console.Clear();
                isThereAnIngrediantToAdd = false;
            }

            else
            {
                IncorrectEntryPrompt();
            }
        } while (isThereAnIngrediantToAdd == true);

        do
        {
            PrintTitle();
            Console.WriteLine("Recipe: " + newRecipe.RecipeName);
            Console.Write("\nDo You Have A Step To Add (Y/N): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("y"))
            {
                string step;

                PrintTitle();
                Console.WriteLine("Recipe: " + newRecipe.RecipeName);
                Console.WriteLine();
                do
                {
                Console.Write("Please Enter Step Number " + stepCount + ": ");
                step = Console.ReadLine();

                    if (step.Equals(""))
                    {
                        IncorrectEntryPrompt();
                    }
                } while (step.Equals(""));
                newRecipe.addStep(step);
                stepCount++;
            }
            else if (userInput.Equals("n"))
            {
                if (newRecipe.StepsList.Count() == 0)
                {
                    Console.Write("\nNo Steps Added! New Recipe Did Not Save");
                    recipeList.Clear();
                    loadingAnimation();
                    return;
                }
                else
                { 
                isThereAStepToAdd = false;
                }
            }
            else
            {
                IncorrectEntryPrompt();
            }

        } while (isThereAStepToAdd == true);

        recipeList.Add(newRecipe);
        PrintTitle();
        Console.Write("Recipe Saved");
        loadingAnimation();
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
            Console.Write("No Recipes Saved");
            loadingAnimation();
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

    public void loadingAnimation() {
        for (int pos = 0; pos < 3; pos++)
        {
            Thread.Sleep(400);
            Console.Write(".");
        }
        Thread.Sleep(400);
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


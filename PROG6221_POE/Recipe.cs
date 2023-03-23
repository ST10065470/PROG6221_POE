using System;
namespace PROG6221_POE
{
	public class Recipe
	{
        private Ingredient[] ingredientsList;
        private string[] stepsList;
        private string recipeName;
//----------------------------------------------------------------------------\\

        public string RecipeName { get => recipeName; set => recipeName = value; }
        public Ingredient[] IngredientsList { get => ingredientsList; set => ingredientsList = value; }
        public string[] StepsList { get => stepsList; set => stepsList = value; }

        //----------------------------------------------------------------------------\\

        public Recipe(string recipeName, int numIngredients, int numSteps)
        {
            IngredientsList = new Ingredient[numIngredients];
            StepsList = new string[numSteps];
            this.RecipeName = recipeName;
        }

//----------------------------------------------------------------------------\\

        public void addIngredient(string ingredientName, string unitOfMeasurement,
                                  double ingredientQuantity)
        {
            int index = 0;
            Ingredient ingredientToAdd = new Ingredient(ingredientName, unitOfMeasurement,
                                                        ingredientQuantity);

            for  (index = 0;  index < IngredientsList.Count(); index++)
            {
                if (IngredientsList[index] == null)
                {
                    break;
                }
            }
            IngredientsList[index] = ingredientToAdd;
        }

//----------------------------------------------------------------------------\\

        public void addStep(string step)
        {
            int index = 0;

            for (index = 0; index < StepsList.Count(); index++)
            {
                if (StepsList[index] == null)
                {
                    break;
                }
            }
            StepsList[index] = step;
        }

//----------------------------------------------------------------------------\\

        public string displayRecipe(double scale)
        {
            string ingredientsToString = "Ingredients:";
            string stepsToString = "Steps:";
            string recipe;
            int stepCount = 1;

            foreach (Ingredient ingredient in IngredientsList)
            {

                ingredientsToString += "\n" + correctQuantityAndMeasurement(scale
                    , ingredient.Quantity, ingredient.UnitOfMeasurement) + " "
                    + ingredient.Name;
            }

            foreach (string step in StepsList)
            {
                stepsToString += "\n" + stepCount + ". " + stepsList[stepCount - 1];
                stepCount++;
            }

            recipe = ingredientsToString + "\n\n" + stepsToString;
            return recipe;
        }

//----------------------------------------------------------------------------\\

        public string correctQuantityAndMeasurement(double scale, double quantity,
                                               string unitOfMeasurement)
        {
            double scaleCorrectedQuantity = (quantity * scale);
            string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement;

            if (unitOfMeasurement.Equals("Teaspoon(s)"))
            {
                if ((scaleCorrectedQuantity % 4) == 0)
                {
                    scaleCorrectedQuantity = scaleCorrectedQuantity / 4.00;
                    correctQuantityAndMeasurement = scaleCorrectedQuantity + " Tablespoon(s)";

                    if (scaleCorrectedQuantity % 16 == 0)
                    {
                        scaleCorrectedQuantity = scaleCorrectedQuantity / 16.00;
                        correctQuantityAndMeasurement = scaleCorrectedQuantity + " Cup(s)";
                        return correctQuantityAndMeasurement;
                    }
                    else
                    {
                        return correctQuantityAndMeasurement;
                    }
                }
                else
                {
                    return correctQuantityAndMeasurement;
                }

            }

            else if (unitOfMeasurement.Equals("Tablespoon(s)"))
            {
                if ((scaleCorrectedQuantity % 16) == 0)
                {
                    correctQuantityAndMeasurement = "Cup(s)";
                    quantity = quantity / 16.00;

                    return quantity + " " + correctQuantityAndMeasurement;
                }
                else if (quantity == 1 && scale == 0.5)
                {
                    correctQuantityAndMeasurement = "Teaspoon(s)";
                    return (quantity * 2.00) + " " + correctQuantityAndMeasurement;
                }
                else
                {
                    return correctQuantityAndMeasurement;
                }
            }
            if (unitOfMeasurement.Equals("Kilograms(s)"))
            {
                if (scale == 0.5 && quantity == 1)
                {
                    // Convert 1 kilogram to 500 grams
                    correctQuantityAndMeasurement = "500 Gram(s)";
                    return correctQuantityAndMeasurement;
                }
                else
                {
                   return correctQuantityAndMeasurement;
                }
            }
            else if (unitOfMeasurement.Equals("Gram(s)"))
            {
                if (scaleCorrectedQuantity >= 1000)
                {
                    // Convert grams to kilograms
                    correctQuantityAndMeasurement = (scaleCorrectedQuantity / 1000.00) + " Kilogram(s)";
                    return correctQuantityAndMeasurement;
                }
                else
                {
                    return correctQuantityAndMeasurement;
                }
            }
            else
            {
                return correctQuantityAndMeasurement;
            }
        }
        }

//----------------------------------------------------------------------------\\
    }



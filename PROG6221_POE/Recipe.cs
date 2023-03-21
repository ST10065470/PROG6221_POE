using System;
namespace PROG6221_POE
{
	public class Recipe
	{
        private List<Ingredient> ingredientsList;
        private List<string> stepsList;
        private string recipeName;
//----------------------------------------------------------------------------\\

        public string RecipeName { get => recipeName; set => recipeName = value; }
        public List<Ingredient> IngredientsList { get => ingredientsList; set => ingredientsList = value; }
        public List<string> StepsList { get => stepsList; set => stepsList = value; }

        //----------------------------------------------------------------------------\\

        public Recipe(string recipeName)
        {
            IngredientsList = new List<Ingredient>();
            StepsList = new List<string>();
            this.RecipeName = recipeName;
        }

//----------------------------------------------------------------------------\\

        public void addIngredient(string ingredientName, string unitOfMeasurement,
                                  double ingredientQuantity)
        {
            Ingredient ingredientToAdd = new Ingredient(ingredientName, unitOfMeasurement,
                                                        ingredientQuantity);
            IngredientsList.Add(ingredientToAdd);
        }

//----------------------------------------------------------------------------\\

        public void addStep(string step)
        {
            StepsList.Add(step);
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
                ingredientsToString += "\n" + double.Round((ingredient.Quantity * scale), 2)
                    + " " + ingredient.UnitOfMeasurement + " "
                    + ingredient.Name;
            }

            foreach (string step in StepsList)
            {
                stepsToString += "\n" + stepCount + ". " + stepsList[stepCount - 1];
                stepCount++;
            }

            recipe = RecipeName + ":\n\n" + ingredientsToString + "\n\n" + stepsToString;
            return recipe;
        }

//----------------------------------------------------------------------------\\

    }
}


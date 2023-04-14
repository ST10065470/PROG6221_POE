using System;
namespace PROG6221_POE
{
    public class Recipe
    {
        private Ingredient[] ingredientsList;
        private string[] stepsList;
        private string recipeName;
        //----------------------------------------------------------------------------\\
        //Getters And Setters
        public string RecipeName { get => recipeName; set => recipeName = value; }
        public Ingredient[] IngredientsList { get => ingredientsList; set => ingredientsList = value; }
        public string[] StepsList { get => stepsList; set => stepsList = value; }

        //----------------------------------------------------------------------------\\

        public Recipe(string recipeName, int numIngredients, int numSteps)
        {
            // Create a new array of Ingredient objects with length numIngredients, and assign it to the IngredientsList field of the Recipe object
            IngredientsList = new Ingredient[numIngredients];

            // Create a new array of strings with length numSteps, and assign it to the StepsList field of the Recipe object
            StepsList = new string[numSteps];

            // Assign the value of recipeName to the RecipeName field of the Recipe object
            this.RecipeName = recipeName;
        }


        //----------------------------------------------------------------------------\\

        public void addIngredient(string ingredientName, string unitOfMeasurement,
                                  double ingredientQuantity)
        {
            // Initialize a counter variable.
            int index = 0;

            // Create an instance of the Ingredient class based on user-provided parameters.
            Ingredient ingredientToAdd = new Ingredient(ingredientName, unitOfMeasurement,
                                                        ingredientQuantity);

            // Search through the IngredientsList collection for an empty position.
            // If found, increment 'index', until a null is encountered or end of collection is reached.
            for (index = 0; index < IngredientsList.Count(); index++)
            {
                if (IngredientsList[index] == null)
                {
                    break;
                }
            }

            // Add the newly created Ingredient object to IngredientsList at next available position. 
            IngredientsList[index] = ingredientToAdd;
        }

        //----------------------------------------------------------------------------\\

        // This method adds a step to StepsList
        public void addStep(string step)
        {
            int index = 0; // Initialize index variable with zero

            // Loop through the StepsList
            for (index = 0; index < StepsList.Count(); index++)
            {
                // If current item in list is null, exit loop
                if (StepsList[index] == null)
                {
                    break;
                }
            }

            // Place the new "step" in first empty location or at end of list 
            StepsList[index] = step;
        }

        //----------------------------------------------------------------------------\\

        // Method to display a recipe with ingredients and steps
        public string displayRecipe(double scale)
        {
            // Initialize strings to store the ingredients and steps
            string ingredientsToString = "Ingredients:";
            string stepsToString = "Steps:";

            // Initialize a counter for the steps
            int stepCount = 1;

            // Iterate over the list of ingredients
            foreach (Ingredient ingredient in IngredientsList)
            {
                // Append the correct quantity and measurement for the scaled ingredient to the string
                ingredientsToString += "\n" + correctQuantityAndMeasurement(scale, ingredient.Quantity, ingredient.UnitOfMeasurement)
                    + " " + ingredient.Name;
            }

            // Iterate over the list of steps
            foreach (string step in StepsList)
            {
                // Append the step number and text to the string
                stepsToString += "\n" + stepCount + ". " + stepsList[stepCount - 1];

                // Increment the step counter
                stepCount++;
            }

            // Combine the strings for ingredients and steps
            string recipe = ingredientsToString + "\n\n" + stepsToString;

            // Return the combined recipe string
            return recipe;
        }


        //----------------------------------------------------------------------------\\
        /* This method takes in a scale factor, a quantity value,
        and a string representing the unit of measurement for that value
        and returns the correct unit of measurement based on the quantity entered*/
        public string correctQuantityAndMeasurement(double scale, double quantity,
                                               string unitOfMeasurement)
        {
            double scaleCorrectedQuantity = (quantity * scale); //The scale corrected quantity
            string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement; //A string which stores the quantity and unit of measurement

            // If originally entered measurements was teaspoons:
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
            // If originally entered measurements was tablespoons:
            else if (unitOfMeasurement.Equals("Tablespoon(s)"))
            {
                if ((scaleCorrectedQuantity % 16) == 0)
                {
                    correctQuantityAndMeasurement = "Cup(s)";
                    scaleCorrectedQuantity = scaleCorrectedQuantity / 16.00;

                    return scaleCorrectedQuantity + " " + correctQuantityAndMeasurement;
                }
                else if (quantity == 1 && scale == 0.5)
                {
                    correctQuantityAndMeasurement = "Teaspoon(s)";
                    return (quantity * 2.00) + " " + correctQuantityAndMeasurement;
                }
                else if (quantity == 0.5 && scale == 0.5)
                {
                    correctQuantityAndMeasurement = "Teaspoon(s)";
                    return (quantity * 1.00) + " " + correctQuantityAndMeasurement;
                }
                else
                {
                    return correctQuantityAndMeasurement;
                }
            }
            // If originally entered measurements was kilograms:
            else if (unitOfMeasurement.Equals("Kilograms(s)"))
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
            // If originally entered measurements was grams:
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



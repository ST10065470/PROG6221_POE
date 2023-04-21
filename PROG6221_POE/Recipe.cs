using System;
using static System.Formats.Asn1.AsnWriter;

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
        public string DisplayRecipe(double scale)
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
                ingredientsToString += "\n" + CorrectQuantityAndMeasurement(scale, ingredient.Quantity, ingredient.UnitOfMeasurement)
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
        public string CorrectQuantityAndMeasurement(double scale, double quantity,
                                               string unitOfMeasurement)
        {
            double scaleCorrectedQuantity = (quantity * scale); //The scale corrected quantity
            string correctQuantityAndMeasurement = scaleCorrectedQuantity + " "
                + unitOfMeasurement; //A string which stores the quantity and unit of measurement

            if (unitOfMeasurement.Contains('/'))
            {
                return IfCustomScale(unitOfMeasurement, correctQuantityAndMeasurement, scaleCorrectedQuantity);
            }

            // If originally entered measurements was teaspoons:
            else
            {
                switch (unitOfMeasurement)
                {
                    case "Teaspoon(s)":
                        return IfTeaspoons(scaleCorrectedQuantity);
                    case "Tablespoon(s)":
                        return IfTableSpoons(scaleCorrectedQuantity);
                    case "Cups":
                        return IfCups(scaleCorrectedQuantity);
                    case "Kilograms(s)":
                        return IfKilograms(scaleCorrectedQuantity);
                    case "Gram(s)":
                        return IfGrams(scaleCorrectedQuantity);
                    default:
                        return null;
                }
            }
        }

        public string IfCustomScale(string unitOfMeasurement, string correctQuantityAndMeasurement, double scaleCorrectedQuantity)
        {
            // Split the unit of measurement string into two parts separated by '/'
            string[] parts = unitOfMeasurement.Split('/');

            // Construct a string with the scaled quantity and the appropriate unit of measurement based on the parts array
            correctQuantityAndMeasurement = scaleCorrectedQuantity + " "
                + (scaleCorrectedQuantity == 1 ? parts[0] : parts[1]) + " Of";

            // Return the constructed string
            return correctQuantityAndMeasurement;
        }

        public string IfTeaspoons(double scaleCorrectedQuantity)
        {
            // If the quantity is a multiple of 4, convert to tablespoons and possibly cups
            if (scaleCorrectedQuantity % 4 == 0)
            {
                // Divide the quantity by 4 to convert to tablespoons
                scaleCorrectedQuantity /= 4.0;

                // Call the IfTableSpoons function to get the converted quantity and measurement
                string correctQuantityAndMeasurement = IfTableSpoons(scaleCorrectedQuantity);

                // If the converted quantity is greater than or equal to 16, convert to cups
                if (scaleCorrectedQuantity >= 16)
                {
                    // Divide the quantity by 16 to convert to cups and call the IfCups function
                    scaleCorrectedQuantity /= 16;
                    return IfCups(scaleCorrectedQuantity);
                }
                else
                {
                    // Return the converted quantity and measurement
                    return correctQuantityAndMeasurement;
                }
            }
            else
            {
                // If the quantity is not a multiple of 4, return the quantity and teaspoon(s) as the unit of measurement
                string unitOfMeasurement = (scaleCorrectedQuantity > 1) ? "Teaspoons" : "Teaspoon";
                string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement + " Of";
                return correctQuantityAndMeasurement;
            }
        }

        public string IfTableSpoons(double scaleCorrectedQuantity)
        {
            // If the quantity is greater than or equal to 16, convert to cups
            if (scaleCorrectedQuantity >= 16)
            {
                // Divide the quantity by 16 to convert to cups and call the IfCups function
                scaleCorrectedQuantity /= 16;
                return IfCups(scaleCorrectedQuantity);
            }
            else if (scaleCorrectedQuantity < 1)
            {
                // If the quantity is less than 1, convert to teaspoons
                scaleCorrectedQuantity *= 4;
                return IfTeaspoons(scaleCorrectedQuantity);
            }
            else
            {
                // Otherwise, return the quantity and tablespoon(s) as the unit of measurement
                string unitOfMeasurement = (scaleCorrectedQuantity > 1) ? "Tablespoons" : "Tablespoon";
                string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement + " Of";
                return correctQuantityAndMeasurement;
            }
        }

        public string IfCups(double scaleCorrectedQuantity)
        {
            // Return the quantity and cup(s) as the unit of measurement
            string unitOfMeasurement = (scaleCorrectedQuantity > 1) ? "Cups" : "Cup";
            string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement + " Of";
            return correctQuantityAndMeasurement;
        }

        public string IfKilograms(double scaleCorrectedQuantity)
        {
            if (scaleCorrectedQuantity < 1)
            {
                scaleCorrectedQuantity *= 1000;
                return IfGrams(scaleCorrectedQuantity);
            }
            else
            {
                string unitOfMeasurement = (scaleCorrectedQuantity > 1) ? "Kilograms" : "Kilogram";
                string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement + " Of";
                return correctQuantityAndMeasurement;
            }
        }

        public string IfGrams(double scaleCorrectedQuantity)
        {
            if (scaleCorrectedQuantity >= 1000)
            {
                scaleCorrectedQuantity /= 1000;
                return IfKilograms(scaleCorrectedQuantity);
            }
            else
            {
                string unitOfMeasurement = (scaleCorrectedQuantity > 1) ? "Grams" : "Gram";
                string correctQuantityAndMeasurement = scaleCorrectedQuantity + " " + unitOfMeasurement + " Of";
                return correctQuantityAndMeasurement;
            }
        }
    }

    //----------------------------------------------------------------------------\\
}



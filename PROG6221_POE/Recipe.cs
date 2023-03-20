﻿using System;
namespace PROG6221_POE
{
	public class Recipe
	{
        private List<Ingredient> ingredientsList;
        private List<string> stepsList;

        public Recipe()
        {
            ingredientsList = new List<Ingredient>();
            stepsList = new List<string>();
        }

        public void addIngredient(string ingredientName, string unitOfMeasurement,
                                  double ingredientQuantity)
        {
            Ingredient ingredientToAdd = new Ingredient(ingredientName, unitOfMeasurement,
                                                        ingredientQuantity);
            ingredientsList.Add(ingredientToAdd);
        }

        public void addStep(string step)
        {
            stepsList.Add(step);
        }

        public string displayRecipe(double scale)
        {
            string ingredientsToString = "";

            foreach (Ingredient ingredient in ingredientsList)
            {
                ingredientsToString += ingredient.Name + ":\t"
                    + double.Round((ingredient.Quantity * scale), 2) + "\t" + ingredient.UnitOfMeasurement;
            }
            return ingredientsToString;
        }
    }
}


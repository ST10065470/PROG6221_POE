//Ethan Schoonbee ST10036509
//PROG6221 POE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PROG6221_POE
{
    public class Recipe
    {
        //declare attributes:
        private string recipeName;
        private string[] arrSteps;
        private Ingredient[] arrIngredients;


        public Recipe(string name, int numSteps, int numIngredients)
        {

            this.recipeName = name;
            arrSteps = new string[numSteps];
            Ingredients = new Ingredient[numIngredients];

        }//end constructor method

        //getters and setters:
        public string RecipeName { get => recipeName; set => recipeName = value; }
        public Ingredient[] Ingredients { get => arrIngredients; set => arrIngredients = value; }
        public string[] Steps { get => arrSteps; set => arrSteps = value; }


        public void addIngredient(string name,string unitOfMeasure, double quantity)
        {
            //decalre variables:
            int index;

            Ingredient ingredientAdd = new Ingredient(name, unitOfMeasure, quantity);

            for (index = 0; index < arrIngredients.Count(); index++) 
            {
            
                if (arrIngredients[index] == null)
                {

                    break;

                }//end if
            
            }//end for-loop

            arrIngredients[index] = ingredientAdd;

        }//end addIngredient method


        public void addStep(string step)
        {
            //decalre variables:
            int index;

            for (index = 0; index < arrSteps.Count(); index++)
            {

                if (arrSteps[index] == null)
                {

                    break;

                }//end if 

            }//end for-loop

            arrSteps[index] = step;


        }//end addStep method

    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
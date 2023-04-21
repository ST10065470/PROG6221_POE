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
    public class Ingredient
    {
        //declare attributes
        private string name;
        private double quantity;
        private int unitOfMeasure;

        //declare GLOBAL variables:
        private enum Units { Teaspoon, Tablespoon, Cup, Pint, Quart, Gallon };

        protected Ingredient()
        {



        }//end contructor method


        //Getters and Setters:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }//end name getter-setter

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }//end quanitity getter-setter

        public int UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }//end unitOfMeasure getter-setter

    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
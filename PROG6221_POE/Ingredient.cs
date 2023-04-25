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
        private string unitOfMeasure;

        //declare GLOBAL variables:
        private enum Units { Teaspoon, Tablespoon, Cup, Pint, Quart, Gallon };

        public Ingredient(string name, string unitOfMeasure, double quantity)
        {

            this.name = name;
            this.unitOfMeasure = unitOfMeasure;
            this.quantity = quantity;

        }//end contructor method


        //Getters and Setters:
        public string Name { get => Name; set => Name = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public string UnitOfMeasure { get => unitOfMeasure; set => unitOfMeasure = value; }

    }
}
//------------------------..oooOOOO_END_OF_FILE_OOOOooo..------------------------
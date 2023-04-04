using System;
namespace PROG6221_POE
{
	public class Ingredient
	{
        // Initiallizing all properties with given arguments 
        public Ingredient(string name, string unitOfMeasurement, double quantity)
        {
            this.Name = name;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.Quantity = quantity;
        }

//----------------------------------------------------------------------------\\

        private string name; // Private field representing the ingredient's name
        private string unitOfMeasurement; // Private field representing the ingredient's unit of measurement
        private double quantity; // Private field representing the ingredient's quantity

//----------------------------------------------------------------------------\\

        // public getter/setter for 'name' variable through 'Name' property   
        public string Name { get => name; set => name = value; }
        // public getter/setter for 'unitOfMeasurement' variable through 'UnitOfMeasurement' property
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; }
        // public getter/setter for 'quantity' variable through 'Quantity' property
        public double Quantity { get => quantity; set => quantity = value; }

//----------------------------------------------------------------------------\\
    }
}


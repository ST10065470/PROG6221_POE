using System;
namespace PROG6221_POE
{
	public class Ingredient
	{
        public Ingredient(string name, string unitOfMeasurement, double quantity)
        {
            this.Name = name;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.Quantity = quantity;
        }

//----------------------------------------------------------------------------\\

        private string name;
		private string unitOfMeasurement;
		private double quantity;

//----------------------------------------------------------------------------\\

        public string Name { get => name; set => name = value; }
        public string UnitOfMeasurement { get => unitOfMeasurement; set => unitOfMeasurement = value; }
        public double Quantity { get => quantity; set => quantity = value; }

//----------------------------------------------------------------------------\\
        //public void displayInfo()
        //{
        //    Console.WriteLine("Name:\t" + name);
        //    Console.WriteLine("Quantity:");
        //}
//----------------------------------------------------------------------------\\
    }
}


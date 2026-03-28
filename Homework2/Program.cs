namespace CarApp;

using CarApp.Factory;
using CarApp.Interfaces;
using System;

public class GetCarDescription
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter car type or 'done' to leave: ");
            string? input = Console.ReadLine();

            if (input == "done")
            {
                break;
            }

            if (Enum.TryParse(typeof(CarType), input, true, out var result))
            {
                ICar car = CarFactory.CreateCar((CarType)result);
                Console.WriteLine(car.GetDescription());
            }
            else
            {
                Console.WriteLine("Invalid car brand");
            }
        }
    }
}

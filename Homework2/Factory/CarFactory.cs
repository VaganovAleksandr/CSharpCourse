namespace CarApp.Factory;

using CarApp.Interfaces;
using CarApp.Models;

using System;

public enum CarType
{
    Tesla,
    Audi,
    Porsche
}

public static class CarFactory
{
    public static ICar CreateCar(CarType type)
    {
        switch (type)
        {
            case CarType.Tesla:
                return new Tesla();
            case CarType.Audi:
                return new Audi();
            case CarType.Porsche:
                return new Porsche();
            default:
                throw new ArgumentException("Invalid car brand");
        }
    }
}

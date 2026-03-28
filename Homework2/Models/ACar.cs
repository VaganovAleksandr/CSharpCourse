namespace CarApp.Models;

using CarApp.Interfaces;

public abstract class ACar : ICar
{
    protected string _brand;
    protected int _seats;
    protected bool _has_android;
    
    public ACar(string brand, int seats, bool hasAndroid)
    {
        _brand = brand;
        _seats = seats;
        _has_android = hasAndroid;
    }

    public abstract string GetEngineInfo();
    public abstract string GetTransmissionInfo();

    public virtual string GetDescription()
    {
        return $"{_brand}: {GetEngineInfo()},  {GetTransmissionInfo()}, {_seats} seats" + (_has_android ? ", has Android" : "");
    }
}

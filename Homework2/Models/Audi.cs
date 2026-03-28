namespace CarApp.Models;

using CarApp.Interfaces;

public class Audi : ACar, IMechanical, IAutomatical
{
    public Audi() : base("Audi", 5, true)
    {
    }

    public string GetMechanicalDescription()
    {
        return "Gasoline car";
    }

    public string GetAutomaticDescription()
    {
        return "Automatic transmission";
    }

    public override string GetEngineInfo()
    {
        return GetMechanicalDescription();
    }

    public override string GetTransmissionInfo()
    {
        return GetAutomaticDescription();
    }
}

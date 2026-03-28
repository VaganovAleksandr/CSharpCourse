namespace CarApp.Models;

using CarApp.Interfaces;

public class Porsche : ACar, IMechanical, IManual
{
    public Porsche() : base("Porsche", 2, false)
    {
    }

    public string GetMechanicalDescription()
    {
        return "Gasoline engine";
    }

    public string GetManualDescription()
    {
        return "Manual transmission";
    }

    public override string GetEngineInfo()
    {
        return GetMechanicalDescription();
    }

    public override string GetTransmissionInfo()
    {
        return GetManualDescription();
    }
}

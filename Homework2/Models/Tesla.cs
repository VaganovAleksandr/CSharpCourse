namespace CarApp.Models;

using CarApp.Interfaces;

public class Tesla : ACar, IElectric, INoTransmission
{
    public Tesla() : base("Tesla", 5, true)
    {
    }

    public string GetElectricDescription()
    {
        return "Electric car";
    }

    public string GetNoTransmissionDescription()
    {
        return "No transmission";
    }

    public override string GetEngineInfo()
    {
        return GetElectricDescription();
    }

    public override string GetTransmissionInfo()
    {
        return GetNoTransmissionDescription();
    }
}

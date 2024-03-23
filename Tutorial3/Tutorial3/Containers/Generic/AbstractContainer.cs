using Tutorial3.Exceptions;

namespace Tutorial3.Containers;

public abstract class AbstractContainer : IContainer
{
    public double CargoWeight { get; set; }
    protected double Height { get; set; }
    protected double CurbWeight { get; set; }
    protected double Depth { get; set; }
    public string SerialNumber { get; set; }
    protected double MaxCargoWeight { get; set; }

    protected AbstractContainer(double height, double curbWeight, double depth, string serialNumber, double maxCargoWeight)
    {
        Height = height;
        CurbWeight = curbWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxCargoWeight = maxCargoWeight;
    }

    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
        {
            throw new OverfillException("Cargo weight exceeds the maximum allowed weight.");
        }

        CargoWeight = cargoWeight;
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }
}
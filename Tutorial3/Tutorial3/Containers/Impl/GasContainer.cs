using Tutorial3.Exceptions;

namespace Tutorial3.Containers.Impl;

public class GasContainer : AbstractContainer, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double height, double curbWeight, double depth, string serialNumber, double maxCargoWeight,
        double pressure) : base(height, curbWeight, depth, serialNumber, maxCargoWeight)
    {
        Pressure = pressure;
    }

    public override void Load(double cargoWeight)
    {
        if (cargoWeight + CargoWeight > MaxCargoWeight)
        {
            throw new OverfillException("Cargo weight exceeds the maximum allowed weight.");
        }

        CargoWeight = cargoWeight;
    }

    public override void Unload()
    {
        CargoWeight *= 0.05;
    }

    public void Notify()
    {
        Console.WriteLine("There was a dangerous situation in container " + base.SerialNumber + "!");
    }
}
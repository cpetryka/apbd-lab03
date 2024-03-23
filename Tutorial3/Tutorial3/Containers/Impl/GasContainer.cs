using Tutorial3.Exceptions;

namespace Tutorial3.Containers.Impl;

public class GasContainer : AbstractContainer, IHazardNotifier
{
    private static int _sGasContainersCounter = 0;
    private double Pressure { get; set; }

    public GasContainer(double height, double curbWeight, double depth, double maxCargoWeight, double pressure)
        : base(height, curbWeight, depth, "KON-G-" + ++_sGasContainersCounter, maxCargoWeight)
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

    public override string ToString()
    {
        return "GasContainer{" +
               "Pressure=" + Pressure +
               ", CargoWeight=" + CargoWeight +
               ", Height=" + Height +
               ", CurbWeight=" + CurbWeight +
               ", Depth=" + Depth +
               ", SerialNumber='" + SerialNumber + '\'' +
               ", MaxCargoWeight=" + MaxCargoWeight +
               '}';
    }
}
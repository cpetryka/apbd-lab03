using Tutorial3.Exceptions;
using Tutorial3.Model;

namespace Tutorial3.Containers.Impl;

public class LiquidContainer : AbstractContainer, IHazardNotifier
{
    private static int _sLiquidContainersCounter = 0;
    private LiquidType LiquidType { get; set; }

    public LiquidContainer(double height, double curbWeight, double depth, double maxCargoWeight, LiquidType liquidType)
        : base(height, curbWeight, depth, "KON-L-" + ++_sLiquidContainersCounter, maxCargoWeight)
    {
        LiquidType = liquidType;
    }

    public void Notify()
    {
        if (LiquidType == LiquidType.Hazardous)
        {
            Console.WriteLine("There was a dangerous situation in container " + base.SerialNumber + "!");
        }
    }

    public override void Load(double cargoWeight)
    {
        // W innym wypadku możemy go wypełnić do 90% jego pojemności
        if (LiquidType == LiquidType.Standard && cargoWeight > MaxCargoWeight * 0.9)
        {
            Console.WriteLine("Attempt to perform a hazardous situation. Standard liquids should not exceed 90% of capacity.");
        }

        // Jeśli kontener przechowuje niebezpieczny ładunek - możemy go wypełnić jedynie do 50% pojemności
        if(LiquidType == LiquidType.Hazardous && cargoWeight > MaxCargoWeight / 2)
        {
            Console.WriteLine("Attempt to perform a hazardous situation. Hazardous liquids should not exceed 50% of capacity.");
        }

        base.Load(cargoWeight);
    }

    public override string ToString()
    {
        return "LiquidContainer{" +
               "LiquidType=" + LiquidType +
               ", CargoWeight=" + CargoWeight +
               ", Height=" + Height +
               ", CurbWeight=" + CurbWeight +
               ", Depth=" + Depth +
               ", SerialNumber='" + SerialNumber + '\'' +
               ", MaxCargoWeight=" + MaxCargoWeight +
               '}';
    }
}
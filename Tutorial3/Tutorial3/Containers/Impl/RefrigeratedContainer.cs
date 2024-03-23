namespace Tutorial3.Containers.Impl;

public class RefrigeratedContainer : AbstractContainer
{
    private static int _sRefrigeratedContainersCounter = 0;
    public string AllowedProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double height, double curbWeight, double depth, double maxCargoWeight, string allowedProductType,
        double temperature) : base(height, curbWeight, depth, "KON-G-" + ++_sRefrigeratedContainersCounter, maxCargoWeight)
    {
        AllowedProductType = allowedProductType;
        Temperature = temperature;
    }
}
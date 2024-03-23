namespace Tutorial3.Containers.Impl;

public class RefrigeratedContainer : AbstractContainer
{
    public string AllowedProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double height, double curbWeight, double depth, string serialNumber, double maxCargoWeight,
        string allowedProductType, double temperature) : base(height, curbWeight, depth, serialNumber, maxCargoWeight)
    {
        AllowedProductType = allowedProductType;
        Temperature = temperature;
    }
}
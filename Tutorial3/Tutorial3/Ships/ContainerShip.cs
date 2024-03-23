using Tutorial3.Containers;

namespace Tutorial3.Ships;

public class ContainerShip
{
    private double MaxSpeed { get; set; }
    private int MaxContainersNumber { get; set; }
    private double MaxContainersWeight { get; set; }
    private List<AbstractContainer> Containers { get; set; }

    public ContainerShip(double maxSpeed, int maxContainersNumber, double maxContainersWeight)
    {
        this.MaxSpeed = maxSpeed;
        this.MaxContainersNumber = maxContainersNumber;
        this.MaxContainersWeight = maxContainersWeight;
        Containers = new List<AbstractContainer>();
    }

    public ContainerShip(double maxSpeed, int maxContainersNumber, double maxContainersWeight, List<AbstractContainer> containers)
    {
        MaxSpeed = maxSpeed;
        MaxContainersNumber = maxContainersNumber;
        MaxContainersWeight = maxContainersWeight;
        Containers = containers;
    }

    public void LoadContainer(AbstractContainer container)
    {
        if (Containers.Count < MaxContainersNumber && container.CargoWeight <= MaxContainersWeight)
        {
            Containers.Add(container);
        }
    }

    public void LoadContainers(List<AbstractContainer> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(AbstractContainer container)
    {
        Containers.Remove(container);
    }

    public void UnloadAllContainers()
    {
        Containers.Clear();
    }

    public void ReplaceContainer(string serialNumber, AbstractContainer newContainer)
    {
        var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);

        if (index != -1)
        {
            Containers[index] = newContainer;
        }
        else
        {
            Console.WriteLine("Container with serial number " + serialNumber + " not found.");
        }
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);

        if (container != null)
        {
            targetShip.LoadContainer(container);
            UnloadContainer(container);
        }
        else
        {
            Console.WriteLine("Container with serial number " + serialNumber + " not found.");
        }
    }

    public override string ToString()
    {
        string result = "";

        result += "================ CONTAINER SHIP ================\n";
        result += "Max speed: " + MaxSpeed + "\n";
        result += "Max containers number: " + MaxContainersNumber + "\n";
        result += "Max containers weight: " + MaxContainersWeight + "\n";
        result += "Containers:\n";

        foreach (var container in Containers)
        {
            result += "-> " + container + "\n";
        }

        result += "================================================";

        return result;
    }
}
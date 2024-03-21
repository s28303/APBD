using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ship
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }

    public Ship(double maxSpeed, int maxContainers, double maxWeight)
    {
        Containers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }


    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new Exception("Cannot add more containers to the ship. Max number is reached.");

        double totalWeight = CalculateTotalWeight() + container.TareWeight + container.Mass;
        if (totalWeight > MaxWeight)
            throw new Exception("Adding this container would exceed the maximum weight capacity.");

        Containers.Add(container);
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }


    private double CalculateTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
            totalWeight += container.TareWeight + container.Mass;
        return totalWeight;
    }
}
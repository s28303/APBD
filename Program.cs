class Program
{
    static void Main(string[] args)
    {
        // Create a container ship
        Ship ship = new Ship(25, 100, 40000);

        // Create containers
        LiquidContainer liquidContainer = new LiquidContainer
        {
            Mass = 1000,
            Height = 200,
            TareWeight = 500,
            Depth = 100,
            MaxPayload = 5000,
            IsHazardous = false
        };

        GasContainer gasContainer = new GasContainer
        {
            Mass = 800,
            Height = 180,
            TareWeight = 400,
            Depth = 120,
            MaxPayload = 4000,
            Pressure = 2.5,
            IsHazardous = true
        };

        Product banana = new Product("Bananas", 10);

        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer
        {
            Mass = 1200,
            Height = 220,
            TareWeight = 600,
            Depth = 150,
            MaxPayload = 6000,
            Product = banana
        };

        // Load cargo
        try
        {
            liquidContainer.LoadCargo(3000);
            gasContainer.LoadCargo(2000);
            refrigeratedContainer.LoadCargo(4000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Load containers
        try
        {
            ship.AddContainer(liquidContainer);
            ship.AddContainer(gasContainer);
            ship.AddContainer(refrigeratedContainer);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Product meat = new Product("meat", -7);

    
        List<Container> containers = new List<Container>
        {
            new LiquidContainer
            {
                Mass = 1500,
                Height = 220,
                TareWeight = 600,
                Depth = 120,
                MaxPayload = 6000,
                IsHazardous = false
            },
             new GasContainer
            {
                Mass = 900,
                Height = 180,
                TareWeight = 450,
                Depth = 100,
                MaxPayload = 4500,
                Pressure = 3.0,
                IsHazardous = true
            },
            new RefrigeratedContainer
            {
                Mass = 1800,
                Height = 240,
                TareWeight = 700,
                Depth = 160,
                MaxPayload = 7000,
                Product = meat
            }
        };

        foreach (Container container in containers)
        {
            try
            {
                ship.AddContainer(container);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Remove a container from the ship
        ship.RemoveContainer(gasContainer);


        // Unload a container
        refrigeratedContainer.EmptyCargo();


        // Replace a container on the ship
        ship.RemoveContainer(liquidContainer);
        LiquidContainer newLiquidContainer = new LiquidContainer
        {
            Mass = 1100,
            Height = 210,
            TareWeight = 550,
            Depth = 110,
            MaxPayload = 5500,
            IsHazardous = true
        };

        try
        {
            ship.AddContainer(newLiquidContainer);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Transfer a container between ships
        Ship otherShip = new Ship(20, 80, 30000);
        otherShip.AddContainer(refrigeratedContainer);
        ship.RemoveContainer(refrigeratedContainer);



        // info about a container
        Console.WriteLine("\nContainer Information:");
        PrintContainerInfo(newLiquidContainer);


        // info about a ship and its cargo
        Console.WriteLine("\nShip Information:");
        PrintShipInfo(ship);
        Console.WriteLine("\nOther Ship Information:");
        PrintShipInfo(otherShip);

    }

    static void PrintContainerInfo(Container container)
    {
        Console.WriteLine($"Container: {container.SerialNumber}");
        Console.WriteLine($"Mass: {container.Mass} kg");
        Console.WriteLine($"Height: {container.Height} cm");
        Console.WriteLine($"Tare Weight: {container.TareWeight} kg");
        Console.WriteLine($"Depth: {container.Depth} cm");
        Console.WriteLine($"Maximum Payload: {container.MaxPayload} kg");


        if (container is LiquidContainer liquidContainer)
        {
            Console.WriteLine($"Type: Liquid Container");
            
            Console.WriteLine($"Hazardous: {liquidContainer.IsHazardous}");
        }
        else if (container is GasContainer gasContainer)
        {
            Console.WriteLine($"Type: Gas Container");
            Console.WriteLine($"Pressure: {gasContainer.Pressure} atmospheres");
          
            Console.WriteLine($"Hazardous: {gasContainer.IsHazardous}");
        }
       
        else if (container is RefrigeratedContainer refrigeratedContainer)
         {
            Console.WriteLine($"Type: Refrigerated Container");
            Console.WriteLine($"Product: {refrigeratedContainer.Product.Name}");
            Console.WriteLine($"Required Temperature: {refrigeratedContainer.Product.RequiredTemperature}°C");
        }
    }

    static void PrintShipInfo(Ship ship)
    {
        Console.WriteLine($"Maximum Speed: {ship.MaxSpeed} knots");
        Console.WriteLine($"Maximum Containers: {ship.MaxContainers}");
        Console.WriteLine($"Maximum Weight: {ship.MaxWeight} tons");

        Console.WriteLine("Containers on the ship:");
        foreach (Container container in ship.Containers)
        {
            Console.WriteLine($"- {container.SerialNumber}");
        }
    }
}

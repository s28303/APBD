using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LiquidContainer : Container, HazardNotifier
{
    private double cargo;
    private const double MAX_FILL_RATIO = 0.9;
    private const double HAZARD_FILL_RATIO = 0.5;

    public override void LoadCargo(double mass)
    {
        if (mass + cargo > MaxPayload)
            throw new OverfillException($"Cannot overload container {SerialNumber}");

        double fillRatio = IsHazardous ? HAZARD_FILL_RATIO : MAX_FILL_RATIO;
        if (mass + cargo > MaxPayload * fillRatio)
            NotifyHazard($"Attempting to dangerously fill container {SerialNumber}");
        else
            cargo += mass;
    }

    public override void EmptyCargo()
    {
        cargo = 0;
    }

    public bool IsHazardous { get; set; }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard: {message}");
    }
}

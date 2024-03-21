using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GasContainer : Container, HazardNotifier
{
    private double cargo;
    private double pressure;

    public override void LoadCargo(double mass)
    {
        if (mass + cargo > MaxPayload)
            throw new OverfillException($"container {SerialNumber} cannot load cargo. Overfill will occur!");


        double fillRatio = IsHazardous ? 0.5 : 0.9;

        if (mass + cargo > MaxPayload * fillRatio)
            NotifyHazard($"Attempting to dangerously fill container {SerialNumber}");
        else
            cargo += mass;
    }

    public override void EmptyCargo()
    {
        cargo = MaxPayload * 0.05;
    }

    public double Pressure { get => pressure; set => pressure = value; }

    public bool IsHazardous { get; set; }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard: {message}");
    }
}

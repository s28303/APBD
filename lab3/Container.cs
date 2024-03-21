using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Container
{
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; }


    public abstract void LoadCargo(double mass);

    public abstract void EmptyCargo();

    protected Container()
    {
        SerialNumber = $"KON-{this.GetType().Name[0]}-{GetUniqueNumber()}";
    }

    private static int containerCount = 1;
    private static int GetUniqueNumber() => containerCount++;
}

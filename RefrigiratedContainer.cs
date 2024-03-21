using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RefrigeratedContainer : Container
{
    private double cargo;
    private Product product;
    private double temperature;


    public override void LoadCargo(double mass)
    {
        if (mass + cargo > MaxPayload)
            throw new OverfillException($"container {SerialNumber} cannot load cargo. Overfill will occur!");


        if (product != null && temperature > product.RequiredTemperature)
            throw new Exception($"Container temperature {temperature} (required: {product.RequiredTemperature})");

        cargo += mass;
    }

    public override void EmptyCargo()
    {
        cargo = 0;
        product = null;
    }


    public Product Product { get => product; set => product = value; }
    public double Temperature { get => temperature; set => temperature = value; }
}
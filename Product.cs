using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Product
{
    public string Name { get; set; }
    public double RequiredTemperature { get; set; }

    public Product(string name, double requiredTemperature)
    {
        Name = name;
        RequiredTemperature = requiredTemperature;
    }
}
using lab04.Models;

namespace lab04.Database;

public static class MockDb
{
    public static List<Animal> Animals { get; set; } = new();
    public static List<Visit> Visits { get; set; } = new();

    static MockDb()
    {
        var ars = new Animal(1, "Ars", "Dog", 213, "Green");
        Animals.Add(ars);
        
        var miha = new Animal(2, "Miha", "Cat", 3, "Black");
        Animals.Add(miha);
        
        var barsa = new Animal(3, "Barsa", "Dog", 21, "White");
        Animals.Add(miha);

        var visit1 = new Visit(1, ars, DateTime.Today, "Vet check", 140);
        Visits.Add(visit1);
        
        
        var visit2 = new Visit(2, barsa, DateTime.Today, "Vet check", 532);
        Visits.Add(visit1);
    }
}
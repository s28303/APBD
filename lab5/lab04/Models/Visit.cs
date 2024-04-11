using lab04.Models;

namespace lab04.Database;

public class Visit(int id, Animal animal, DateTime date, string description, decimal price)
{
    public int Id { get; set; } = id;
    public Animal Animal { get; set; } = animal;
    public DateTime Date { get; set; } = date;
    public string Description { get; set; } = description;
    public decimal Price { get; set; } = price;
}
using lab04.Database;
using lab04.Models;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = MockDb.Animals;
        return Ok(animals);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = MockDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        MockDb.Animals.Add(animal);
        return Ok(animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = MockDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;
        
        return Ok(animal);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = MockDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        
        MockDb.Animals.Remove(animal);
        return Ok();
    }
}
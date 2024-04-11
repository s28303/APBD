using lab04.Database;
using lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab04.Controllers;

[ApiController]
[Route("/visits")]
public class VisitController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Visit> GetVisits(Animal animal)
    {
        return MockDb.Visits.Where(v => v.Animal == animal);
    }
    
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        MockDb.Visits.Add(visit);
        return Ok(visit);
    }
}
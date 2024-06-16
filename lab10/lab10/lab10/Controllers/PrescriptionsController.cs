using lab10.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace lab10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPatientRepository _petientRepository;
        public PrescriptionsController(IPatientRepository patientRepository)
        {
            _petientRepository = patientRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _petientRepository.GetPatientAsync(id);

            return Ok(patient);
        }
    }
}

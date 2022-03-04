using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPatient(int id)
        => throw new NotImplementedException();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPatients()
        => throw new NotImplementedException();

    [HttpPost]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        => throw new NotImplementedException();

    [HttpPut]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        => throw new NotImplementedException();

    [HttpDelete]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemovePatient(int id)
        => throw new NotImplementedException();
}

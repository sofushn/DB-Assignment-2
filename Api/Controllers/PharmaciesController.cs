using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PharmaciesController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Pharmacy), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPharmacy(int id)
        => throw new NotImplementedException();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Pharmacy>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPharmacies()
        => throw new NotImplementedException();

    [HttpPost]
    [ProducesResponseType(typeof(Pharmacy), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPharmacy([FromBody] Pharmacy pharmacy)
        => throw new NotImplementedException();

    [HttpPut]
    [ProducesResponseType(typeof(Pharmacy), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePharmacy(int id, [FromBody] Pharmacy pharmacy)
        => throw new NotImplementedException();

    [HttpDelete]
    [ProducesResponseType(typeof(Pharmacy), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemovePharmacy(int id)
        => throw new NotImplementedException();
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDoctor(int id)
        => throw new NotImplementedException();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Doctor>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDoctors()
        => throw new NotImplementedException();

    [HttpPost]
    [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        => throw new NotImplementedException();

    [HttpPut]
    [ProducesResponseType(typeof(Doctor), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        => throw new NotImplementedException();

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveDoctor(int id)
        => throw new NotImplementedException();
}

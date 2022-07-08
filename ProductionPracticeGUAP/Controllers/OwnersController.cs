using Microsoft.AspNetCore.Mvc;
using ProductionPracticeGUAP.API.Models;

namespace ProductionPracticeGUAP.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnersController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<int> Add(OwnerRequest dog)
    {
        return 1;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult RemoveById(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult UpdateById(OwnerRequest dog, int id)
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OwnerOutPutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<DogOutPutResponse> GetByOwnerId(int id)
    {
        return Ok(new DogOutPutResponse());
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<OwnerOutPutAllResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<DogOutPutAllResponse>> GetAll()
    {
        return Ok(new DogOutPutAllResponse());
    }
}

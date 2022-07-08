using Microsoft.AspNetCore.Mvc;
using ProductionPracticeGUAP.API.Models;

namespace ProductionPracticeGUAP.Controllers;

[ApiController]
[Route("[controller]")]
public class DogsController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<int> Add ([FromBody]DogRequest dog)
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
    public ActionResult UpdateById(DogRequest dog, int id)
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DogOutPutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<DogOutPutResponse> GetByUserId(int id)
    {
        return Ok(new DogOutPutResponse());
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<DogOutPutAllResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<DogOutPutAllResponse>> GetAll()
    {
        return NoContent();
    }
}

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
    public ActionResult<int> AddDog ([FromBody]DogRequest dog)
    {
        return 1;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult RemoveDogById(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult UpdateDogById(DogRequest dog, int id)
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DogOutPutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult GetDogByUserId(int id)
    {
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<DogOutPutAllResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult GetAllDogs()
    {
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using ProductionPracticeGUAP.API.Extentions;
using ProductionPracticeGUAP.API.Infrastructure;
using ProductionPracticeGUAP.API.Models;
using ProductionPracticeGUAP.Data.Enums;
using ProductPracticeGUAP.Data.Entities;
using ProductPracticeGUAP.Data.Repositories.Interfaces;

namespace ProductionPracticeGUAP.Controllers;

[ApiController]
[Route("[controller]")]
public class DogsController : Controller
{
    private readonly IDogRepository _dogRepository;
    private readonly IOwnerRepository _ownerRepository;

    public DogsController(IDogRepository dogRepository, IOwnerRepository ownerRepository)
    {
        _dogRepository = dogRepository;
        _ownerRepository = ownerRepository;
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<int> Add ([FromBody]DogRequest dogInfo, int ownerId)
    {
        var owner = _ownerRepository.GetById(ownerId);

        Dog dog = new Dog
        {
            Name = dogInfo.Name,
            Breed = dogInfo.Breed,
            Weight = dogInfo.Weight,
            Age = dogInfo.Age,
            Owner = owner,
            IsDeleted = false
        };

        var result = _dogRepository.Add(dog);
        return Created($"{this.GetUri()}/{result}", result);
    }

    [AuthorizeByRole]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult RemoveById(int id)
    {
        _dogRepository.RemoveById(id);

        return NoContent();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult UpdateById([FromBody] DogRequest dogInfo, int id)
    {
        var dog = _dogRepository.GetById(id);

        dog.Name = dogInfo.Name;
        dog.Breed = dogInfo.Breed;
        dog.Weight = dogInfo.Weight;
        dog.Age = dogInfo.Age;

        _dogRepository.UpdateById(dog, id);

        return NoContent();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DogOutPutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<DogOutPutResponse> GetById(int id)
    {
        var dog = _dogRepository.GetById(id);

        if (dog is not null)
            return Ok(dog);
        else
            return NotFound();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpGet("{id}/owner")]
    [ProducesResponseType(typeof(DogOutPutAllResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<DogOutPutAllResponse>> GetByOwnerId(int id)
    {
        var dogs = _dogRepository.GetByOwnerId(id);

        if (dogs.Count != 0)
            return Ok(dogs);
        else
            return NotFound();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpGet]
    [ProducesResponseType(typeof(List<DogOutPutAllResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<DogOutPutAllResponse>> GetAll()
    {
        var dogs = _dogRepository.GetAll();

        if (dogs.Count != 0)
            return Ok(dogs);
        else
            return NotFound();
    }
}

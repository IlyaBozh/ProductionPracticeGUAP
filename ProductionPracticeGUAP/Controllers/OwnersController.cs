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
public class OwnersController : Controller
{
    private readonly IOwnerRepository _ownerRepository;

    public OwnersController(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<int> Add([FromBody] OwnerRequest ownerInfo)
    {
        Owner ownre = new Owner
        {
            FirstName = ownerInfo.FirstName,
            LastName = ownerInfo.LastName,
            Email = ownerInfo.Email,
            Password = ownerInfo.Password,
            IsDeleted = false
        };

        var result = _ownerRepository.Add(ownre);
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
        _ownerRepository.RemoveById(id);

        return Ok();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public ActionResult UpdateById([FromBody] OwnerUpdateRequest ownerInfo, int id)
    {
        var owner = _ownerRepository.GetById(id);
        owner.FirstName = ownerInfo.FirstName;
        owner.LastName = ownerInfo.LastName;

        _ownerRepository.UpdateById(owner, id);

        return NoContent();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OwnerOutPutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<OwnerOutPutResponse> GetById(int id)
    {
        var owner = _ownerRepository.GetById(id);

        if (owner is not null)
            return Ok(owner);
        else
            return NotFound();
    }

    [AuthorizeByRole(RoleEnum.Owner)]
    [HttpGet]
    [ProducesResponseType(typeof(List<OwnerOutPutAllResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<List<OwnerOutPutAllResponse>> GetAll()
    {
        var owners = _ownerRepository.GetAll();

        if (owners.Count != 0)
            return Ok(owners);
        else
            return NotFound();
    }
}

using ProductionPracticeGUAP.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ProductionPracticeGUAP.API.Models;

public class OwnerUpdateRequest
{
    [Required(ErrorMessage = ApiErrorMessage.NameIsRequired)]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.LastNameIsRequired)]
    [MaxLength(30)]
    public string LastName { get; set; }
}

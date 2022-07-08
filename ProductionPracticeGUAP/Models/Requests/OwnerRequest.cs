using ProductionPracticeGUAP.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ProductionPracticeGUAP.API.Models;

public class OwnerRequest
{
    [Required(ErrorMessage = ApiErrorMessage.NameIsRequired)]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.LastNameIsRequired)]
    [MaxLength(30)]
    public string LastName { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.EmailIsRequired)]
    public string Email { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }
}

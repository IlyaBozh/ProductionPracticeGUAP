using ProductionPracticeGUAP.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ProductionPracticeGUAP.API.Models.Requests
{
    public class OwnerLoginRequest
    {
        [Required(ErrorMessage = ApiErrorMessage.PasswordIsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage = ApiErrorMessage.EmailIsRequired)]
        public string Email { get; set; }
    }
}

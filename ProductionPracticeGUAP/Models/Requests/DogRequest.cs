using ProductionPracticeGUAP.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ProductionPracticeGUAP.API.Models;

public class DogRequest
{
    [Required(ErrorMessage = ApiErrorMessage.NameIsRequired)]
    [MaxLength(30)]
    public string Name { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.AgeIsRequired)]
    [Range(1,30)]
    public int Age { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.BreedIsRequired)]
    public string Breed { get; set; }

    [Required(ErrorMessage = ApiErrorMessage.NameIsRequired)]
    public double Weight { get; set; }
}

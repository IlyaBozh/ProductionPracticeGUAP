namespace ProductionPracticeGUAP.API.Models;

public class OwnerRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<DogRequest> Dogs { get; set; }
}

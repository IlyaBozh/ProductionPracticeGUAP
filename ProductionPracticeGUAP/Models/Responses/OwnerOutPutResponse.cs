namespace ProductionPracticeGUAP.API.Models;

public class OwnerOutPutResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<DogRequest> Dogs { get; set; }
}

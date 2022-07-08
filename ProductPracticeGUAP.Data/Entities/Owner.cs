

namespace ProductPracticeGUAP.Data.Entities;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Dog> Dogs { get; set; }
    public bool IsDeleted { get; set; }
}



namespace ProductPracticeGUAP.Data.Entities;

public class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
    public double Weight { get; set; }
    public Owner Owner { get; set; }
}

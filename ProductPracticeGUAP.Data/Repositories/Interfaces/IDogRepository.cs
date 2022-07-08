using ProductPracticeGUAP.Data.Entities;


namespace ProductPracticeGUAP.Data.Repositories.Interfaces;

public interface IDogRepository
{
    public int Add(Dog dog);
    public void RemoveById(int id);
    public void UpdateById(Dog dog, int id);
    public List<Dog>? GetByOwnerId(int id);
    public Dog? GetById(int id);
    public List<Dog> GetAll();
}

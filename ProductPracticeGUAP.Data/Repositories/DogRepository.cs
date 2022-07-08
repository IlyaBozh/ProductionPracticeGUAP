using ProductPracticeGUAP.Data.Entities;
using ProductPracticeGUAP.Data.Repositories.Interfaces;

namespace ProductPracticeGUAP.Data.Repositories;

public class DogRepository : IDogRepository
{
    private readonly ProductPracticeGUAPContext _context;

    public DogRepository(ProductPracticeGUAPContext context)
    {
        _context = context;
    }

    public int Add(Dog dog)
    {
        _context.Dogs.Add(dog);
        _context.SaveChanges();

        return dog.Id;
    }

    public List<Dog> GetAll() => _context.Dogs.Where(d => !d.IsDeleted).ToList();

    public Dog? GetById(int id) => _context.Dogs.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Id == id);

    public List<Dog>? GetByOwnerId(int id) => _context.Dogs.Where(d => d.Owner.Id == id && !d.IsDeleted).ToList();


    public void RemoveById(int id)
    {
        var dog = _context.Dogs.FirstOrDefault(d => d.Id == id);
        dog.IsDeleted = true;
        _context.SaveChanges();
    }

    public void UpdateById(Dog updateDog, int id)
    {
        var dog = _context.Dogs.FirstOrDefault(d => d.Id == id);
        dog = updateDog;
        _context.Dogs.Update(dog);
        _context.SaveChanges();
    }
}



using ProductPracticeGUAP.Data.Entities;
using ProductPracticeGUAP.Data.Repositories.Interfaces;

namespace ProductPracticeGUAP.Data.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly ProductPracticeGUAPContext _context;

    public OwnerRepository(ProductPracticeGUAPContext context)
    {
        _context = context;
    }

    public int Add(Owner owner)
    {
        _context.Owners.Add(owner);
        _context.SaveChanges();

        return owner.Id;
    }

    public List<Owner> GetAll() => _context.Owners.Where(o => !o.IsDeleted).ToList();

    public Owner? GetById(int id) => _context.Owners.Where(o => !o.IsDeleted).FirstOrDefault(o => o.Id == id);

    public void RemoveById(int id)
    {
        var owner = _context.Owners.FirstOrDefault(o => o.Id == id);
        owner.IsDeleted = true;
        _context.SaveChanges();
    }

    public void UpdateById(Owner updateOwner, int id)
    {
        var owner = _context.Owners.FirstOrDefault(d => d.Id == id);
        owner = updateOwner;
        _context.Owners.Update(owner);
        _context.SaveChanges();
    }
}

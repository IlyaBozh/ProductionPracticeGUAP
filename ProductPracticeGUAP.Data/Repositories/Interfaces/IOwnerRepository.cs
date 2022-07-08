

using ProductPracticeGUAP.Data.Entities;

namespace ProductPracticeGUAP.Data.Repositories.Interfaces;

public interface IOwnerRepository
{
    public int Add(Owner owner);
    public void RemoveById(int id);
    public void UpdateById(Owner dog, int id);
    public Owner? GetByUserId(int id);
    public List<Owner> GetAll();
}

using ProductPracticeGUAP.Data.Entities;
using ProductPracticeGUAP.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPracticeGUAP.Data.Repositories
{
    public class DogRepository : IDogRepository
    {
        public int Add(Dog dog)
        {
            throw new NotImplementedException();
        }

        public List<Dog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dog? GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(Dog dog, int id)
        {
            throw new NotImplementedException();
        }
    }
}

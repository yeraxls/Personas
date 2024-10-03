using Core.Entities;
using Core.Repositories;
using Infraestructure.Data;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(AplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

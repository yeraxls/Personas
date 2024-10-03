using Core.Entities;

namespace Aplication.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> Create(Person person);
        Task<Person> Update(int id, string name, string lastname);
        Task<bool> Delete(int id);
    }
}
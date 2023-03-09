using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Contracts.Service
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPeople();
        Task<Person> GetById(int id);
        Task<bool> SavePerson(Person entity);
        Task<bool> SearchPersonByCpfReturnBool(int cpf);
    }
}

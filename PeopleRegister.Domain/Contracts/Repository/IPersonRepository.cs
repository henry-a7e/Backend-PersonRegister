using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Contracts.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPeople();
        Task<Person> GetById(int id);
        void SavePerson(Person entity);
        Task<Person> SearchPersonByCPF(int cpf);
    }
}

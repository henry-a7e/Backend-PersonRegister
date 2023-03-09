
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Contracts.Repository
{
    public interface IPhoneRepository
    {
        Task<Phone> GetById(int id);
        Task<List<Phone>> GetByPersonId(int idPerson);
        void SavePhone(Phone phone);
    }
}

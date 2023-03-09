
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Contracts.Service
{
    public interface IPhoneService
    {
        void SavePhone(Phone phone);
        Task<Phone> GetById(int id);
        Task<List<Phone>> GetByPersonId(int idPerson);
    }
}

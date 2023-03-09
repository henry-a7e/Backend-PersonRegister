using PeopleRegister.Contracts.Repository;
using PeopleRegister.Contracts.Service;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Domain.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<Phone> GetById(int id)
        {
            return await _phoneRepository.GetById(id);
        }

        public async Task<List<Phone>> GetByPersonId(int idPerson)
        {
            List<Phone> phones = await _phoneRepository.GetByPersonId(idPerson);
            return phones;// await _phoneRepository.GetByPersonId(id);
        }

        public void SavePhone(Phone phone)
        {
            _phoneRepository.SavePhone(phone);
        }
    }
}

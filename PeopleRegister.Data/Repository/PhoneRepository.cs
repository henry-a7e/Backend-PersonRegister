using Microsoft.EntityFrameworkCore;
using PeopleRegister.Contracts.Repository;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Data.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly MyDbContext _context;

        public PhoneRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Phone> GetById(int id)
        {
            return await _context.Phones.FindAsync(id);
        }

        public async Task<List<Phone>> GetByPersonId(int idPerson)
        {
            return await _context.Phones.Where(p => p.PersonId == idPerson).ToListAsync();
        }

        public void SavePhone(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
        }

    }
}

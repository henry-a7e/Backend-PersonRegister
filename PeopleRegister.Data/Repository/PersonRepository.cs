using Microsoft.EntityFrameworkCore;
using PeopleRegister.Contracts.Repository;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyDbContext _context;

        public PersonRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await _context.People.ToListAsync(); 
        }

        public async Task<Person> GetById(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public void SavePerson(Person entity)
        {
            _context.People.Add(entity);
            _context.SaveChanges();
        }

        public async Task<Person> SearchPersonByCPF(int cpf)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.CPF == cpf);
        }
    }
}

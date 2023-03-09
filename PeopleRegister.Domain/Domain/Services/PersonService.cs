using PeopleRegister.Contracts.Repository;
using PeopleRegister.Contracts.Service;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Services.Exceptions;
using System.Collections.Generic;

namespace PeopleRegister.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await _personRepository.GetAllPeople();
        }

        public async Task<Person> GetById(int id)
        {
            if (id == 0)
            {
                throw new IdCanNotBeZero();
            }
            return await _personRepository.GetById(id);

        }

        public async Task<bool> SavePerson(Person entity)
        {
            Person person = await _personRepository.SearchPersonByCPF(entity.CPF);
            if (person == null)
            {
                _personRepository.SavePerson(entity);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> SearchPersonByCpfReturnBool(int cpf)
        {
            Person person = await _personRepository.SearchPersonByCPF(cpf);
            if (person == null)
                return false;
            else
                return true;
            

        }
    }
}

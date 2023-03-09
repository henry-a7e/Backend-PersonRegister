using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleRegister.API.DTOs;
using PeopleRegister.Contracts.Service;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PersonDto>>> GetAllPeople()
        {
            List<Person> people= await _personService.GetAllPeople();

            return Ok(_mapper.Map<List<PersonDto>>(people));
        }

        [HttpGet("{id}", Name = "GetByIdPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            if(id == 0)
                return BadRequest("The Id can not be zero");
            
            Person person = await _personService.GetById(id);

            if (person==null)
                return NotFound($"Person not found with Id={id}"); 
            
            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpGet("search-by-cpf-return-bool/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> SearchByCpfReturnBool(int cpf)
        {
            if (cpf >999999999)
                return BadRequest("the cpf can not be greater than 9 numbers");
            bool person = await _personService.SearchPersonByCpfReturnBool(cpf);

            if (person == true)
                return true;
            else
                return false;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Person person = _mapper.Map<Person>(entity);
            
            Task<bool> result =  _personService.SavePerson(person);

            if (await result == false)
                return BadRequest("Exist a person with the same CPF");
            
            return CreatedAtRoute("GetByIdPerson", new { id = entity.Id }, entity);
        }

    }
}

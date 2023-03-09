using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeopleRegister.API.DTOs;
using PeopleRegister.Contracts.Service;
using PeopleRegister.Domain.Entities;


namespace PeopleRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        private readonly IMapper _mapper;

        public PhoneController(IPhoneService phoneService, IMapper mapper)
        {
            _phoneService = phoneService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PhoneDto>> GetById(int id)
        {
            Phone phone = await _phoneService.GetById(id);
            return Ok(_mapper.Map<PhoneDto>(phone));
        }

        [HttpGet("get-by-personId/{idPerson}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PhoneDto>>> GetByPersonId(int idPerson)
        {
            List<Phone> phones = await _phoneService.GetByPersonId(idPerson);
            return Ok(_mapper.Map<List<PhoneDto>>(phones));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PhoneDto> Save([FromBody] PhoneDto entity)
        {
            Phone phone = _mapper.Map<Phone>(entity);
            _phoneService.SavePhone(phone);

            return CreatedAtRoute("GetById", new { id = entity.Id }, entity);
        }
    }
}

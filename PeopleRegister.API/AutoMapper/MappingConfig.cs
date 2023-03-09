using AutoMapper;
using PeopleRegister.API.DTOs;
using PeopleRegister.Domain.Entities;
using System.Globalization;

namespace PeopleRegister.API.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Person, PersonDto>()
                //.ForMember(d=>d.CPF, opt=>opt.MapFrom(o=> Convert.ToInt64(o.CPF)))
                .ForMember(d=>d.Birthdate, opt=>opt.MapFrom(o=>o.Birthdate.ToString("dd/MM/yyyy")));
            CreateMap<PersonDto, Person>()
                //.ForMember(d => d.CPF, opt => opt.MapFrom(o => Convert.ToInt32(o.CPF)))
                .ForMember(d=>d.Birthdate,opt=>opt.MapFrom(o=>DateTime.ParseExact(o.Birthdate,"dd/MM/yyyy",CultureInfo.InvariantCulture)));
                
            CreateMap<Phone, PhoneDto>().ReverseMap();
        }
    }
}

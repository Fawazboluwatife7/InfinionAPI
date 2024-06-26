using AutoMapper;
using InfinionAPI.DTO;
using InfinionAPI.Models;

namespace InfinionAPI.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Users, CreateUserDTO>().ReverseMap();
            CreateMap<Users, UpdateUserDTO>().ReverseMap();
            CreateMap<Users, UserDTO>().ReverseMap();
        }
    }
}

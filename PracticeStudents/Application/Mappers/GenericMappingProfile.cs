using AutoMapper;
using PracticeStudents.Domain.Entities;

public class GenericMappingProfile : Profile
{
    public GenericMappingProfile()
    {
        CreateMap<UserRequestDto, User>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
    }
}
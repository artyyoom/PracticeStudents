using AutoMapper;
using PracticeStudents.Domain.Entities;

public class GenericMappingProfile : Profile
{
    public GenericMappingProfile()
    {
        CreateMap<CourseRequestDto, Course>().ReverseMap();
        CreateMap<Course, CourseResponseDto>().ReverseMap();

        CreateMap<GroupRequestDto, Group>().ReverseMap();
        CreateMap<Group, GroupResponseDto>().ReverseMap();

        CreateMap<LessonRequestDto, Lesson>().ReverseMap();
        CreateMap<Lesson, LessonResponseDto>().ReverseMap();

        CreateMap<StudentsGroupRequestDto, StudentsGroup>().ReverseMap();
        CreateMap<StudentsGroup, StudentsGroupResponseDto>().ReverseMap();

        CreateMap<AttendanceRequestDto, Attendance>().ReverseMap();
        CreateMap<Attendance, AttendanceResponseDto>().ReverseMap();
    }
}
using PracticeStudents.Domain.Entities;

public class StudentsGroupService : AbstractService<StudentsGroup>
{
    private readonly IRepository<StudentsGroup> _studentsGroupRepository;
    public StudentsGroupService(IRepository<StudentsGroup> repository, IGenericMapper mapper) : base(repository, mapper)
    {
        _studentsGroupRepository = repository;
    }

    public async Task<StudentsGroupResponseDto> Create(StudentsGroupRequestDto dto, int groupId)
    {
        var groupExists = await _studentsGroupRepository.ExistsAsync(s => s.Id == groupId);

        if (!groupExists)
            throw new ArgumentException($"Group with id {groupId} does not exist.");

        var entity = _mapper.Map<StudentsGroupRequestDto, StudentsGroup>(dto);
        entity.GroupId = groupId;
        var result = await _repository.AddAsync(entity);

        return _mapper.Map<StudentsGroup, StudentsGroupResponseDto>(result);
    }
    
    public override async Task Delete(int studentId)
    {
        var entity = await _studentsGroupRepository.GetByFuncAsync(s => s.StudentId == studentId);

        if (entity == null)
            throw new ArgumentException($"Student with id {studentId} does not exist.");

        await _repository.DeleteByIdAsync(entity.Id);
    }
}
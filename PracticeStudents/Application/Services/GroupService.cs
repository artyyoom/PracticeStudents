using PracticeStudents.Domain.Entities;

public class GroupService : AbstractService<Group>
{

    private readonly GroupRepository _groupRepository;

    public GroupService(GroupRepository groupRepository, IRepository<Group> repository, IGenericMapper mapper) : base(repository, mapper)
    {
        _groupRepository = groupRepository;
    }

    public async Task<IEnumerable<GroupResponseDto>> GetByFilter(string requestName)
    {
        var entities = await _groupRepository.GetByFilterAsync(requestName);
        var dtos = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupResponseDto>>(entities);
        return dtos;
    }
}
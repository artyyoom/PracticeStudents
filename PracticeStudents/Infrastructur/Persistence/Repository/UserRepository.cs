using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeStudents.Domain.Entities;


public class UserRepository : IRepository<User>
{
    private readonly ProjectDbContext _dbContext;

    public UserRepository(ProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddAsync(User entity)
    {
        await _dbContext.UserDb.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.UserDb.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.UserDb.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(User entity)
    {
        _dbContext.UserDb.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var result = await _dbContext.UserDb.Where(u => u.Id == id).ExecuteDeleteAsync();
        return result;
    }
}

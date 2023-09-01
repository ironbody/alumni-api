using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class TestService: ITestService
{
    private readonly AlumniDbContext _context;

    public TestService(AlumniDbContext context)
    {
        _context = context;
    }

    public Task<Test?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Test>> GetAllAsync()
    {
        return await _context.Test.ToListAsync();
    }

    public Task<bool> ExistsWithIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(Test entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Test entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Test entity)
    {
        throw new NotImplementedException();
    }
}
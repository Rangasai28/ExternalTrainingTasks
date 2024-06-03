using ArchitectureWebApi.Core.Contracts.IRepositories;
using ArchitectureWebApi.Core.Models;
using ArchitectureWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ArchitectureWebApi.Infrastructure.Repositories;

public class PersonRepository<T> : IPersonRepository<T> where T : class
{
    readonly Context _context;
    readonly DbSet<T> personEntity;
    public PersonRepository(Context context)
    {
        _context = context;
        personEntity = context.Set<T>();
    }

    public async Task<(bool, string)> Create(T person)
    {
        try
        {
            personEntity.Add(person);
            await _context.SaveChangesAsync();
            return (true, "Created successfully");
        }
        catch (Exception ex)
        {
            return (false, $"Error creating  : {ex.Message}");
        }

    }


    public async Task<(bool, string)> Delete(int id)
    {
        try
        {

            var person = await personEntity.FindAsync(id);
            if (person == null)
            {
                return (false, " not found");
            }
            personEntity.Remove(person);
            await _context.SaveChangesAsync();
            return (true, " deleted successfully");
        }
        catch (Exception ex)
        {
            return (false, $"Error deleting : {ex.Message}");
        }

    }


    public async Task<List<T>> GetStdDetails()
    {
        return await personEntity.ToListAsync();
    }

    public async Task<T> GetStdDetailsById(int id)
    {
        return await personEntity.FindAsync(id);
    }

    public async Task<(bool,string)> Update(T person)
    {
        
        try
        {
            personEntity.Update(person);
            await _context.SaveChangesAsync();
            return (true, " Updates successfully");
        }
        catch (Exception ex)
        {
            return (false, $"Error updating Student: {ex.Message}");
        }

    }

    public async Task<(bool,T)> PersonExists(int id)
    {
        var person = await personEntity.FindAsync(id);
        if(person == null)
        {
            return (false, null);
        }
        return (true, person);
    }
}

using Microsoft.EntityFrameworkCore;
using PracticeC_.Data;
using PracticeC_.Models;
using PracticeC_.Repositories.Interfaces;

namespace PracticeC_.Services;
public class EmployeeServices : IEmployeeRepository
{
    private readonly ApplicationDbContext Context;

    public EmployeeServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        try
        {
            return await Context.Employees.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task<Employee> GetById(int id)
    {
        try
        {
            return await Context.Employees.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Add(Employee Employee)
    {
        try
        {
            await Context.Employees.AddAsync(Employee);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Update(Employee Employee)
    {
        try
        {
            Context.Employees.Update(Employee);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var roomTypeFound = await GetById(id);
            Context.Employees.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Employees.AnyAsync(b=>b.Id == id);
    }

}
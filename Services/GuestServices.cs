using Microsoft.EntityFrameworkCore;
using PracticeC_.Data;
using PracticeC_.Models;
using PracticeC_.Repositories.Interfaces;

namespace PracticeC_.Services;
public class GuestServices : IGuestRepository
{
    private readonly ApplicationDbContext Context;

    public GuestServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Guest>> GetAll()
    {
        try
        {
            return await Context.Guests.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task<Guest> GetById(int id)
    {
        try
        {
            return await Context.Guests.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Add(Guest Guest)
    {
        try
        {
            await Context.Guests.AddAsync(Guest);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Update(Guest Guest)
    {
        try
        {
            Context.Guests.Update(Guest);
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
            Context.Guests.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Guests.AnyAsync(b=>b.Id == id);
    }

}
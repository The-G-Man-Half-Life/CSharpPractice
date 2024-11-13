using Microsoft.EntityFrameworkCore;
using PracticeC_.Data;
using PracticeC_.Models;
using PracticeC_.Repositories.Interfaces;

namespace PracticeC_.Services;
public class Room_typeServices : IRoom_typeRepository
{
    private readonly ApplicationDbContext Context;

    public Room_typeServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Room_type>> GetAll()
    {
        try
        {
            return await Context.Room_types.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task<Room_type> GetById(int id)
    {
        try
        {
            return await Context.Room_types.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Add(Room_type Room_type)
    {
        try
        {
            await Context.Room_types.AddAsync(Room_type);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Update(Room_type Room_type)
    {
        try
        {
            Context.Room_types.Update(Room_type);
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
            Context.Room_types.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Room_types.AnyAsync(b=>b.Id == id);
    }

}
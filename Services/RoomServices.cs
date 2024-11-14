using Microsoft.EntityFrameworkCore;
using PracticeC_.Data;
using PracticeC_.Models;
using PracticeC_.Repositories.Interfaces;

namespace PracticeC_.Services;
public class RoomServices : IRoomRepository
{
    private readonly ApplicationDbContext Context;

    public RoomServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        try
        {
            return await Context.Rooms.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task<Room> GetById(int id)
    {
        try
        {
            return await Context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Add(Room Room)
    {
        try
        {
            await Context.Rooms.AddAsync(Room);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Update(Room Room)
    {
        try
        {
            Context.Rooms.Update(Room);
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
            Context.Rooms.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Rooms.AnyAsync(b=>b.Id == id);
    }

}
using Microsoft.EntityFrameworkCore;
using PracticeC_.Data;
using PracticeC_.Models;
using PracticeC_.Repositories.Interfaces;

namespace PracticeC_.Services;
public class BookingServices : IBookingRepository
{
    private readonly ApplicationDbContext Context;

    public BookingServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Booking>> GetAll()
    {
        try
        {
            return await Context.Bookings.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task<Booking> GetById(int id)
    {
        try
        {
            return await Context.Bookings.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Add(Booking Booking)
    {
        try
        {
            await Context.Bookings.AddAsync(Booking);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task Update(Booking Booking)
    {
        try
        {
            Context.Bookings.Update(Booking);
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
            Context.Bookings.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("Un error ocurrio", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Bookings.AnyAsync(b=>b.Id == id);
    }

}
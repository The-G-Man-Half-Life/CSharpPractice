using PracticeC_.DTOs.Requests;
using PracticeC_.Models;

namespace PracticeC_.Repositories.Interfaces;
public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAll();
    Task<Booking?> GetById(int id);
    Task Add(Booking Booking);
    Task Update(Booking Booking);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
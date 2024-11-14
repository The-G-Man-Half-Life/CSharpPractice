using PracticeC_.DTOs.Requests;
using PracticeC_.Models;

namespace PracticeC_.Repositories.Interfaces;
public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAll();
    Task<Room?> GetById(int id);
    Task Add(Room Room);
    Task Update(Room Room);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
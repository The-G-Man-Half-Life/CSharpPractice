using PracticeC_.DTOs.Requests;
using PracticeC_.Models;

namespace PracticeC_.Repositories.Interfaces;
public interface IRoom_typeRepository
{
    Task<IEnumerable<Room_type>> GetAll();
    Task<Room_type?> GetById(int id);
    Task Add(Room_type Room_type);
    Task Update(Room_type Room_type);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
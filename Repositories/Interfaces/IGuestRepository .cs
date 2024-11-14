using PracticeC_.DTOs.Requests;
using PracticeC_.Models;

namespace PracticeC_.Repositories.Interfaces;
public interface IGuestRepository
{
    Task<IEnumerable<Guest>> GetAll();
    Task<Guest?> GetById(int id);
    Task Add(Guest Guest);
    Task Update(Guest Guest);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
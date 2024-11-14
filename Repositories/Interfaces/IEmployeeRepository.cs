using PracticeC_.DTOs.Requests;
using PracticeC_.Models;

namespace PracticeC_.Repositories.Interfaces;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee?> GetById(int id);
    Task Add(Employee Employee);
    Task Update(Employee Employee);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
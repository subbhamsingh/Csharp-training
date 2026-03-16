using TestWebApi.Models;

namespace TestWebApi.Services
{
    public interface IEmployeeTaskService
    {
        Task<IEnumerable<EmployeeTask>> GetAllAsync();
        Task<EmployeeTask> GetByIdAsync(int id);
        Task AddAsync(EmployeeTask task);
        Task UpdateAsync(EmployeeTask task);
        Task DeleteAsync(int id);



    }
}

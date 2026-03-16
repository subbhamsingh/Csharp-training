using TestWebApi.Models;
using TestWebApi.Repositories;

namespace TestWebApi.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _repository;
     
        public EmployeeTaskService(IEmployeeTaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeTask>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
        public Task<EmployeeTask> GetByIdAsync(int id)
        { 

            return _repository.GetByIdAsync(id);
        }
        public async Task AddAsync(EmployeeTask task)
        {
            if (task.Status != Status.Pending &&
        task.Status != Status.InProgress &&
        task.Status != Status.Completed)
            {
                throw new Exception("Invalid Task Status.");
            }
            var existing = await _repository.GetByIdAsync(task.Id);
            if(existing != null)
            {
                throw new Exception($"Task with Id {task.Id} already exists.");
            }

           
            await _repository.AddAsync(task);
        }
        public async Task UpdateAsync(EmployeeTask task)
        {
            if (task.Status != Status.Pending &&
        task.Status != Status.InProgress &&
        task.Status != Status.Completed)
            {
                throw new Exception("Invalid Task Status.");
            }
            var existing = await _repository.GetByIdAsync(task.Id);
            if (existing == null)
            {
                throw new Exception($"Task with Id {task.Id} not found.");
            }

            await _repository.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                throw new Exception($"Task with Id {id} not found.");
            }

            await _repository.DeleteAsync(id);
        }
    }
}

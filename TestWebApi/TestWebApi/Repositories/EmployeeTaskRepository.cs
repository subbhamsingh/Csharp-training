using TestWebApi.Models;

namespace TestWebApi.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {

        private static List<EmployeeTask> tasks = new List<EmployeeTask>
        {
            new EmployeeTask { Id = 1, Title = "Task 1", Description = "Demo 1", AssignedTo = "Raj",  Status = Status.Completed },
            new EmployeeTask { Id = 2, Title = "Task 2", Description = "Demo 2", AssignedTo = "Veer",  Status = Status.InProgress },
            new EmployeeTask { Id = 3, Title = "Task 3", Description = "Demo 3", AssignedTo = "Shobhit",  Status = Status.Completed },
            new EmployeeTask { Id = 4, Title = "Task 4", Description = "Demo 4", AssignedTo = "Rahul",  Status = Status.Pending },
            new EmployeeTask { Id = 5, Title = "Task 5", Description = "Demo 5", AssignedTo = "Puru", Status = Status.InProgress }
        };


        public Task<IEnumerable<EmployeeTask>> GetAllAsync()
        {
            return Task.FromResult(tasks.AsEnumerable());
        }
        public Task<EmployeeTask> GetByIdAsync(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(task);
        }
        public Task AddAsync(EmployeeTask task)
        {
            tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(EmployeeTask task)
        {
            var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.AssignedTo = task.AssignedTo;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                tasks.Remove(task);
            return Task.CompletedTask;
        }


    }
}

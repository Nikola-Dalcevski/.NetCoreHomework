using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models.IRepositories
{
    public interface ITaskRepository
    {
        Task Get(int Id);
        IEnumerable<Task> GetAll();
        Task Add(Task task);
        Task Update(Task task);
        Task Delete(int id);
    }
}

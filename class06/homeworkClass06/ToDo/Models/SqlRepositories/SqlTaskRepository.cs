using System;
using System.Collections.Generic;
using System.Linq;

using ToDo.Models.Entities;

using ToDo.Models.IRepositories;

namespace ToDo.Models.SqlRepositories
{
    public class SqlTaskRepository : ITaskRepository
    {

        private readonly AppDbContext db;
        public SqlTaskRepository(AppDbContext context)
        {
            db = context;
        }
       
        public Task Add(Task task)
        {
            db.Add(task);
            db.SaveChanges();
            return task;
        }

        public System.Threading.Tasks.Task Add(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            var task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return task;
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks;
        }

        public Task Update(Task changedTask)
        {
            var task = db.Tasks.Attach(changedTask);
            task.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return changedTask;
        }

        public System.Threading.Tasks.Task Update(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task ITaskRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task ITaskRepository.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<System.Threading.Tasks.Task> ITaskRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

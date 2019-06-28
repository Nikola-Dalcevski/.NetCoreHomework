using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.SqlRepositories
{
    public class SqlUserRepository : IUserRepository
    {

        private readonly AppDbContext Db;

        public SqlUserRepository(AppDbContext context)
        {
            Db = context;
        }


        public User Add(User user)
        {
            Db.Add(user);
            Db.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = Db.Users.Find(id);
            Db.Users.Remove(user);
            Db.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return Db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return Db.Users;
        }

        public User Update(User userChanges)
        {
            var user = Db.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();
            return userChanges;
        }
    }
}

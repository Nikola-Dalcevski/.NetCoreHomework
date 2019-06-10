using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.MockRepositories
{
    public class MockUserRepository : IUserRepository
    {

        List<User> users;

        public MockUserRepository()
        {
            users = new List<User>()
            {
                new User{ID=1, Name="Nikola",City="Skopje", Address="main street", Email="nikola@gmail", Phone="2222"},
                new User{ID=2, Name="Vukasin",City="Veles", Address="main street", Email="vukasin1@gmail", Phone="2222"},
                new User{ID=3, Name="Venko",City="Ohrid", Address="main street", Email="venko@gmail", Phone="2222"}
            };
        }

        public User Add(User user)
        {
            int newId = users.Max(x => x.ID) + 1;
            user.ID = newId;
            users.Add(user);
            return user;

        }

        public User Delete(int id)
        {
            User user = users.FirstOrDefault(x => x.ID == id);
            users.Remove(user);
            return user;
        }

        public User Get(int id)
        {
            User user = users.FirstOrDefault(x => x.ID == id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Update(User editUser)
        {
            User user = users.FirstOrDefault(x => x.ID == editUser.ID);
            if(user != null)
            {
                user.Name = editUser.Name;
                user.Email = editUser.Email;
                user.City = editUser.City;
                user.Address = editUser.Address;
                user.Phone = editUser.Phone;
            }
            return user;
        }

    }
}

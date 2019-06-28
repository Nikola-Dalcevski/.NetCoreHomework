using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.SqlRepositories
{
    public class SqlPizzaRepository : IPizzaRepository
    {

        private readonly  AppDbContext db;

        public SqlPizzaRepository(AppDbContext context)
        {
            db = context;
        }


        public Pizza Add(Pizza pizza)
        {
            db.Add(pizza);
            db.SaveChanges();
            return pizza;
            
        }

        public Pizza Delete(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
            db.SaveChanges();
            return pizza;
        }

        public Pizza Get(int id)
        {
            return db.Pizzas.Find(id);

        }

        public IEnumerable<Pizza> GetAll()
        {
            return db.Pizzas;
        }

        public Pizza Update(Pizza pizzaChanges)
        {
            var pizza = db.Pizzas.Attach(pizzaChanges);
            pizza.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return pizzaChanges;
        }
    }
}

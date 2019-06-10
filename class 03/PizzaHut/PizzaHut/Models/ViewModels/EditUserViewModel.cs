using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.ViewModels
{
    public class EditUserViewModel: CreateUserModel
    {
        public int ID { get; set; }
    }
}

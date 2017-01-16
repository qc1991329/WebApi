using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        User[] users = new User[] 
        {
            new User {id=1, name = "Michael" },
            new User {id=2, name = "Qian" },
            new User {id=3, name = "Fuck" }

        };

        public IEnumerable<User> GetAllUsers() {
            return users;
            

        }

        public User GetUserById(int id) {
            for (int i = 0; i < 3; i++) {
                if(users[i].id == id)
                    return users[i];

            }
                return null;

        }



    }
}

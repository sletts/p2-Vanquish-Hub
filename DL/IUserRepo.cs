using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IUserRepo
    {
        bool AddUser(User user, String connectionString);
        User SearchUser(User user, String connectionString);
        List<User> SearchUsers(String connectionString);


    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserRepoNew
    {
        User AddUser(User user);
        List<User> GetAllUsers();
        User GetUserByName(string name);
        User Update(User user);
        void DeleteUser(int id);
    }
}

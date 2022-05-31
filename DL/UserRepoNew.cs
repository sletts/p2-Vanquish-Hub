using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DL
{
    public class UserRepoNew : IUserRepoNew
    {
        private VanquishDBContext db;
        public UserRepoNew(VanquishDBContext db)
        {
            this.db = db;
        }
        public User AddUser(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var deletethis = db.users.Where(u => u.Id == id).FirstOrDefault();
            if(deletethis != null)
            {
                db.users.Remove(deletethis);
                db.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            return db.users.ToList();
        }

        public User GetUserByName(string name)
        {
            return db.users.Where(u => u.Username == name).FirstOrDefault();
        }

        public User Update(User user)
        {
            db.users.Update(user);
            db.SaveChanges();
            return user;
        }
    }
}

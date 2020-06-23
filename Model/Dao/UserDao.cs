using System.Collections.Generic;
using System.Linq;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        public UserDao()
        {
            this.Db = new ShopOnlineDbContext();
        }

        public ShopOnlineDbContext Db { get; private set; }
        //public List<User> ListCate()
        //{
        //    return Db.Users.ToList();
        //}
        //public User getById(int id)
        //{
        //    return Db.Users.Single(i => i.id == id);
        //}
        public bool checkLogin(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(username))
            {
                int a = Db.Users.Where(y => y.UserName == username && y.Password == password).ToList().Count();
                if (a >= 1)
                    return true;
            }
            return false;
        }
    }
}
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.Phonenum = reader["phone"].ToString();
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.IsAdmin = bool.Parse(reader["isAdmin"].ToString());
            user.Birthday = DateTime.Parse(reader["birthday"].ToString());
            TypeSurfDB sdb = new TypeSurfDB();
            user.Surfslst = sdb.SelectByUser(user);
            return user;

        }

        public override BaseEntity NewEntity()
        {
            return new User();
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUsers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectByID(int id)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE (id = {id})";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE (email = '{user.Email}') AND ([password] = '{user.Password}')";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

    }
}

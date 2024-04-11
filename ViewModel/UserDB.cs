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
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.Phonenum = reader["phone"].ToString();
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.IsAdmin = bool.Parse(reader["isAdmin"].ToString());
            user.Birthday = DateTime.Parse(reader["birthday"].ToString());

            TypeSurfDB sdb = new TypeSurfDB();
            user.Surfslst = sdb.SelectByUser(user);
            return user;

        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@firstname", user.FirstName);
            command.Parameters.AddWithValue("@lastname", user.LastName);
            command.Parameters.AddWithValue("@birthday", user.Birthday);
            command.Parameters.AddWithValue("@phone", user.Phonenum);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
            command.Parameters.AddWithValue("@id", user.ID);
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
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO tblUsers ([password], firstname, lastname, birthday, phone, email, isAdmin) VALUES (@password, @firstname, @lastname, @birthday, @phone, @email, @isAdmin)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE tblUsers SET [password] = @password, firstname = @firstname, lastname = @lastname, birthday = @birthday, phone = @phone, email = @email, isAdmin = @isAdmin WHERE (id = @id)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM tblUsers WHERE (id = @id) ";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE (tblUsers.email = '{user.Email}') AND (tblUsers.password = '{user.Password}')";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public User SelectByEmail(string email)
        {
            command.CommandText = $"SELECT * FROM tblUsers WHERE (tblUsers.email = '{email}')";
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}

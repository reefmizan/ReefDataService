using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class User:BaseEntity
    {
        protected string firstname;
        protected bool isAdmin;
        protected string lastname;
        protected string phonenum;
        protected string email;
        protected string password;
        protected DateTime birthday;
        protected TypeSurfList surfslst;


        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Phonenum
        {
            get { return phonenum; }
            set { phonenum = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public TypeSurfList Surfslst
        {
            get { return surfslst; }
            set { surfslst = value; }
        }
    }
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}

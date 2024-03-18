using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    [DataContract]
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

        [DataMember]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [DataMember]
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [DataMember]
        public string Phonenum
        {
            get { return phonenum; }
            set { phonenum = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        [DataMember]
        public TypeSurfList Surfslst
        {
            get { return surfslst; }
            set { surfslst = value; }
        }
    }
    [CollectionDataContract]
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

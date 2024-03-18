using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Comments : BaseEntity
    {
        protected string content;
        protected User user;
        protected Locations location;
        protected DateTime cdatetime;
        [DataMember]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        [DataMember]
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        [DataMember]
        public DateTime Cdatetime
        {
            get { return cdatetime; }
            set { cdatetime = value; }
        }
        [DataMember]
        public Locations Location
        {
            get { return location; }
            set { location = value; }
        }
    }
        [CollectionDataContract]
        public class CommentsList : List<Comments>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public CommentsList() { }
            //המרה אוסף גנרי לרשימת ערים
            public CommentsList(IEnumerable<Comments> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת ערים
            public CommentsList(IEnumerable<BaseEntity> list)
                : base(list.Cast<Comments>().ToList()) { }
        }
    }


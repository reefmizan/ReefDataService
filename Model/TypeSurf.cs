using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class TypeSurf: BaseEntity
    {
        protected string name;
        protected string description;
        protected string urls;

        [DataMember]
        public string Name{
            get { return name; }
            set { name = value; } 
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string URLS
        {
            get { return urls; }
            set { urls = value; }
        }
    }
    [CollectionDataContract]
    public class TypeSurfList : List<TypeSurf>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public TypeSurfList() { }
        //המרה אוסף גנרי לרשימת ערים
        public TypeSurfList(IEnumerable<TypeSurf> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת ערים
        public TypeSurfList(IEnumerable<BaseEntity> list)
            : base(list.Cast<TypeSurf>().ToList()) { }
    }
}

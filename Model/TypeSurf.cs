using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypeSurf: BaseEntity
    {
        protected string name;

        public string Name{
            get { return name; }
            set { name = value; } 
        }
    }
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

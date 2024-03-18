using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class SurfClubs : BaseEntity
    {
        protected string name;
        protected Locations location;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public Locations Location
        {
            get { return location; }
            set { location = value; }
        }
    }
    [CollectionDataContract]
    public class SurfClubsList : List<SurfClubs>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public SurfClubsList() { }
            //המרה אוסף גנרי לרשימת ערים
            public SurfClubsList(IEnumerable<SurfClubs> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת ערים
            public SurfClubsList(IEnumerable<BaseEntity> list)
                : base(list.Cast<SurfClubs>().ToList()) { }
        }
    }


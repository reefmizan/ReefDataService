using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Locations : BaseEntity
    {
        protected string name;
        protected string description;
        protected string weatherlink;
        protected string cord;
        [DataMember]
        public string Name
        {
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
        public string WeatherLink
        {
            get { return weatherlink; }
            set { weatherlink = value; }
        }
        [DataMember]
        public string Cord
        {
            get { return cord; }
            set { cord = value; }
        }
    }
    [CollectionDataContract]
    public class LocationsList : List<Locations>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public LocationsList() { }
            //המרה אוסף גנרי לרשימת ערים
            public LocationsList(IEnumerable<Locations> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת ערים
            public LocationsList(IEnumerable<BaseEntity> list)
                : base(list.Cast<Locations>().ToList()) { }
        }
    }


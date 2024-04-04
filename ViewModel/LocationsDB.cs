using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Locations;

namespace ViewModel
{
    public class LocationsDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Locations location = entity as Locations;
            location.ID = int.Parse(reader["id"].ToString());
            location.Name = reader["name"].ToString();
            location.Description = reader["description"].ToString();
            location.Cord = reader["cord"].ToString();
            return location;
        }

        protected override BaseEntity NewEntity()
        {
            return new Locations();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Locations location = entity as Locations;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", location.Name);
            command.Parameters.AddWithValue("@description", location.Description);
            command.Parameters.AddWithValue("@cord", location.Cord);
            command.Parameters.AddWithValue("@id", location.ID);
        }
        public LocationsList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblLocations";
            LocationsList list = new LocationsList(ExecuteCommand());
            return list;
        }
        public int Insert(Locations locations)
        {
            command.CommandText = "INSERT INTO tblLocations (name, description, cord) VALUES (@name, @description, @cord)";
            LoadParameters(locations);
            return ExecuteCRUD();
        }
        public int Update(Locations locations)
        {
            command.CommandText = "UPDATE tblLocations SET name = @name, description = @description, cord =@cord WHERE (id = @id)";
            LoadParameters(locations);
            return ExecuteCRUD();
        }
        public int Delete(Locations locations)
        {
            command.CommandText = "DELETE FROM tblLocations WHERE (id = @id) ";
            LoadParameters(locations);
            return ExecuteCRUD();
        }
        public Locations SelectByID(int id)
        {
            command.CommandText = $"SELECT * FROM tblLocations WHERE (id = {id})";
            LocationsList list = new LocationsList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.SurfClubs;

namespace ViewModel
{
    public class SurfClubsDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            SurfClubs surfclub = entity as SurfClubs;
            surfclub.ID = int.Parse(reader["id"].ToString());
            surfclub.Name = reader["name"].ToString();
            LocationsDB ldb = new LocationsDB();
            int lcid = int.Parse(reader["id"].ToString());
            surfclub.Description = reader["description"].ToString();
            surfclub.Location = ldb.SelectByID(lcid);
            surfclub.Cord = reader["cord"].ToString();


            return surfclub;
            
        }
        protected override BaseEntity NewEntity()

        {
            return new SurfClubs();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            SurfClubs surfclub = entity as SurfClubs;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", surfclub.Name);
            command.Parameters.AddWithValue("@location", surfclub.Location.ID);
            command.Parameters.AddWithValue("@id", surfclub.ID);
            command.Parameters.AddWithValue("@cord", surfclub.Cord);
            command.Parameters.AddWithValue("@description", surfclub.Description);


        }
        public int Insert(SurfClubs surfClubs)
        {
            command.CommandText = "INSERT INTO tblSurfClubs (name, location, cord, description) VALUES (@name, @location, @cord, @description)";
            LoadParameters(surfClubs);
            return ExecuteCRUD();
        }
        public int Update(SurfClubs surfClubs)
        {
            command.CommandText = "UPDATE tblSurfClubs SET name = @name, location = @location, cord = @cord, description = @description WHERE (id = @id)";
            LoadParameters(surfClubs);
            return ExecuteCRUD();
        }
        public int Delete(SurfClubs surfClubs)
        {
            command.CommandText = "DELETE FROM tblSurfClubs WHERE (id = @id) ";
            LoadParameters(surfClubs);
            return ExecuteCRUD();
        }
        public SurfClubsList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblSurfClubs";
            SurfClubsList list = new SurfClubsList(ExecuteCommand());
            return list;
        }
        public SurfClubs SelectByID(int id)
        {
            command.CommandText = $"SELECT * FROM tblSurfClubs WHERE (id = {id})";
            SurfClubsList list = new SurfClubsList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public SurfClubsList SelectByLocation(int location)
        {
            command.CommandText = $"SELECT * FROM tblSurfClubs WHERE (location = {location})";
            SurfClubsList list = new SurfClubsList(ExecuteCommand());
            return list;
        }
    }
}

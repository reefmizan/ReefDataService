using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TypeSurfDB: BaseDB
    {
        protected override BaseEntity NewEntity()
        { return new TypeSurf(); }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            TypeSurf item = entity as TypeSurf;
            item.ID = int.Parse(reader["id"].ToString());
            item.Name = reader["name"].ToString();
            item.Description = reader["description"].ToString();
            item.URLS = reader["URLS"].ToString();
            return item;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            TypeSurf item = entity as TypeSurf;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@description", item.Description);
            command.Parameters.AddWithValue("@id", item.ID);
            command.Parameters.AddWithValue("@URLS", item.URLS);

        }
        public int Insert(TypeSurf typeSurf)
        {
            command.CommandText = "INSERT INTO tblTypeSurf (name,description) VALUES (@name,@description,@urls)";
            LoadParameters(typeSurf);
            return ExecuteCRUD();
        }
        public int Update(TypeSurf typeSurf)
        {
            command.CommandText = "UPDATE tblTypeSurf SET name = @name,description = @description,URLS = @urls WHERE (id = @id)";
            LoadParameters(typeSurf);
            return ExecuteCRUD();
        }
        public int Delete(TypeSurf typeSurf)
        {
            command.CommandText = "DELETE FROM tblTypeSurf WHERE (id = @id) ";
            LoadParameters(typeSurf);
            return ExecuteCRUD();
        }
        public TypeSurfList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblTypeSurf";
            return new TypeSurfList(ExecuteCommand());
        }
        public TypeSurfList SelectByUser(User user)
        {
            command.CommandText = $"SELECT * " +
                $"FROM (tblUserTypeSurf INNER JOIN tblTypeSurf ON tblUserTypeSurf.TypeSurfid = tblTypeSurf.id) " +
                $"WHERE (tblUserTypeSurf.Userid = {user.ID})";
            return new TypeSurfList(ExecuteCommand());
        }       
        public TypeSurfList SelectByID(int id)
        {
            command.CommandText = "SELECT * FORM tblTypeSurf " +
                $" WHERE (id = {id})";
            return new TypeSurfList(ExecuteCommand());
        }
    }
}

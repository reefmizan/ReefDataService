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
        public override BaseEntity NewEntity()
        { return new TypeSurf(); }

        public override BaseEntity CreateModel(BaseEntity entity)
        {
            TypeSurf item = entity as TypeSurf;
            item.ID = int.Parse(reader["id"].ToString());
            item.Name = reader["name"].ToString();
            return item;
        }
        public TypeSurfList SelectAll()
        {
            command.CommandText = "SELECT * FORM tblTypeSurf";
            return new TypeSurfList(ExecuteCommand());
        }
        public TypeSurfList SelectByUser(User user)
        {
            command.CommandText = $"SELECT * " +
                $"FROM (tblUserTypeSurf INNER JOIN tblTypeSurf ON tblUserTypeSurf.TypeSurfid = tblTypeSurf.id) " +
                $"WHERE (tblUserTypeSurf.Userid = {user.ID}";
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

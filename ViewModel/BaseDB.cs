using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=C:\\Users\\gold\\source\\repos\\Model\\ViewModel\\myDb.accdb;" +
            "Persist Security Info=True";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public abstract BaseEntity NewEntity();
        public abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }
        public List<BaseEntity> ExecuteCommand()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection != null)
                    connection.Close();
            }
            return list;
        }
    }
}

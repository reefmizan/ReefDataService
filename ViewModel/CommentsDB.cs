using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Comments;
using static Model.SurfClubs;

namespace ViewModel
{
    public class CommentsDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Comments comment = entity as Comments;
            comment.ID = int.Parse(reader["id"].ToString());
            comment.Content = reader["content"].ToString();
            comment.Cdatetime = DateTime.Parse(reader["content"].ToString());
            LocationsDB ldb = new LocationsDB();
            int lcid = int.Parse(reader["id"].ToString());
            comment.Location = ldb.SelectByID(lcid);
            UserDB udb = new UserDB();
            int usid = int.Parse(reader["id"].ToString());
            comment.User = udb.SelectByID(usid);
            return comment;
        }

        protected override BaseEntity NewEntity()
        {
            return new Comments();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Comments comments = entity as Comments;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@content", comments.Content);
            command.Parameters.AddWithValue("@cdatetime", comments.Cdatetime);
            command.Parameters.AddWithValue("@location", comments.Location.ID);
            command.Parameters.AddWithValue("@user", comments.User.ID);
            command.Parameters.AddWithValue("@id", comments.ID);
        }
        public CommentsList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblComments";
            CommentsList list = new CommentsList(ExecuteCommand());
            return list;
        }
        public int Insert(Comments comments)
        {
            command.CommandText = "INSERT INTO tblComments (content, cdatetime, location, user) VALUES (@content, @cdatetime, @location, @user)";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
        public int Update(Comments comments)
        {
            command.CommandText = "UPDATE tblComments SET content = @content, cdatetime = @cdatetime, location = @location, user =@user WHERE (id = @id)";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
        public int Delete(Comments comments)
        {
            command.CommandText = "DELETE FROM tblComments WHERE (id = @id) ";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
        public Comments SelectByID(int id)
        {
            command.CommandText = $"SELECT * FROM tblComments WHERE (id = {id})";
            CommentsList list = new CommentsList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}


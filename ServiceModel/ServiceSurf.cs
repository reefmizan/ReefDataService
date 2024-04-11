using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class ServiceSurf : IServiceSurf
    {
        #region User
        public UserList GetAllUser()
        {
            UserDB db = new UserDB();
            UserList list = db.SelectAll();
            return list;
        }
        public User LogIn(User user)
        {
            UserDB db = new UserDB();
            User user1 = db.Login(user);
            if (user1 == null)
                return null;
            if (user1.Password.Equals(user.Password))
                return user1;
            return null;
        }
        public bool IsEmailFree(string email)
        {
            UserDB db = new UserDB();
            return db.SelectByEmail(email)==null;
        }
        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            int num = db.Insert(user);
            if (num == 0) return -1;
            user.ID= db.SelectAll().Last().ID; //get user Id
            TypeSurfDB surfDB=new TypeSurfDB();
            foreach (TypeSurf type in user.Surfslst)
            {
                if (surfDB.InsertType(type, user) == 0)
                    return -1;
            }
            return 1;
        }
        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            int num = db.Update(user);
            return num;
        }
        public int DeleteUser(User user)
        {
            TypeSurfDB typeSurfDB = new TypeSurfDB();
            foreach (TypeSurf type in user.Surfslst)
            {
                typeSurfDB.DeleteType(type, user);
            }
            UserDB db = new UserDB();
            int num = db.Delete(user);
            return num;
        }
        #endregion
        #region TypeSurf
        public TypeSurfList GetAllTypeSurf()
        {
            TypeSurfDB db = new TypeSurfDB();
            TypeSurfList list = db.SelectAll();
            return list;
        }
        public int InsertTypeSurf(TypeSurf typeSurf)
        {
            TypeSurfDB db = new TypeSurfDB();
            int num = db.Insert(typeSurf);
            return num;
        }
        public int UpdateTypeSurf(TypeSurf typeSurf)
        {
            TypeSurfDB db = new TypeSurfDB();
            int num = db.Update(typeSurf);
            return num;
        }
        public int DeleteTypeSurf(TypeSurf typeSurf)
        {
            TypeSurfDB db = new TypeSurfDB();
            int num = db.Delete(typeSurf);
            return num;
        }
        #endregion
        #region SurfClubs
        public SurfClubsList GetAllSurfClubs()
        {
            SurfClubsDB db = new SurfClubsDB();
            SurfClubsList list = db.SelectAll();
            return list;
        }
        public int InsertSurfClubs(SurfClubs surfClubs)
        {
            SurfClubsDB db = new SurfClubsDB();
            int num = db.Insert(surfClubs);
            return num;
        }
        public int UpdateSurfClubs(SurfClubs surfClubs)
        {
            SurfClubsDB db = new SurfClubsDB();
            int num = db.Update(surfClubs);
            return num;
        }
        public int DeleteSurfClubs(SurfClubs surfClubs)
        {
            SurfClubsDB db = new SurfClubsDB();
            int num = db.Delete(surfClubs);
            return num;
        }
        public SurfClubsList SelectByLocation(int location)
        {
            SurfClubsDB db = new SurfClubsDB();
            SurfClubsList surfClubs = db.SelectByLocation(location);
            return surfClubs;
        }
        #endregion
        #region Locations
        public LocationsList GetAllLocations()
        {
            LocationsDB db = new LocationsDB();
            LocationsList list = db.SelectAll();
            return list;
        }
        public int InsertLocations(Locations locations)
        {
            LocationsDB db = new LocationsDB();
            int num = db.Insert(locations);
            return num;
        }
        public int UpdateLocations(Locations locations)
        {
            LocationsDB db = new LocationsDB();
            int num = db.Update(locations);
            return num;
        }
        public int DeleteLocations(Locations locations)
        {
            LocationsDB db = new LocationsDB();
            int num = db.Delete(locations);
            return num;
        }
        #endregion
        #region Comments
        public CommentsList GetAllComments()
        {
            CommentsDB db = new CommentsDB();
            CommentsList list = db.SelectAll();
            return list;
        }
        public int InsertComments(Comments comments)
        {
            CommentsDB db = new CommentsDB();
            int num = db.Insert(comments);
            return num;
        }
        public int UpdateComments(Comments comments)
        {
            CommentsDB db = new CommentsDB();
            int num = db.Update(comments);
            return num;
        }
        public int DeleteComments(Comments comments)
        {
            CommentsDB db = new CommentsDB();
            int num = db.Delete(comments);
            return num;
        }

        
        #endregion
    }
}

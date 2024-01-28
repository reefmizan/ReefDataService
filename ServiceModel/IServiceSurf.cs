using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceSurf
    {
        #region User
        [OperationContract] UserList GetAllUser();
        [OperationContract] User LogIn(User user);
        [OperationContract] bool IsEmailFree(string email);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        #endregion
        #region TypeSurf
        [OperationContract] TypeSurfList GetAllTypeSurf();
        [OperationContract] int InsertTypeSurf(TypeSurf typeSurf);
        [OperationContract] int UpdateTypeSurf(TypeSurf typeSurf);
        [OperationContract] int DeleteTypeSurf(TypeSurf typeSurf);
        #endregion
        #region SurfClubs
        [OperationContract] SurfClubsList GetAllSurfClubs();
        [OperationContract] int InsertSurfClubs(SurfClubs surfClubs);
        [OperationContract] int UpdateSurfClubs(SurfClubs surfClubs);
        [OperationContract] int DeleteSurfClubs(SurfClubs surfClubs);
        #endregion
        #region Locations
        [OperationContract] LocationsList GetAllLocations();
        [OperationContract] int InsertLocations(Locations locations);
        [OperationContract] int UpdateLocations(Locations locations);
        [OperationContract] int DeleteLocations(Locations locations);
        #endregion
        #region Comments
        [OperationContract] CommentsList GetAllComments();
        [OperationContract] int InsertComments(Comments comments);
        [OperationContract] int UpdateComments(Comments comments);
        [OperationContract] int DeleteComments(Comments comments);
        #endregion
    }
}

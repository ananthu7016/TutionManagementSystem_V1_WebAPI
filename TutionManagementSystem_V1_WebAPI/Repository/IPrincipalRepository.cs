using Microsoft.AspNetCore.Mvc;
using TutionManagementSystem_V1_WebAPI.Model;

namespace TutionManagementSystem_V1_WebAPI.Repository
{
    public interface IPrincipalRepository
    {

        // this is the interface for the Principal repository here we need to declare all the methods that are responsible for the 
        // functionalities of Principal Role 



        #region Add a new Student Details 

        Task<ActionResult<int>> RegisterNewStudent(Student student);

        #endregion

    }
}

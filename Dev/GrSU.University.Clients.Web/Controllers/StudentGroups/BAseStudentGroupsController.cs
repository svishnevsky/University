namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using System.Web.Mvc;
    using Data.EF;
    using Domain;
    using Domain.Services;

    public abstract class BaseStudentGroupsController : Controller
    {
        protected readonly IStudentGroupServiceAsync StudentGroupService;

        protected BaseStudentGroupsController()
        {
            this.StudentGroupService = new StudentGroupService(new StudentGroupRepository(new DataContext("defaultconnection")));
        }
	}
}
using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.Students
{
    using System.Linq;
    using System.Web.Mvc;
    using Domain;
    using Domain.Model;
    using Models.Students;

    public class StudentsController : BaseListController<IStudentServiceAsync, Student, StudentModel, StudentListModel>
    {
        private readonly IStudentGroupServiceAsync studentGroupService;

        public StudentsController(IStudentServiceAsync studentService, IStudentGroupServiceAsync studentGroupService, IMapper mapper)
            : base(studentService, mapper)
        {
            this.studentGroupService = studentGroupService;
        }

        protected override StudentModel PrepairModel(StudentModel model = null)
        {
            var groups = this.studentGroupService.GetAsync()
                .Result.Select(
                    sg =>
                        new SelectListItem { Text = sg.Name, Value = sg.Id.ToString() })
                .ToList();

            if (groups.Any())
            {
                groups.First().Selected = true;
            }

            var m = model ?? new StudentModel();
            m.StudentGroups = groups;

            return m;
        }
    }
}
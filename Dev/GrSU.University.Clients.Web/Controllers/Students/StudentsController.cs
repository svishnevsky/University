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

        public StudentsController(IStudentServiceAsync studentService, IStudentGroupServiceAsync studentGroupService)
            : base(studentService)
        {
            this.studentGroupService = studentGroupService;
        }

        protected override StudentListModel MapListModel(Student entity)
        {
            var group = this.studentGroupService.GetAsync(entity.GroupId).Result;

            return new StudentListModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Group = new GroupModel
                {
                    Id = group.Id,
                    Name = group.Name
                }
            };
        }

        protected override Student Map(StudentModel model)
        {
            return new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                GroupId = model.GroupId
            };
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
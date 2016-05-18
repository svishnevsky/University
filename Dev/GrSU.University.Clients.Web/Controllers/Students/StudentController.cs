using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.Students
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Domain;
    using Domain.Model;
    using Models.Students;

    public class StudentController : BaseEntityController<IStudentServiceAsync, Student, StudentModel>
    {
        private readonly IStudentGroupServiceAsync studentGroupService;

        public StudentController(IStudentServiceAsync studentService, IStudentGroupServiceAsync studentGroupService, IMapper mapper)
            : base(studentService, mapper)
        {
            this.studentGroupService = studentGroupService;
        }

        protected override StudentModel PrepairModel(StudentModel model = null)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var groups = this.studentGroupService.GetAsync()
                .Result.Select(
                    sg =>
                        new SelectListItem { Text = sg.Name, Value = sg.Id.ToString(), Selected = sg.Id == model.GroupId })
                .ToList();

            model.StudentGroups = groups;

            return model;
        }
    }
}
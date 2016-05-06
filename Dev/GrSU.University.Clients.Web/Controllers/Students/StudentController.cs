﻿namespace GrSU.University.Clients.Web.Controllers.Students
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.EF;
    using Domain;
    using Domain.Model;
    using Domain.Services;
    using Models.Students;

    public class StudentController : BaseEntityController<IStudentServiceAsync, Student, StudentModel>
    {
        private readonly IStudentGroupServiceAsync studentGroupService;

        public StudentController()
            : base(new StudentService(new StudentRepository(new DataContext("defaultconnection"))))
        {
            this.studentGroupService =
                new StudentGroupService(new StudentGroupRepository(new DataContext("defaultconnection")));
        }

        protected override Student Map(StudentModel model)
        {
            return new Student
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GroupId = model.GroupId
            };
        }

        protected override StudentModel Map(Student entity)
        {
            return PrepairModel(new StudentModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                GroupId = entity.GroupId
            });
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
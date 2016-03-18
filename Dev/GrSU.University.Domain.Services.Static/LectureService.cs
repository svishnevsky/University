using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class LectureService : DomainService<Lecture>, ILectureService
    {
        private readonly List<Lecture> entities = new List<Lecture>();

        private readonly IStudentGroupService studentGroupService;

        private readonly IEmployeeService employeeService;

        private readonly IRoomService roomService;

        public LectureService(IStudentGroupService studentGroupService,
            IEmployeeService employeeService,
            IRoomService roomService,
            IAuditManager auditmanager) : base(auditmanager)
        {
            this.studentGroupService = studentGroupService;
            this.employeeService = employeeService;
            this.roomService = roomService;
        }

        protected override List<Lecture> GetEntities()
        {
            return entities;
        }

        protected override void Resolve(ref Lecture entity)
        {
            base.Resolve(ref entity);
            entity.Group = entity.GroupId <= 0 ? null : studentGroupService.Get(entity.GroupId);
            entity.Lector = entity.LectorId <= 0 ? null : employeeService.Get(entity.LectorId);
            entity.Room = entity.RoomId <= 0 ? null : roomService.Get(entity.RoomId);
        }
    }
}

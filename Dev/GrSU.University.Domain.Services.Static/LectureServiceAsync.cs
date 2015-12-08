using System.Collections.Generic;
using GrSU.University.Domain.Model;
using System.Threading.Tasks;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class LectureServiceAsync : DomainServiceAsync<Lecture>, ILectureServiceAsync
    {
        private readonly List<Lecture> entities = new List<Lecture>();

        private readonly IStudentGroupServiceAsync studentGroupService;

        private readonly IEmployeeServiceAsync employeeService;

        private readonly IRoomServiceAsync roomService;

        public LectureServiceAsync(IStudentGroupServiceAsync studentGroupService,
            IEmployeeServiceAsync employeeService,
            IRoomServiceAsync roomService,
            IAuditManager auditManager)
            : base(auditManager)
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

            var groupTask = entity.GroupId <= 0 ? Task.FromResult<StudentGroup>(null) : studentGroupService.GetAsync(entity.GroupId);

            var lectorTask = entity.LectorId <= 0 ? Task.FromResult<Employee>(null) : employeeService.GetAsync(entity.LectorId);

            var roomTask = entity.RoomId <= 0 ? Task.FromResult<Room>(null) : roomService.GetAsync(entity.RoomId);

            entity.Group = groupTask.Result;
            entity.Lector = lectorTask.Result;
            entity.Room = roomTask.Result;
        }
    }
}

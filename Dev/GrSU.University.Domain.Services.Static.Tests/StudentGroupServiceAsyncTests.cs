using System;
using System.Linq;
using System.Threading.Tasks;
using GrSU.University.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrSU.University.Audit.Services;

namespace GrSU.University.Domain.Services.Static.Tests
{
    [TestClass]
    public class StudentGroupServiceAsyncTests
    {
        private readonly IStudentGroupServiceAsync service;

        public StudentGroupServiceAsyncTests()
        {
            this.service = new StudentGroupServiceAsync(new AuditManager());

            service.AddAsync(new StudentGroup
                        {
                            Name = "First group"
                        }).Wait();

            service.AddAsync(new StudentGroup
            {
                Name = "Second group"
            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();

            var newGroup = new StudentGroup
                           {
                               Name = name
                           };

            var addedGroupTask = service.AddAsync(newGroup);

            var addedGroup = addedGroupTask.Result;

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.AreEqual(addedGroup.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var group = service.GetAsync(1).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var group = service.GetAsync(1).Result;
            var name = group.Name;
            group.Name = Guid.NewGuid().ToString();
            var newGroup = service.GetAsync(1).Result;
            Assert.AreEqual(newGroup.Name, name);
        }   

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var group = service.GetAsync(int.MaxValue).Result;

            Assert.IsNull(group);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var groupList = service.GetAsync().Result;

            Assert.IsNotNull(groupList);
            Assert.IsTrue(groupList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var group = service.GetAsync().Result.First();

            group.Name = group.Name + "1";

            service.UpdateAsync(group).Wait();

            var updatedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(updatedGroup.Name, group.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void UpdateNotFoundTest()
        {
            service.UpdateAsync(new StudentGroup
                           {
                               Id = int.MaxValue
                           }).Wait();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var group = service.GetAsync().Result.Last();
            service.DeleteAsync(group.Id).Wait();

            var deletedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNull(deletedGroup);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DeleteNotFoundTest()
        {
            service.DeleteAsync(int.MaxValue)
                .Wait();
        }
    }
}

using System;
using System.Linq;
using GrSU.University.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrSU.University.Domain.Services.Static.Tests
{
    [TestClass]
    public class StudentGroupServiceTests
    {
        private readonly IStudentGroupService service;

        public StudentGroupServiceTests()
        {
            this.service = new StudentGroupService();

            service.Add(new StudentGroup
                        {
                            Name = "First group"
                        });

            service.Add(new StudentGroup
            {
                Name = "Second group"
            });
        }

        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();

            var newGroup = new StudentGroup
                           {
                               Name = name
                           };

            var addedGroup = service.Add(newGroup);

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.AreEqual(addedGroup.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var group = service.Get(1);

            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var group = service.Get(1);
            var name = group.Name;
            group.Name = Guid.NewGuid().ToString();
            var newGroup = service.Get(1);
            Assert.AreEqual(newGroup.Name, name);
        }   

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var group = service.Get(int.MaxValue);

            Assert.IsNull(group);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var groupList = service.Get();

            Assert.IsNotNull(groupList);
            Assert.IsTrue(groupList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var group = service.Get().First();

            group.Name = group.Name + "1";

            service.Update(group);

            var updatedGroup = service.Get(group.Id);

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(updatedGroup.Name, group.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundTest()
        {
            service.Update(new StudentGroup
                           {
                               Id = int.MaxValue
                           });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var group = service.Get().Last();
            service.Delete(group.Id);

            var deletedGroup = service.Get(group.Id);

            Assert.IsNull(deletedGroup);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteNotFoundTest()
        {
            service.Delete(int.MaxValue);
        }
    }
}

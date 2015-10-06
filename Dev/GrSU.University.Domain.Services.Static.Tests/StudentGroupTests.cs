namespace GrSU.University.Domain.Services.Static.Tests
{
    using System;
    using System.Linq;
    using Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for StudentGroupTests
    /// </summary>
    [TestClass]
    public class StudentGroupTests
    {
        private StudentGroupService service;

        public StudentGroupTests()
        {
            service = new StudentGroupService();
            service.Add(new StudentGroup
                        {
                            Name = "Group 1"
                        });
        }

        [TestMethod]
        public void GetAllTest()
        {
            var items = service.Get();
            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetItemTest()
        {
            const int groupId = 1;
            var group = service.Get(groupId);
            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, groupId);
        }

        [TestMethod]
        public void GetItemNotFoundTest()
        {
            var group = service.Get(int.MaxValue);
            Assert.IsNull(group);
        }
        
        [TestMethod]
        public void AddItemTest()
        {
            var items = service.Get().ToArray();
            var guid = Guid.NewGuid().ToString();
            var group = new StudentGroup
                        {
                            Name = guid
                        };

            service.Add(group);

            var newItems = service.Get();
            Assert.IsTrue(items.Length + 1 == newItems.Count);

            var addedGroup = newItems.FirstOrDefault(item => item.Name.Equals(guid));

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.IsTrue(newItems.Select(item => item.Id).Distinct().Count() == newItems.Count);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new StudentGroup {Name = "Test"});

            var guid = Guid.NewGuid().ToString();

            item.Name = guid;

            service.Update(item);

            var newItem = service.Get(item.Id);

            Assert.AreEqual(newItem.Name, guid);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateItemNotFoundTest()
        {
            var notFoundGroup = new StudentGroup
                                {
                                    Id = int.MaxValue,
                                    Name = "Some name"
                                };

            service.Update(notFoundGroup);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new StudentGroup { Name = "Test" });
            service.Delete(item.Id);
            var deletedItem = service.Get(item.Id);

            Assert.IsNull(deletedItem);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemNotFoundTest()
        {
            service.Delete(int.MaxValue);
        }
    }
}

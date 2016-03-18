namespace GrSU.University.Domain.Services.Tests
{
    using System;
    using System.Linq;
    using Data.EF;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;

    [TestClass]
    public class RoomServiceAsyncTests
    {
        private readonly IRoomServiceAsync service;

        public RoomServiceAsyncTests()
        {
            this.service = new RoomService(new RoomRepository(new DataContext("defaultconnection")));

            service.AddAsync(new Room
                        {
                            Number = "123",
                            SitsCount = 15
                        }).Wait();

            service.AddAsync(new Room
            {
                Number = "124",
                SitsCount = 17
            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();

            var newGroup = new Room
                           {
                               Number = name
                           };

            var addedGroupTask = service.AddAsync(newGroup);

            var addedGroup = addedGroupTask.Result;

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.AreEqual(addedGroup.Number, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var group = service.GetAsync(1).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, 1);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var groupList = service.GetAsync().Result;

            Assert.IsNotNull(groupList);
            Assert.IsTrue(groupList.Count > 0);
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

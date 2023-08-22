using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendLibrary.Models;
using BackendLibrary.DataAccess;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(1)]
    public class RemovalDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllRemovalsReturnNotNull()
        {
            var output = await Task.Run(() => RemovalData.GetAllRemovals());

            Assert.NotNull(output);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => RemovalData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(3)]
        public async void GetRemovalTest()
        {
            var output = await Task.Run(() => RemovalData.GetRemoval(-2137));

            Assert.True(output.Id == -1);
        }

        [Fact, Order(4)]
        public async void InsertRemovalTest()
        {
            RemovalModel newRemoval = new RemovalModel(0, 1, "1970-01-01");
            await Task.Run(() => RemovalData.InsertRemoval(newRemoval));
            RemovalModel addedRemoval = await Task.Run(() => RemovalData.GetRemoval(RemovalData.GetMaxId()));

            try
            {
                Assert.Equal(addedRemoval.Date, "01/01/1970 00:00:00");
            }
            finally
            {
                await Task.Run(() => RemovalData.DeleteRemoval(addedRemoval.Id));
            }
        }

        [Fact, Order(5)]
        public async void DeleteRemovalTest()
        {
            RemovalModel newRemoval = new RemovalModel(0, 1, "1970-01-01");
            await Task.Run(() => RemovalData.InsertRemoval(newRemoval));
            int id = await Task.Run(() => RemovalData.GetMaxId());
            await Task.Run(() => RemovalData.DeleteRemoval(id));
            RemovalModel deletedRemoval = await Task.Run(() => RemovalData.GetRemoval(id));

            Assert.Equal(deletedRemoval.Id, -1);
        }
    }
}

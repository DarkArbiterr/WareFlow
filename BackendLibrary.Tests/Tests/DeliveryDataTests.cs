using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendLibrary.Models;
using BackendLibrary.DataAccess;
using Xunit;
using XUnitPriorityOrderer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendLibrary.Tests.Tests
{
    [Order(2)]
    public class DeliveryDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllDeliverysReturnNotNull()
        {
            var output = await Task.Run(() => DeliveryData.GetAllDeliveries());

            Assert.NotNull(output);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => DeliveryData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(3)]
        public async void GetDeliveryTest()
        {
            var output = await Task.Run(() => DeliveryData.GetDelivery(-2137));

            Assert.True(output.Id == -1);
        }

        [Fact, Order(4)]
        public async void InsertDeliveryTest()
        {
            DeliveryModel newDelivery = new DeliveryModel(0, 1, "1970-01-01");
            await Task.Run(() => DeliveryData.InsertDelivery(newDelivery));
            DeliveryModel addedDelivery = await Task.Run(() => DeliveryData.GetDelivery(DeliveryData.GetMaxId()));

            try
            {
                Assert.Equal("1970-01-01", newDelivery.Date);
            }
            finally
            {
                await Task.Run(() => DeliveryData.DeleteDelivery(addedDelivery.Id));
            }
        }

        [Fact, Order(5)]
        public async void DeleteDeliveryTest()
        {
            DeliveryModel newDelivery = new DeliveryModel(1, "1970-01-01");
            await Task.Run(() => DeliveryData.InsertDelivery(newDelivery));
            int id = await Task.Run(() => DeliveryData.GetMaxId());
            await Task.Run(() => DeliveryData.DeleteDelivery(id));
            DeliveryModel deletedDelivery = await Task.Run(() => DeliveryData.GetDelivery(id));

            Assert.Equal(-1, deletedDelivery.Id);
        }
    }
}

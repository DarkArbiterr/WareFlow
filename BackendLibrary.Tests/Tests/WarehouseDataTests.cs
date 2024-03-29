﻿using System;
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
    [Order(5)]
    public class WarehouseDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllWarehousesReturnNotNull()
        {
            var output = await Task.Run(() => WarehouseData.GetAllWarehouses());

            Assert.NotNull(output);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => WarehouseData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(3)]
        public async void GetWarehouseTest()
        {
            var output = await Task.Run(() => WarehouseData.GetWarehouse(-11));

            Assert.True(output.Id == -1);
        }

        [Fact, Order(4)]
        public async void InsertWarehouseTest()
        {
            WarehouseModel newWarehouse = new WarehouseModel(0, 0, "test_warehouse");
            await Task.Run(() => WarehouseData.InsertWarehouse(newWarehouse));
            WarehouseModel addedWarehouse = await Task.Run(() => WarehouseData.GetWarehouse(0));

            try
            {
                Assert.Equal(newWarehouse.Name, addedWarehouse.Name);
            }

            finally
            {
                await Task.Run(() => WarehouseData.DeleteWarehouse(addedWarehouse.Id));
            }
        }

        [Fact, Order(5)]
        public async void DeleteWarehouseTest()
        {
            WarehouseModel newWarehouse = new WarehouseModel(0, 0, "test_warehouse");
            await Task.Run(() => WarehouseData.InsertWarehouse(newWarehouse));
            await Task.Run(() => WarehouseData.DeleteWarehouse(0));
            WarehouseModel deletedWarehouse = await Task.Run(() => WarehouseData.GetWarehouse(0));

            Assert.Equal(-1, deletedWarehouse.Id);
        }
    }
}

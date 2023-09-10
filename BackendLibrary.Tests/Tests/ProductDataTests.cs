using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendLibrary.Models;
using BackendLibrary.DataAccess;
using Xunit;
using XUnitPriorityOrderer;
using Xunit.Abstractions;

namespace BackendLibrary.Tests.Tests
{
    [Order(3)]
    public class ProductDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllProductsReturnNotNull()
        {
            var output = await Task.Run(() => ProductData.GetAllProducts());

            Assert.NotNull(output);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => ProductData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(3)]
        public async void GetProductByIdTest()
        {
            var output = await Task.Run(() => ProductData.GetProductById(-2137));

            Assert.True(output.Id == -1);
        }

        [Fact, Order(4)]
        public async void GetProductByNameTest()
        {
            var output = await Task.Run(() => ProductData.GetProductByName("falszywa_nazwa_prodooktu"));

            Assert.True(output.Id == -1);
        }

        [Fact, Order(5)]
        public async void DeleteProductTest()
        {
            ProductModel newProduct = new ProductModel("falszyna_nazwa", "falszywy_opis");
            await Task.Run(() => ProductData.InsertProduct(newProduct));
            int id = await Task.Run(() => ProductData.GetMaxId());
            await Task.Run(() => ProductData.DeleteProduct(id));
            ProductModel deletedProduct = await Task.Run(() => ProductData.GetProductById(id));

            Assert.Null(deletedProduct.Name);
        }

        [Fact, Order(6)]
        public async void InsertProductTest()
        {
            ProductModel newProduct = new ProductModel("falszyna_nazwa", "falszywy_opis");
            await Task.Run(() => ProductData.InsertProduct(newProduct));
            ProductModel addedProduct = await Task.Run(() => ProductData.GetProductByName("falszyna_nazwa"));

            try
            {
                Assert.Equal(newProduct.Name, addedProduct.Name);
            }
            finally
            {
                await Task.Run(() => ProductData.DeleteProduct(addedProduct.Id));
            }
        }
    }
}

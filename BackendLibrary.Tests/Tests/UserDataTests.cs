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
    public class UserDataTests : BaseTestClass
    {
        [Fact, Order(1)]
        public async void GetAllUsersReturnNotNull()
        {
            var output = await Task.Run(() => UserData.GetAllUsers());

            Assert.NotNull(output);
        }

        [Fact, Order(2)]
        public async void GetMaxIdShouldReturnInt()
        {
            int id = await Task.Run(() => UserData.GetMaxId());

            Assert.IsType<Int32>(id);
        }

        [Fact, Order(3)]
        public async void GetUserTest()
        {
            var output = await Task.Run(() => UserData.GetUser("nieistniejacy email", "nieistniejace haslo"));

            Assert.True(output.IdStudent == -1);
        }

        [Fact, Order(4)]
        public async void AddUserTest()
        {
            UserModel newUser = new UserModel("imieI", "nazwiskoI", "emailI", "hasloI");
            await Task.Run(() => UserData.InsertUser(newUser));
            UserModel addedUser = await Task.Run(() => UserData.GetUser("emailI", "hasloI"));

            try
            {
                Assert.Equal(newUser, addedUser);
            }
            finally
            {
                await Task.Run(() => UserData.DeleteUser(addedUser.Id));
            }
        }

        [Fact, Order(5)]
        public async void DeleteUserTest()
        {
            UserModel newUser = new UserModel("imieD", "nazwiskoD", "emailD", "hasloD");
            await Task.Run(() => UserData.InsertUser(newUser));
            int id = await Task.Run(() => UserData.GetMaxId());
            await Task.Run(() => UserData.DeleteUser(id));
            UserModel deletedUser = await Task.Run(() => UserData.GetUser("emailD", "hasloD"));

            Assert.Null(deletedUser);
        }
    }
}

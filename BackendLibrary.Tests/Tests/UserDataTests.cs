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
            var output = await Task.Run(() => UserData.GetUser("false_name", "false_email"));

            Assert.True(output.UserId == -1);
        }
        
        [Fact, Order(4)]
        public async void InsertUserTest()
        {
            UserModel newUser = new UserModel("emailI", "hasloI", "imieI", "nazwiskoI");
            await Task.Run(() => UserData.InsertUser(newUser));
            UserModel addedUser = await Task.Run(() => UserData.GetUser("emailI", "hasloI"));

            try
            {
                Assert.Equal(newUser.Email, addedUser.Email);
            }
            finally
            {
                await Task.Run(() => UserData.DeleteUser(addedUser.UserId));
            }
        }
        
        [Fact, Order(5)]
        public async void DeleteUserTest()
        {
            UserModel newUser = new UserModel("emailD", "hasloD", "imieD", "nazwiskoD");
            await Task.Run(() => UserData.InsertUser(newUser));
            int id = await Task.Run(() => UserData.GetMaxId());
            await Task.Run(() => UserData.DeleteUser(id));
            UserModel deletedUser = await Task.Run(() => UserData.GetUser("emailD", "hasloD"));

            Assert.Null(deletedUser.Email);
        }
    }
}

﻿using DemoAPI.Data.Entities;
using DemoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Services.UserService
{
    public interface IUserService
    {
        List<User> GetUsers();
        User FindUserById(string id);
        bool InsertUser(User rq);
        bool DeleteUser(string id);

        bool UpdateUser(string userId, User rq);

       bool AddListUser(List<User> users);

        Task<ErrorResponse<string>> Import(IFormFile formFile);
        Task<FileStreamResult> Export();

        bool Verify(List<User> users);

    }
}

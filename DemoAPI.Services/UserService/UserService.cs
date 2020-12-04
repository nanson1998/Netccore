﻿using DemoAPI.Data.Entities;
using DemoAPI.Repository;
using DemoAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IImportExcel _importExcel;
        public UserService(IUserRepository userRepository, IImportExcel importExcel)
        {
            _importExcel = importExcel;
            _userRepository = userRepository;
        }
        public bool AddListUser(List<User> users)
        {
            var result = _userRepository.AddListUser(users);
            return true;
        }

        public bool DeleteUser(string id)
        {
            var result = _userRepository.DeleteUser(id);
            if (result == false)
            {
                return false;
            }
            return true;
        }

        public User FindUserById(string id)
        {
            var user = _userRepository.FindUserById(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public List<User> GetUsers()
        {
            var listUsers = _userRepository.GetUsers();
            return listUsers;
        }

        public bool InsertUser(User rq)
        {
            var result = _userRepository.InsertUser(rq);
            if (result == false)
            {
                return false;
            }
            return true;
        }


        public bool UpdateUser(string userId, User rq)
        {
            var result = _userRepository.UpdateUser(userId, rq);
            if (result == false)
            {
                return false;
            }
            return true;
        }

        public async Task<ErrorResponse<string>> Import(IFormFile formFile)
        {
            var listUsers = await _importExcel.Import(formFile);
            return listUsers;
        }
        public async Task<FileStreamResult> Export()
        {
            var listUsers = await _importExcel.Export();
            return listUsers;
        }

        public bool Verify(List<User> users)
        {
            var d = 0;
            foreach (var item in users)// 11
            {
                //if (!string.IsNullOrEmpty(item.Errors))
                //{
                //    d++;
                //} 
               
            }
            if (d != 0)
            {
                return false;
            }
            return true;
        }
    }
}

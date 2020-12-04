using DemoAPI.Data.Entities;
using DemoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.ApiModel
{
    public class ApiResponse
    {
        public int code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public ErrorResponse<string> result { get; set; }
        public List<User> listUser { get; set; }

        public ApiResponse(int code, ErrorResponse<string> result)
        {
            this.code = code;
            this.success = code == 200 ? true : false;
            this.message = GetDefaultMessageForStatusCode(code);
            this.result = result;
        }

        public ApiResponse(int code, string message)
        {
            this.code = code;
            this.success = code == 200 ? true : false;
            this.message = message ?? GetDefaultMessageForStatusCode(code);
            this.result = null;
        }
        public ApiResponse(int code, string message, List<User> listUser)
        {
            this.code = code;
            this.success = code == 200 ? true : false;
            this.message = message ?? GetDefaultMessageForStatusCode(code);
            this.listUser = listUser;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "OK";
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }

    
    }
}

﻿using DemoAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public static class MyAppExtensions
    {
        // Mở rộng cho IApplicationBuilder phương thức UseCheckAccess
        public static IApplicationBuilder UseResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models.Requests
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Domain.Models
{
    public class UserLogin
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } =string.Empty;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.System.Users
{
    public class Uservm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
    }
}

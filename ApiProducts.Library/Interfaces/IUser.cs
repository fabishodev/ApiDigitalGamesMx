﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProducts.Library.Interfaces
{
    public interface IUser : IDisposable
    {
        List<Models.User> GetUsers();
        int InsertUser(string email, string password, string nombreCompleto, string rol);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
    public String username { get; set; }
    public String password { get; set; }

    public User(String username, String password)
    {
        this.username = username;
        this.password = password;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp4
{
    public class dbconnection:DbContext
    {
      public  DbSet<User> Users {  get; set; }
       public DbSet <Assignment> Assignment { get; set; } 

    }
}

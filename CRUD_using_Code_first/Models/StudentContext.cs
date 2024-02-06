using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD_using_Code_first.Models
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestAsm.Data
{
    public class TestAsmContext: DbContext
    {
        public TestAsmContext() : base("name=TestAsmContext")
        {

        }
        public System.Data.Entity.DbSet<TestAsm.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<TestAsm.Models.Product> Products { get; set; }
    }
}
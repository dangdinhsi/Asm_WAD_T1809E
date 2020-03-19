using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsm.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }
        // public DateTime DeletedAt { get; set; }
        public CategoryStatus Status { get; set; }
      //  public virtual List<Product> ListProduct { get; set; }

        public enum CategoryStatus
        {
            Deactive = 0,
            Active = 1,
            Deleted = -1
        }
    }
}
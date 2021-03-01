using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMS_Entity_Framework_DB_First_Approach.Models
{
    public class ProductMetaData
    {
        public int ProductId { get; set; }

        [Required, MaxLength(5, ErrorMessage ="Maximum Length is 5")]
        public string ProductName { get; set; }

        [Required, Range(0,1000)]
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
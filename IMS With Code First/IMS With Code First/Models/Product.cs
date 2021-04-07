﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS_With_Code_First.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductCategory { get; set; }
    }
}

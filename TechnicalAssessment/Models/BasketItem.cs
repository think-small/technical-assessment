﻿namespace TechnicalAssessment.Models
{
    public class BasketItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Cost { get; set; }
    }
}

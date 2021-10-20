using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalAssessment.Interfaces;

namespace TechnicalAssessment.Models
{
    public class Basket
    {
        private readonly ITaxService _taxService;
        public List<BasketItem> Items;
        public decimal TotalTax { get; private set; }
        public decimal GrandTotal { get; private set; }

        public Basket(ITaxService taxService, List<BasketItem> items)
        {
            _taxService = taxService;
            Items = items;
        }

        public void CalculateTotal()
        {
            foreach (var item in Items)
            {                
                item.Tax = _taxService.CalculateTaxesFor(item.Product) * item.Quantity;
                item.Cost = (item.Tax + item.Product.Price) * item.Quantity;
            }

            TotalTax = Items.Sum(i => i.Tax.Value);
            GrandTotal = Items.Sum(i => i.Cost.Value);
        }

        public void PrintReceipt()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Quantity} {(item.Product.IsImported ? "imported " : "")}{item.Product.Name} at {item.Cost}");
            }
            Console.WriteLine($"Sales Taxes: {TotalTax}");
            Console.WriteLine($"Total: {GrandTotal}");
            Console.WriteLine();
        }
    }
}

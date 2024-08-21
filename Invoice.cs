using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    public class Invoice
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalAmount { get; set; }
        public string PaymentOption { get; set; }
        public decimal Discount { get; set; }

        public Invoice(Customer customer, List<Product> products, decimal discount, string paymentOption)
        {
            Customer = customer;
            Products = products;
            Discount = discount;
            PaymentOption = paymentOption;
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var product in Products)
            {
                TotalAmount += product.Price * product.Quantity;
            }
            TotalAmount -= Discount;
        }

        public override string ToString()
        {
            string invoiceDetails = $"Customer: {Customer.Name}\n";
            invoiceDetails += $"Email: {Customer.Email}\n";
            invoiceDetails += $"Address: {Customer.Address}\n";
            invoiceDetails += $"Contact: {Customer.ContactNumber}\n";
            invoiceDetails += "Products:\n";
            foreach (var product in Products)
            {
                invoiceDetails += $"- {product.Name} ({product.Quantity} x {product.Price:C})\n";
            }
            invoiceDetails += $"Total Amount: {TotalAmount:C}\n";
            invoiceDetails += $"Payment Option: {PaymentOption}\n";
            return invoiceDetails;
        }

    }
}

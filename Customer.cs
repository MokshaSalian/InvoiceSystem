using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public Customer(string name, string email, string address, string contactNumber)
        {
            Name = name;
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
        }

    }
}

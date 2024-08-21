using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvoiceSystem
{
    public class CustomerRepository
    {

        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer) => customers.Add(customer);
        public void RemoveCustomer(string name) => customers.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public Customer GetCustomer(string name) => customers.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public List<Customer> GetAllCustomers() => new List<Customer>(customers);

    }
}

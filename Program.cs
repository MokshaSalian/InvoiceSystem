using InvoiceSystem;
using System;

namespace InvoicingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepo = new ProductRepository();
            var categoryRepo = new CategoryRepository();
             var customerRepo = new CustomerRepository();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Invoicing System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View By Product Name");
                Console.WriteLine("5. View Products");
                Console.WriteLine("6. Add Category");
                Console.WriteLine("7. Update Category");
                Console.WriteLine("8. Delete Category");
                Console.WriteLine("9. View By Category Name");
                Console.WriteLine("10. View Categories");
                Console.WriteLine("11. Add Customer");
                Console.WriteLine("12. Update Customer");
                Console.WriteLine("13. Delete Customer");
                Console.WriteLine("14. View By Customer Name");
                Console.WriteLine("15. View Customers");
                Console.WriteLine("16. Generate Invoice");
                Console.WriteLine("17. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct(productRepo, categoryRepo);
                        break;
                    case "2":
                        UpdateProduct(productRepo, categoryRepo);
                        break;
                    case "3":
                        DeleteProduct(productRepo);
                        break;
                    case "4":
                        ViewProductById(productRepo);
                        break;
                    case "5":
                        ViewProducts(productRepo);
                        break;
                    case "6":
                        AddCategory(categoryRepo);
                        break;
                    case "7":
                        UpdateCategory(categoryRepo);
                        break;
                    case "8":
                        DeleteCategory(categoryRepo);
                        break;
                    case "9":
                        ViewCategoryById(categoryRepo);
                        break;

                    case "10":
                        ViewCategories(categoryRepo);
                        break;
                    case "11":
                        AddCustomer(customerRepo);
                        break;
                    case "12":
                        UpdateCustomer(customerRepo);
                        break;
                    case "13":
                        DeleteCustomer(customerRepo);
                        break;
                    case "14":
                        ViewCustomerById(customerRepo);
                        break;

                    case "15":
                        ViewCustomers(customerRepo);
                        break;
                    case "16":
                        GenerateInvoice(productRepo, customerRepo);
                        break;
                    case "17":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddProduct(ProductRepository productRepo, CategoryRepository categoryRepo)
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();
            var category = categoryRepo.GetCategory(categoryName);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
               // return;
            }
            else
            {
                var product = new Product(name, description, price, quantity, category);
                productRepo.AddProduct(product);
                Console.WriteLine("Product added.");
            }
           
            Console.ReadKey();
        }

        static void UpdateProduct(ProductRepository productRepo, CategoryRepository categoryRepo)
        {
            Console.Write("Enter the product Name you want to update: ");
            string productName = Console.ReadLine();

            var product = productRepo.GetProduct(productName);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                //  return;
            }
            else
            {
                Console.Write("Enter new product name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    product.Name = newName;
                }

                Console.Write("Enter new description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    product.Description = newDescription;
                }

                Console.Write("Enter new price (leave blank to keep current): ");
                string newPriceInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPriceInput))
                {
                    product.Price = decimal.Parse(newPriceInput);
                }

                Console.Write("Enter new quantity (leave blank to keep current): ");
                string newQuantityInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(newQuantityInput))
                {
                    product.Quantity = int.Parse(newQuantityInput);
                }

                Console.Write("Enter new category name (leave blank to keep current): ");
                string newCategoryName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCategoryName))
                {
                    var newCategory = categoryRepo.GetCategory(newCategoryName);
                    if (newCategory == null)
                    {
                        Console.WriteLine("Category not found.");
                        return;
                    }
                    product.Category = newCategory;
                }

                Console.WriteLine("Product updated.");
            }

            
            Console.ReadKey();
        }

        static void DeleteProduct(ProductRepository productRepo)
        {
            Console.Write("Enter the  product name you want to delete: ");
            string productName = Console.ReadLine();

           
             productRepo.RemoveProduct(productName);
            Console.WriteLine("Product deleted.");
            Console.ReadKey();
        }
        static void ViewProductById(ProductRepository productRepo)
        {
            Console.Write("Enter the  product name you want to fetch: ");
            string productName = Console.ReadLine();


            var product= productRepo.GetProduct(productName);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
              //  return;
            }
            else
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}, Category: {product.Category.Name}");
            }
            
            Console.ReadKey();
        }

        static void ViewProducts(ProductRepository productRepo)
        {
            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}, Category: {product.Category.Name}");
            }
            Console.ReadKey();
        }

        static void AddCategory(CategoryRepository categoryRepo)
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            var category = new Category(name, description);
            categoryRepo.AddCategory(category);
            Console.WriteLine("Category added.");
            Console.ReadKey();
        }

        static void UpdateCategory(CategoryRepository categoryRepo)
        {
            Console.Write("Enter the category Name you want to update: ");
            string categoryName = Console.ReadLine();

            var category = categoryRepo.GetCategory(categoryName);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
               // return;
            }
            else
            {
                Console.Write("Enter new category name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    category.Name = newName;
                }

                Console.Write("Enter new description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    category.Description = newDescription;
                }


                Console.WriteLine("Category updated.");
            }
            
            Console.ReadKey();
        }

        static void DeleteCategory(CategoryRepository categoryRepo)
        {
            Console.Write("Enter the category name you want to delete: ");
            string categoryName = Console.ReadLine();


            categoryRepo.RemoveCategory(categoryName);
            Console.WriteLine("Category deleted.");
            Console.ReadKey();
        }
        static void ViewCategoryById(CategoryRepository categoryRepo)
        {
            Console.Write("Enter the  category name you want to fetch: ");
            string categoryName = Console.ReadLine();


            var category = categoryRepo.GetCategory(categoryName);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                //return;
            }
            else
            {
                Console.WriteLine($"Name: {category.Name}, Description: {category.Description}");
            }

           
            Console.ReadKey();
        }

        static void ViewCategories(CategoryRepository categoryRepo)
        {
            var categories = categoryRepo.GetAllCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"Name: {category.Name}, Description: {category.Description}");
            }
            Console.ReadKey();
        }

        static void AddCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter contact number: ");
            string contactNumber = Console.ReadLine();
            var customer = new Customer(name, email, address, contactNumber);
            customerRepo.AddCustomer(customer);
            Console.WriteLine("Customer added.");
            Console.ReadKey();
        }


        static void UpdateCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Enter the Customer Name you want to update: ");
            string cusomerName = Console.ReadLine();

            var customer = customerRepo.GetCustomer(cusomerName);
            if (customer == null)
            {
                Console.WriteLine("customer not found.");
                // return;
            }
            else
            {
                Console.Write("Enter new customer name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    customer.Name = newName;
                }

                Console.Write("Enter new Email (leave blank to keep current): ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEmail))
                {
                    customer.Email = newEmail;
                }

                Console.Write("Enter new Address (leave blank to keep current): ");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAddress))
                {
                    customer.Address = newAddress;
                }

                Console.Write("Enter new Contact Number (leave blank to keep current): ");
                string newContact = Console.ReadLine();
                if (!string.IsNullOrEmpty(newContact))
                {
                    customer.ContactNumber = newContact;
                }


                Console.WriteLine("Customer updated.");
            }

           
            Console.ReadKey();
        }

        static void DeleteCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Enter the customer name you want to delete: ");
            string customerName = Console.ReadLine();


            customerRepo.RemoveCustomer(customerName);
            Console.WriteLine("Customer deleted.");
            Console.ReadKey();
        }
        static void ViewCustomerById(CustomerRepository customerRepo)
        {
            Console.Write("Enter the  Customer name you want to fetch: ");
            string customerName = Console.ReadLine();


            var customer = customerRepo.GetCustomer(customerName);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                // return;
            }
            else
            {
                Console.WriteLine($"Name: {customer.Name}, Email: {customer.Email}, Address: {customer.Address}, Contact: {customer.ContactNumber}");
            }

            
            Console.ReadKey();
        }


        static void ViewCustomers(CustomerRepository customerRepo)
        {
            var customers = customerRepo.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.Name}, Email: {customer.Email}, Address: {customer.Address}, Contact: {customer.ContactNumber}");
            }
            Console.ReadKey();
        }


        static void GenerateInvoice(ProductRepository productRepo, CustomerRepository customerRepo)
        {
            Console.Write("Enter customer email: ");
            string email = Console.ReadLine();
            var customer = customerRepo.GetCustomer(email);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            var products = new List<Product>();
            bool addingProducts = true;

            while (addingProducts)
            {
                Console.Write("Enter product name to add to cart: ");
                string productName = Console.ReadLine();
                var product = productRepo.GetProduct(productName);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                if (quantity > product.Quantity)
                {
                    Console.WriteLine("Insufficient quantity.");
                    continue;
                }

                var cartProduct = new Product(product.Name, product.Description, product.Price, quantity, product.Category);
                products.Add(cartProduct);
                product.Quantity -= quantity;

                Console.Write("Add another product? (y/n): ");
                addingProducts = Console.ReadLine().ToLower() == "y";
            }

            Console.Write("Enter discount amount: ");
            decimal discount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter payment option: ");
            string paymentOption = Console.ReadLine();

            var invoice = new Invoice(customer, products, discount, paymentOption);
            Console.WriteLine("Invoice Generated:");
            Console.WriteLine(invoice.ToString());
            Console.ReadKey();
        }
    }
}
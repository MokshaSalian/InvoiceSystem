using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    public class CategoryRepository
    {
        private List<Category> categories = new List<Category>();

        public void AddCategory(Category category) => categories.Add(category);
        public void RemoveCategory(string name) => categories.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public Category GetCategory(string name) => categories.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public List<Category> GetAllCategories() => new List<Category>(categories);

    }
}

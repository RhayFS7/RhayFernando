
using Persistence.DAL.Tables;
using RhayFernando.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tables
{
    public class CategoryServices
    {
        private CategoryDAL categoryDAL = new CategoryDAL();
        public IQueryable<Category> GetByName()
        {
            return categoryDAL.GetOrderbyName();
        }


        public Category GetByID(long? id)
        {
            return categoryDAL.GetOrderById(id);
        }

        public IQueryable<Category> GetCategoriesClassifiedByName()

        {

            return categoryDAL.GetCategoriesClassifiedByName();

        }



        public Category GetCategoryById(long id)
        {
            return categoryDAL.GetCategoryById(id);
        }

        public void SaveCategory(Category category)
        {
            categoryDAL.SaveCategory(category);
        }

        public Category RemoveCategoryById(long id)
        {
            return categoryDAL.RemoveCategorytBy(id);
        }
    }
}

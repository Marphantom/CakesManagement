using CakesManagement.Contexts;
using CakesManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CakesManagementDBContext context;

        public CategoryService(CakesManagementDBContext context)
        {
            this.context = context;
        }

        public Category Get(int CategoryId)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        }

        public List<Category> Gets()
        {
            return context.Categories.Include(c => c.Cakes).ToList();
        }
    }
}

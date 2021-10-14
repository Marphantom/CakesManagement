using CakesManagement.Contexts;
using CakesManagement.Entities;
using CakesManagement.Models.CakeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Services
{
    public class CakeService : ICakeService
    {
        private readonly CakesManagementDBContext context;

        public CakeService(CakesManagementDBContext context)
        {
            this.context = context;
        }

        public bool Create(Cakes model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Edit model)
        {
            try
            {
                var cakes = Get(model.CakeId);
                cakes.CategoryId = model.CategoryId;
                cakes.CakeName = model.CakeName;
                cakes.Intingredient = model.Intingredient;
                cakes.Expiry = model.Expiry;
                cakes.DateOfManufacture = model.DateOfManufacture;
                cakes.Price = model.Price;
                cakes.Delete = model.Delete;
                cakes.CakeId = model.CakeId;
                context.Attach(cakes);
                context.Entry(cakes).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cakes Get(int cakeId)
        {
            return context.Cakes.Include(p => p.Category).FirstOrDefault(p => p.CakeId == cakeId);
        }

        public List<Cakes> GetProductByCategoryId(int categoryId)
        {
            return context.Cakes.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool Remove(int cakeId)
        {
            try
            {
                var cakes = Get(cakeId);
                cakes.Delete = "hết hàng";
                context.Attach(cakes);
                context.Entry(cakes).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

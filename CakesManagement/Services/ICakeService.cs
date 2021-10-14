using CakesManagement.Entities;
using CakesManagement.Models.CakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Services
{
    public interface ICakeService
    {
        List<Cakes> GetProductByCategoryId(int categoryId);
        Cakes Get(int cakeId);
        bool Create(Cakes model);
        bool Edit(Edit model);
        bool Remove(int caketId);
    }
}

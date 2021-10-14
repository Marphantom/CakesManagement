using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Models.CakeModel
{
    public class Create
    {
        [Required]
        public string CakeName { get; set; }
        [Required]
        public string Intingredient { get; set; }
        [Required]
        public string Expiry { get; set; }
        [Required]
        public DateTime DateOfManufacture { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Delete { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}

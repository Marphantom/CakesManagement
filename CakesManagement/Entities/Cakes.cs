using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Entities
{
    public class Cakes
    {
        [Key]
        public int CakeId { get; set; }
        [Required]
        [StringLength(300)]
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
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

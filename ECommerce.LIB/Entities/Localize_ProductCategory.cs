using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.Entities
{
    [Table("Localize_ProductCategory")]
    public class Localize_ProductCategory
    {

        [Column("category ID")]
        public int Category_ID { get; set; }

        [Column("language ID")]
        public int Language_ID { get; set; }

        [Column("Category name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string CategoryName { get; set; }

        [Column("descr")]
        public string CategoryDescription { get; set; }


    }
}

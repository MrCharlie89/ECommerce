using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.Entities
{
    [Table("Product_Images")]
    public class ProductImages
    {
        [Key]
        [Column("image_ID")]
        public int ImageID { get; set; }

        [Column("product_ID")]
        public int ProductID { get; set; }

        [Column("order")]
        public int ImageOrder { get; set; }

        [Column("image_URL")]
        public string ImageURL { get; set; }

        public Product Product { get; set; }

        [NotMapped]
        public string FileLocation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.Entities
{
    [Table("product_categories")]
    public class ProductCategory : BaseEntity<int>
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual ProductCategory Parent { get; set; }

        public virtual ICollection<ProductCategory> Children { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            Children = new List<ProductCategory>();
            Products = new List<Product>();
        }

        public override bool IsNew()
        {
            return this.Id == 0;
        }

        public virtual ICollection<Localize_ProductCategory> Localize_ProductCategories { get; set; }

    }
}

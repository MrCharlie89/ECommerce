using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.Views
{
    [Table("dbo.vProductOverview")]
    public class ProductOverView
    {
        [Key]
        [Column("view_id")]
        public Guid ViewID { get; set; }

        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("unit_price")]
        public Decimal UnitPrice { get; set; }

        [Column("current_stock")]
        public int CurrentStock { get; set; }

        [Column("name")]
        public string ProductName { get; set; }

        [Column("descr")]
        public string ProductDescription { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("iso")]
        public string LanguageISO { get; set; }
    }
}

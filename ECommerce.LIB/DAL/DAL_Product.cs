using Syntra.VDOAP.CProef.ECommerce.LIB.DATA;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.DAL
{
    public static class DAL_Product
    {
        public static void Create(Product model,Localize_Product localize_model)
        {
            var ctx = AppDBContext.Instance();

            //model.Category_ID = 1;

            ctx.Products.Add(model);

            localize_model.Product_ID = model.Id;
            ctx.localize_Products.Add(localize_model);
            ctx.SaveChanges();
        }

        public static void Update(Product model,Localize_Product localize_model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<Product> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Products.Where(p => p.DeletedAt == null).ToList();
        }
    }
}
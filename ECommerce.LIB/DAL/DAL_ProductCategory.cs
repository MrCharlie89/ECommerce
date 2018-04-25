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
    public static class DAL_ProductCategory
    {
        public static void Create(ProductCategory model, Localize_ProductCategory localize_model)
        {
            var ctx = AppDBContext.Instance();

            ctx.ProductCategories.Add(model);

            localize_model.Category_ID = model.Id;
            ctx.localize_ProductCategories.Add(localize_model);
            ctx.SaveChanges();
        }

        public static List<ProductCategory> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Where(pc => pc.DeletedAt == null).ToList();
        }

        //public static List<ProductCategory> GetAll(int? parentId, int excludeId = 0)
        //{
        //    var ctx = AppDBContext.Instance();

        //    return ctx.ProductCategories
        //                .Where(pc => pc.DeletedAt == null && pc.ParentId == parentId && pc.Id != excludeId)
        //                .OrderBy(pc => pc.Name)
        //                .ToList();
        //}
        public static void Update(ProductCategory model, Localize_ProductCategory localize_model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }


    }
}

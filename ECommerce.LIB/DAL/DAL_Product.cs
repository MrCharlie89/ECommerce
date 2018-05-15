using Syntra.VDOAP.CProef.ECommerce.LIB.DATA;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using Syntra.VDOAP.CProef.ECommerce.LIB.Views;
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
        public static void Create(Product model, int EnglishLanguageID)
        {
            var ctx = AppDBContext.Instance();
            using (var ctxTransaction = ctx.Database.BeginTransaction())
                try
                {
                    ctx.Products.Add(model);
                    ctx.SaveChanges();

                    foreach (ProductImages image in model.Images)
                    {
                        image.ProductID = model.Id;
                        image.ImageURL = DAL_ProductImages.UploadImage(image, 
                            model.Localize_Product.SingleOrDefault(lp => lp.Language_ID == EnglishLanguageID).ProductName);
                    }
                    ctx.SaveChanges();
                    ctxTransaction.Commit();

                }
                catch (Exception)
                {

                    ctxTransaction.Rollback();
                    throw;
                }

            //model.Category_ID = 1;


        }

        public static void Update(Product model)
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

        public static List<ProductOverView> GetAllOverView()
        {
            var ctx = AppDBContext.Instance();

            return ctx.vProductOverView.ToList();
        }

        public static Product GetProduct(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Products.SingleOrDefault(p => p.Id == productID && p.DeletedAt == null);
        }
    }
}
using Syntra.VDOAP.CProef.ECommerce.LIB.DAL;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using Syntra.VDOAP.CProef.ECommerce.LIB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.BL
{
    public static class BL_Product
    {

        public static bool Save(Product Model, int EnglishLanguageID)
        {
            try
            {

                if (Model.IsNew())
                {
                    Create(Model, EnglishLanguageID);
                }
                else
                {
                    Update(Model);
                }
            }
            catch (Exception)
            {

                throw;
            }
           return true;
        }

        public static void Create(Product model, int EnglishLanguageID)
        {

            try
            {
                DAL_Product.Create(model, EnglishLanguageID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void Update(Product model)
        {
            try
            {
                DAL_Product.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ProductOverView> GetAllOverView()
        {
            try
            {
                return DAL_Product.GetAllOverView();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Product GetProduct(int productID)
        {
            return DAL_Product.GetProduct(productID);
        }

        public static List<Product> GetAll()
        {
            try
            {
                return DAL_Product.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(Product model)
        {
            try
            {
                model.DeletedAt = DateTime.Now;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


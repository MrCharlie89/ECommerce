using Syntra.VDOAP.CProef.ECommerce.LIB.DAL;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.BL
{
    public static class BL_Product
    {

        public static bool Save(Product Model,Localize_Product Localize_Model)
        {
            try
            {

                if (Model.IsNew())
                {
                    Create(Model,Localize_Model);
                }
                else
                {
                    Update(Model,Localize_Model);
                }
            }
            catch (Exception)
            {

                throw;
            }
           return true;
        }
        public static void Create(Product model,Localize_Product localize_model)
        {

            try
            {
                DAL_Product.Create(model,localize_model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void Update(Product model,Localize_Product localize_model)
        {
            try
            {
                DAL_Product.Update(model,localize_model);
            }
            catch (Exception)
            {

                throw;
            }
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


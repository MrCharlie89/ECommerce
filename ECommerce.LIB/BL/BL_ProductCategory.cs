using Syntra.VDOAP.CProef.ECommerce.LIB.DAL;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.BL
{
    public static class BL_ProductCategory
    {
        public static bool Save(ProductCategory Model)
        {
            try
            {
                if (Model.IsNew())
                {
                    Create(Model);
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

        private static void Create(ProductCategory model)
        {
            try
            {
                DAL_ProductCategory.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void Update(ProductCategory model)
        {
            try
            {
                DAL_ProductCategory.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ProductCategory> GetAll()
        {
            try
            {
                return DAL_ProductCategory.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(ProductCategory model)
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

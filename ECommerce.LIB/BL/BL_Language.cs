using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using Syntra.VDOAP.CProef.ECommerce.LIB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.BL
{
    public static class BL_Language
    {
        public static bool Save(Language Model)
        {
            try
            {
                if (Model.IsNew())
                {
                    Create(Model);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        private static void Create(Language model)
        {
            try
            {
                DAL_Language.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Language> GetAll()
        {
            try
            {
                return DAL_Language.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Language GetEnglishLanguages()
        {
            try
            {
                return DAL_Language.GetEnglishLanguages();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(Language model)
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

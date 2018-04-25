using Syntra.VDOAP.CProef.ECommerce.LIB.DATA;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.DAL
{
    public static class DAL_Language
    {
        public static void Create(Language model)
        {
            var ctx = AppDBContext.Instance();

            ctx.languages.Add(model);

            ctx.SaveChanges();
        }

        public static List<Language> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.languages.Where(lang => lang.DeletedAt == null).ToList();
        }
    }
}

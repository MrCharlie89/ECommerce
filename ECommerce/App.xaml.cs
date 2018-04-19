using Syntra.VDOAP.CProef.ECommerce.LIB.DATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Syntra.VDOAP.CProef.ECommerce
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        AppDBContext ctx = AppDBContext.Instance(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerce"].ConnectionString);

    }

}

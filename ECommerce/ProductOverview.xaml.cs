﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Syntra.VDOAP.CProef.ECommerce
{
    /// <summary>
    /// Interaction logic for ProductOverview.xaml
    /// </summary>
    public partial class ProductOverview : UserControl
    {
        public ProductOverview()
        {
            InitializeComponent();
        }

        private void dgrdProducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
    }
}

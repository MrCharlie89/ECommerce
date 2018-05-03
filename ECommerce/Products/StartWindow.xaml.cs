using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;

namespace Syntra.VDOAP.CProef.ECommerce.Products
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void ramiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StartWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to exit the application?", "Exit application", MessageBoxButton.YesNo) == MessageBoxResult.No;

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProductForm();
            form.OnModelSaved += OnProductSaved;
            Productcontent.Content = form;        
        }

        private void OnProductSaved(LIB.Entities.Product Model)
        {
            btnProductOverview_Click(btnProductOverview, null);
        }

        private void btnProductOverview_Click(object sender, RoutedEventArgs e)
        {
            var overview = new ProductOverview();
            //TODO: place here all the calls events of the overview


            Productcontent.Content = overview;
        }

        private void btnProductCategories_Click(object sender, RoutedEventArgs e)
        {
            Productcontent.Content = new CategoryForm();

        }

        private void btnProductCategoriesOverview_Click(object sender, RoutedEventArgs e)
        {
            Productcontent.Content = new CategoryOverview();
        }

        private void btnLanguageAdd_Click(object sender, RoutedEventArgs e)
        {
            Productcontent.Content = new LanguageForm();
        }

        private void btnLanguagesOverview_Click(object sender, RoutedEventArgs e)
        {
            Productcontent.Content = new LanguageOverview();
        }


    }
}

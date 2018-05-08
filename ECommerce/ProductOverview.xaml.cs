using Syntra.VDOAP.CProef.ECommerce.LIB.BL;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        private ObservableCollection<Product> datasource;

        private void BindData()
        {
            datasource = new ObservableCollection<Product>(BL_Product.GetAll());           
            
           // datasource.CollectionChanged += DataSourceChanged;
            dgrdProducts.ItemsSource = datasource;
            dgrdProducts.DataContext = datasource;

        }

        //private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    switch (e.Action)
        //    {
        //        case NotifyCollectionChangedAction.Add:
        //            foreach (Product m in e.NewItems)
        //                BL_Product.Save(m);
        //            break;

        //        case NotifyCollectionChangedAction.Remove:
        //            foreach (Product m in e.OldItems)
        //                BL_Product.Delete(m);
        //            break;
        //    }
        //}

        public ProductOverview()
        {
            InitializeComponent();

            BindData();

        }

        private void dgrdProducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            var model = ((FrameworkElement)sender).DataContext as Product;
            ProductDetail pd = new ProductDetail(model);
            pd.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Product;
            if (MessageBox.Show("Do you want to delete this product?", "Delete product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                datasource.Remove(obj);
            }
        }
    }
}

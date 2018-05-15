using Syntra.VDOAP.CProef.ECommerce.LIB.BL;
using Syntra.VDOAP.CProef.ECommerce.LIB.Entities;
using System;
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
using System.Windows.Shapes;

namespace Syntra.VDOAP.CProef.ECommerce
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        public Product Model { get; set; }

        public Localize_Product LocalizeProduct { get; set; }

        public ProductDetail(int productID)
        {
            InitializeComponent();
            Product model = BL_Product.GetProduct(productID);
            Model = model;
            int englishId = BL_Language.GetEnglishLanguages().Id;
            LocalizeProduct = model.Localize_Product.Single(lcp => lcp.Language_ID == englishId);

            this.DataContext = this;


        }

        //private void showDetails()
        //{
        //    txtProductName.Text = Localize_Model.ProductName;
        //    txtProductCategory.Text = Localize_Cat.CategoryName;
        //    txtProductDescription.Text = Localize_Model.Description;
        //    txtProductMaterial.Text = Localize_Model.Material;
        //    txtProductColor.Text = Localize_Model.Color;
        //    //txtProductPrice.Text = Model.UnitPrice.ToString;
        //    //txtProductStock.Text = Model.CurrentStock.ToString;
        //    txtProductBarcode.Text = Model.ProductCode;

        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

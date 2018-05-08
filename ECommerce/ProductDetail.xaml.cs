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
        public Localize_Product Localize_Model { get; set; }
        public Localize_ProductCategory Localize_Cat { get; set; }


        public ProductDetail() : this (new Product(),new Localize_Product(),new Localize_ProductCategory())
        {
            
        }

        public ProductDetail(Product model, Localize_Product localize_model, Localize_ProductCategory localize_cat)
        {
            InitializeComponent();
            this.Model = model;
            this.Localize_Model = localize_model;
            this.Localize_Cat = localize_cat;
            showDetails();
        }

        public ProductDetail(Product model)
        {
            Model = model;
        }

        private void showDetails()
        {
            txtProductName.Text = Localize_Model.ProductName;
            txtProductCategory.Text = Localize_Cat.CategoryName;
            txtProductDescription.Text = Localize_Model.Description;
            txtProductMaterial.Text = Localize_Model.Material;
            txtProductColor.Text = Localize_Model.Color;
            //txtProductPrice.Text = Model.UnitPrice.ToString;
            //txtProductStock.Text = Model.CurrentStock.ToString;
            txtProductBarcode.Text = Model.ProductCode;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

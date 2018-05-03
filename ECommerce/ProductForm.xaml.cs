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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Syntra.VDOAP.CProef.ECommerce
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : UserControl
    {        
        bool validating;

        public delegate void ModelSavedEventHandler(Product Model);
        public event ModelSavedEventHandler OnModelSaved;

        public Product Model { get; set; }
        public Localize_Product Localize_Model { get; set; }

        public ProductForm() : this(new Product(), new Localize_Product()) { }

        public ProductForm(Product model, Localize_Product localize_model)
        {
            InitializeComponent();

            this.Model = model;
            this.Localize_Model = localize_model;

            grdProductForm.DataContext = this;
            setTitle();
        }
       

        private void setTitle()
        {
            if (Model.IsNew())
            {
                Title.Content = "New product";
            }
            else Title.Content = "Edit product";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Verifying();
            if (validating == true)
            {
                if (BL_Product.Save(Model,Localize_Model))
                {
                    if (OnModelSaved != null)
                    {
                        OnModelSaved(Model);
                    }
                }
            }
        }

        private void Verifying()
        {
            validating = true;
            errProductName.Content = errProductDescription.Content = errMaterial.Content = errColor.Content = errUnitPrice.Content = errCurrentStock.Content = errBarcode.Content = null;

            if (txtProductName.Text == "")
            {
                errProductName.Content = "the Product name can't be empty";
                validating = false;
            }
            if (txtProductDescription.Text == "")
            {
                errProductDescription.Content = "Please give a description for this product";
                validating = false;
            }
            if (txtProductMaterial.Text == "")
            {
                errMaterial.Content = "please give the material the product is made of";
                validating = false;
            }
            if (txtProductColor.Text == "")
            {
                errColor.Content = "please give the maincolor of the product";
                validating = false;
            }
            if (txtProductPrice.Text == "")
            {
                errUnitPrice.Content = "Please give the price for this product";
                validating = false;
            }
            if (txtProductPrice.Text == "0")
            {
                errUnitPrice.Content = "The unitprice can't be zero";
                validating = false;
            }
            if (txtProductStock.Text == "")
            {
                errCurrentStock.Content = "Please give the current stock of this product";
                validating = false;
            }
            if (txtProductBarcode.Text == "")
            {
                errBarcode.Content = "Please give the Barcode for this product";
                validating = false;
            }
            if (txtProductStock.Text == "0")
            {
                checkProductIsActive.IsChecked = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "Cancel" , MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}

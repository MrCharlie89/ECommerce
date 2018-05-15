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
        public ProductForm(Product model)
        {
            InitializeComponent();

            this.Model = model;
            Model.Localize_Product = new List<Localize_Product>();
            Model.Images = new List<ProductImages>();

            grdProductForm.DataContext = this;
            setTitle();
            AddLocalizedTabs();


        }

        public ProductForm() : this(new Product()) { }

        bool validating;

        public delegate void ModelSavedEventHandler(Product Model);
        public event ModelSavedEventHandler OnModelSaved;

        public Product Model { get; set; }



        List<Language> LanguageList { get; set; }
        Image Image_To_Drag;

        /// <summary>
        /// adding dynamic tabs, labels and textboxes
        /// </summary>
        /// 
        public void AddLocalizedTabs()
        {
            TCLocalized.Items.Clear();

            LanguageList = BL_Language.GetAll();
            

            foreach (var langs in LanguageList)
            {

                Localize_Product locProd = new Localize_Product
                {
                    Language_ID = langs.Id
                };

                TabItem tabLocalized = new TabItem
                {
                    FontSize = 20,
                    Header = langs.LanguageName,
                    BorderThickness = new Thickness(1, 1, 1, 1),
                    Name = "TIProdLocalized" + langs.LanguageName

                };
                TCLocalized.Items.Add(tabLocalized);
                
                //ScrollViewer ScrollingTab = new ScrollViewer
                //{
                //    VerticalScrollBarVisibility = ScrollBarVisibility.Disabled
                //};

                WrapPanel Wrapper = new WrapPanel();

                StackPanel LabelStacker = new StackPanel
                {
                    Margin = new Thickness { Top = 7 },
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                StackPanel TextboxStacker = new StackPanel
                {
                    Margin = new Thickness { Top = 7 }
                };

                Label lblName = new Label
                {
                    Content = "Name: ",
                    Width = 250,
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                Label lblDescription = new Label
                {
                    Content = "Description: ",
                    Width = 250,
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 25, 0, 5)
                };

                Label lblMaterial = new Label
                {
                    Content = "Material: ",
                    Width = 250,
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 46, 0, 5)
                };

                Label lblColor = new Label
                {
                    Content = "Color: ",
                    Width = 250,
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 6, 0, 5)
                };

                TextBox txtName = new TextBox
                {
                    Width = 250,
                    Height = 40,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Binding bindingName = new Binding("ProductName")
                {
                    Source = locProd
                };
                txtName.SetBinding(TextBox.TextProperty, bindingName);

                TextBox txtDescription = new TextBox
                {
                    Width = 250,
                    Height = 90,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    BorderThickness = new Thickness(1, 1, 1, 1),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Binding bindingDescription = new Binding("Description")
                {
                    Source = locProd
                };
                txtDescription.SetBinding(TextBox.TextProperty, bindingDescription);

                TextBox txtMaterial = new TextBox
                {
                    Width = 250,
                    Height = 40,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Binding bindingMaterial = new Binding("Material")
                {
                    Source = locProd
                };
                txtMaterial.SetBinding(TextBox.TextProperty, bindingMaterial);

                TextBox txtColor = new TextBox
                {
                    Width = 250,
                    Height = 40,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Binding bindingColor = new Binding("Color")
                {
                    Source = locProd
                };
                txtColor.SetBinding(TextBox.TextProperty, bindingColor);

                Model.Localize_Product.Add(locProd);


                LabelStacker.Children.Add(lblName);
                LabelStacker.Children.Add(lblDescription);
                LabelStacker.Children.Add(lblMaterial);
                LabelStacker.Children.Add(lblColor);

                TextboxStacker.Children.Add(txtName);
                TextboxStacker.Children.Add(txtDescription);
                TextboxStacker.Children.Add(txtMaterial);
                TextboxStacker.Children.Add(txtColor);

                Wrapper.Children.Add(LabelStacker);
                Wrapper.Children.Add(TextboxStacker);

                //ScrollingTab.Content = Wrapper;

                //tabLocalized.Content = ScrollingTab;
                tabLocalized.Content = Wrapper;

            }
        }

        private int ImgCounter = 0;
        private const int DefaultWidth = 150;
        private const int DefaultHeight = 150;
        private const int FirstImageWidth = 200;
        private const int FirstImageHeight = 200;

        private void AddImage(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "image File (*.jpg; *.png)| *.jpg; *.png"
                };

                Nullable<bool> result = fileDialog.ShowDialog();

                if (result == true)
                {
                    string filename = fileDialog.FileName;

                    Image img = new Image
                    {
                        Source = new BitmapImage(new Uri(filename)),
                        Width = ImgCounter != 0 ? DefaultWidth : FirstImageWidth,
                        Height = ImgCounter != 0 ? DefaultHeight : FirstImageHeight,
                        AllowDrop = true,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    img.DragEnter += ImgDragEnter;
                    img.MouseLeftButtonDown += ImgMouseLeftButtonDown;

                    ProductImages imgItem = new ProductImages
                    {
                        FileLocation = filename,
                        ImageOrder = ImgCounter
                    };

                    Model.Images.Add(imgItem);

                    imgPanel.Children.Add(img);

                    ImgCounter += 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ImgMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image_To_Drag = (Image)e.Source;
            DragDrop.DoDragDrop(Image_To_Drag, Image_To_Drag, DragDropEffects.Move);
        }

        private void ImgDragEnter(object sender, DragEventArgs e)
        {
            Image Img = (Image)e.Source;
            int WhereToDrop = imgPanel.Children.IndexOf(Img);
            int StartLocation = imgPanel.Children.IndexOf(Image_To_Drag);

            imgPanel.Children.Remove(Image_To_Drag);
            imgPanel.Children.Insert(WhereToDrop, Image_To_Drag);

            foreach (var item in imgPanel.Children)
            {
                Image image = item as Image;

                image.Height = imgPanel.Children.IndexOf(image) != 0 ? DefaultHeight : FirstImageHeight;
                image.Width = imgPanel.Children.IndexOf(image) != 0 ? DefaultWidth : FirstImageWidth;
            }

            ProductImages temporary = Model.Images.Single(x => x.ImageOrder == StartLocation);
            ProductImages temporary2 = Model.Images.Single(x => x.ImageOrder == WhereToDrop);

            temporary.ImageOrder = WhereToDrop;
            temporary2.ImageOrder = StartLocation;

            Model.Images = Model.Images.OrderBy(x => x.ImageOrder).ToList();
        }

        private void setTitle()
        {
            if (Model.IsNew())
            {
                Title.Content = "New product";
            }
            else Title.Content = "Edit product";
        }

        // TODO: adding validation to the textboxes
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BL_Product.Save(Model, LanguageList.SingleOrDefault(lang => lang.ISO == "eng").Id);
            if (MessageBox.Show("Product saved", "Product saved", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                this.Visibility = Visibility.Collapsed;
            }

        }


        // moet inside de btnSave_Click
        //Verifying();
        //if (validating == true)
        //{
        //    if (BL_Product.Save(Model,Localize_Model))
        //    {
        //        if (OnModelSaved != null)
        //        {
        //            OnModelSaved(Model);
        //        }
        //    }
        //}
        //}

        //private void Verifying()
        //{
        //    validating = true;
        //    errProductName.Content = errProductDescription.Content = errMaterial.Content = errColor.Content = errUnitPrice.Content = errCurrentStock.Content = errBarcode.Content = null;

        //    if (txtProductName.Text == "")
        //    {
        //        errProductName.Content = "the Product name can't be empty";
        //        validating = false;
        //    }
        //    if (txtProductDescription.Text == "")
        //    {
        //        errProductDescription.Content = "Please give a description for this product";
        //        validating = false;
        //    }
        //    if (txtProductMaterial.Text == "")
        //    {
        //        errMaterial.Content = "please give the material the product is made of";
        //        validating = false;
        //    }
        //    if (txtProductColor.Text == "")
        //    {
        //        errColor.Content = "please give the maincolor of the product";
        //        validating = false;
        //    }
        //    if (txtProductPrice.Text == "")
        //    {
        //        errUnitPrice.Content = "Please give the price for this product";
        //        validating = false;
        //    }
        //    if (txtProductPrice.Text == "0")
        //    {
        //        errUnitPrice.Content = "The unitprice can't be zero";
        //        validating = false;
        //    }
        //    if (txtProductStock.Text == "")
        //    {
        //        errCurrentStock.Content = "Please give the current stock of this product";
        //        validating = false;
        //    }
        //    if (txtProductBarcode.Text == "")
        //    {
        //        errBarcode.Content = "Please give the Barcode for this product";
        //        validating = false;
        //    }
        //    if (txtProductStock.Text == "0")
        //    {
        //        checkProductIsActive.IsChecked = false;
        //    }
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}

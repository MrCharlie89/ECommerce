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
    /// Interaction logic for CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : UserControl
    {
        public CategoryForm( ProductCategory model)
        {
            InitializeComponent();

            this.Model = model;

            usercontrolCategoryForm.DataContext = this;
            setTitle();
            AddLocalizedTabs();
        }

        public CategoryForm() : this(new ProductCategory()) { }

        public delegate void ModelSavedEventHandler(ProductCategory Model);
        public event ModelSavedEventHandler OnModelSaved;

        public ProductCategory Model { get; set; }

        List<Language> LanguageList { get; set; }

        /// <summary>
        /// adding dynamic tabs, textboxes and labels in different languages
        /// </summary>        
        public void AddLocalizedTabs()
        {
            TCLocalized.Items.Clear();

            LanguageList = BL_Language.GetAll();
            Model.Localize_ProductCategories = new List<Localize_ProductCategory>();

            foreach (var langs in LanguageList)
            {
                Localize_ProductCategory locCat = new Localize_ProductCategory
                {
                    Language_ID = langs.Id
                };

                TabItem tabLocalized = new TabItem
                {
                    FontSize = 20,
                    Header = langs.LanguageName,
                    Name = "TIProdCatLocalized" + langs.LanguageName
                };
                TCLocalized.Items.Add(tabLocalized);

                ScrollViewer ScrollingTab = new ScrollViewer
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto
                };

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
                    Content = "Category name",
                    Width = 250,
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                Label lblDescription = new Label
                {
                    Content = "Category description",
                    Width = 250,                    
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                TextBox txtName = new TextBox
                {
                    Width = 250,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Binding bindingName = new Binding("Name")
                {
                    Source = locCat
                };

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
                    Source = locCat
                };

                Model.Localize_ProductCategories.Add(locCat);

                LabelStacker.Children.Add(lblName);
                LabelStacker.Children.Add(lblDescription);

                TextboxStacker.Children.Add(txtName);
                TextboxStacker.Children.Add(txtDescription);

                Wrapper.Children.Add(LabelStacker);
                Wrapper.Children.Add(TextboxStacker);

                ScrollingTab.Content = Wrapper;

                tabLocalized.Content = ScrollingTab;

            }
        }


        public void setTitle()
        {
            if (Model.IsNew())
            {
                Title.Content = "New category";
            }
            else Title.Content = "Edit category";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

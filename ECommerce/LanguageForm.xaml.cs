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
    /// Interaction logic for LanguageForm.xaml
    /// </summary>
    public partial class LanguageForm : UserControl
    {
        bool validating;

        public delegate void ModelSavedEventHandler(Language Model);
        public event ModelSavedEventHandler OnModelSaved;

        public Language Model { get; set; }
        public LanguageForm() : this(new Language())
        { }

        public LanguageForm(Language model)
        {
            InitializeComponent();

            this.DataContext = this;
            this.Model = model;
            setTitle();
        }

        private void setTitle()
        {
            if (Model.IsNew())
            {
                Title.Content = "New language";
            }
            else Title.Content = "Edit Language";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Verifying();
            if (validating == true)
            {
                if (BL_Language.Save(Model))
                {
                    if (OnModelSaved != null)
                    {
                        OnModelSaved(Model);                       

                    }
                }
            }
            this.Visibility = Visibility.Collapsed;

        }

        private void Verifying()
        {
            validating = true;
            errLanguageName = errEnglishName = errISO = null;

            if (txtLanguageName.Text == "")
            {
                errLanguageName.Content = "Please give the local name of the language";
                validating = false;
            }
            if (txtLanguageEnglishName.Text == "")
            {
                errEnglishName.Content = "Please give the English name of the language";
                validating = false;
            }
            if (txtLanguageISO.Text == "")
            {
                errISO.Content = "Please give the ISO code of the language";
                validating = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Syntra.VDOAP.CProef.ECommerce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SetTitle(string label = null)
        {
            try
            {
                string _title = "";

                if (!string.IsNullOrWhiteSpace(label))
                {
                    _title += label + " - ";

                    this.Title = _title;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void SetTitleByRibbonButton(object sender)
        {
            try
            {
                SetTitle(((RibbonButton)sender).Label);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ramiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainScreen_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to exit the application?", "Exit application", MessageBoxButton.YesNo) == MessageBoxResult.No;

        }
        private void btnProductOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);

                testContent.Content = new ProductOverview();
               //  mainContent.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                throw;

            }
        }

        private void btnProductAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new ProductForm();
               // testContent.Visibility = Visibility.Collapsed;
               //  mainContent.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSupplierOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new SupplierOverview();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSupplierAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new SupplierForm();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCategoryOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new CategoryOverview();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCategoryAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new CategoryForm();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLanguageOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new LanguageOverview();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLanguageAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTitleByRibbonButton(sender);
                mainContent.Content = new LanguageForm();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

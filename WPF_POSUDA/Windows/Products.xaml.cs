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
using WPF_POSUDA.Models;

namespace WPF_POSUDA.Windows
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {

        public Products()
        {
            InitializeComponent();
            List<Models.Product> list = App.context.Products.ToList();
            Classes.Alldata.all = list.Count;
            LoadData();
        }
        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }
        public void LoadData() //обновление окна при каких-то изменениях
        {
            ProductView.Children.Clear();
            List<Models.Product> list = App.context.Products.ToList();
            if (Filtration.SelectedItem != null)
            {
                switch (Filtration.SelectedIndex)
                {
                    case 0:
                        list = App.context.Products.ToList();
                        break;
                    case 1:
                        list = list.Where(p => p.ProductDiscountAmount > 0 && p.ProductDiscountAmount < Convert.ToDecimal(9.99)).ToList();
                        break;
                    case 2:
                        list = list.Where(p => p.ProductDiscountAmount > 10 && p.ProductDiscountAmount < Convert.ToDecimal(14.99)).ToList();
                        break;
                    case 3:
                        list = list.Where(p => p.ProductDiscountAmount >= 15 && p.ProductDiscountAmount < 100).ToList();
                        break;
                }
            }
            if (Search.Text.Length != 0)
                list = list.Where(p => p.ProductName.Contains(Search.Text)).ToList();
            if (Asc.IsChecked == true)
                list = list.OrderBy(p => p.ProductCost).ToList();
            else if (Desc.IsChecked == true)
                list = list.OrderByDescending(p => p.ProductCost).ToList();

            foreach (var item in list)
                ProductView.Children.Add(new UserControls.ProductCard(item.ProductArticleNumber, item.ProductName, item.ProductDescription, item.ManufacturerId.ToString(), item.ProductCost.ToString(), item.ProductDiscountAmount.ToString(), Convert.ToDecimal(item.ProductDiscountAmount), item.ProductPhoto));
            All.Text = list.Count.ToString() + " из " + Classes.Alldata.all.ToString();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


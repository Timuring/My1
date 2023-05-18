using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_POSUDA.Models;

namespace WPF_POSUDA.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : UserControl
    {
        string Article;
        public ProductCard(string Atricle, string Title, string Description, string Manufacturer, string Cost, string Stock, decimal Sale, byte[] Img) //поля которые будут вызываться при использовании вызове
        {
            InitializeComponent();
            this.Article = Atricle; //артикул
            this.Title.Text = Title; //название
            this.Description.Text = Description; //описание
            Manufacturer manufacturers = App.context.Manufacturers.ToList().Find(m => m.ManufacturerId.ToString() == Manufacturer); //поиск производителя в бд
            this.Manufacturer.Text += manufacturers.ManufacturerName; //производитель
            this.Cost.Text += Cost.Split(',')[0] + " р."; //стоимость
            this.Stock.Text = Stock + "%"; //скидка
            if (Sale > 15)
                BackgroundSale.Background = SaleColor.Background;
            if (Sale > 0)
            {
                CostDiscount.Visibility = Visibility.Visible;
                this.Cost.TextDecorations = Strike.TextDecorations;
                CostDiscount.Text += (Convert.ToDecimal(Cost) - Convert.ToDecimal(Cost) * Sale / 100).ToString().Split(',')[0] + " р."; //рассчёт стоимости с учётом скидки
            }

            try //сжатие и показ картинки
            {
                BitmapImage img = new BitmapImage();
                MemoryStream MS = new MemoryStream(Img);
                img.BeginInit();
                img.StreamSource = MS;
                img.EndInit();
                this.Imgs.Source = img;
            }
            catch
            {
            }
        }
    }
}

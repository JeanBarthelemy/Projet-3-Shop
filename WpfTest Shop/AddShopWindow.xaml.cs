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
using Microsoft.EntityFrameworkCore;

namespace WpfTest_Shop
{
    /// <summary>
    /// Interaction logic for AddShopWindow.xaml
    /// </summary>
    public partial class AddShopWindow : Window
    {
        private readonly ShopContext shopContext;
        public AddShopWindow()
        {
            InitializeComponent();
            DataContext = shopContext;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopContext())
            {
                var addShop = new Shop()
                {
                    Name = ShopNameTxtBox.Text,
                    StreetNumber = StreetNumberTxtBox.Text,
                    StreetName = StreetNameTxtBox.Text,
                    ZipCode = ZipCodeTxtBox.Text
                };
                context.AddRange(addShop);
                context.SaveChanges();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

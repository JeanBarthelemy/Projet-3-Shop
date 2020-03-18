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
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ListViewItem = System.Windows.Controls.ListViewItem;

namespace WpfTest_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DbSet<Shop> _shops;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _shops;
            List<Shop> shopList = DisplayInformation.DisplayDefaultShop();
            ShopListView.ItemsSource = shopList;
            
        }

        private void Research_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManualSettingsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                ShopInfoWindow shopInfoWindow = new ShopInfoWindow();
                shopInfoWindow.Owner=this;
                shopInfoWindow.Show();
                 
            }
            
        }
    }
}

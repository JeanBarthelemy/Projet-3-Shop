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
        private readonly ShopContext shopContext;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = shopContext;
            List<Shop> shopList = DisplayInformation.DisplayDefaultShop();
            ShopListView.ItemsSource = shopList;        
            
        }

        private void Research_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (FilterNameComboBox.Text == "City" && DisplayInformation.GetCity().Contains(InfoFilterTextBox.Text))
            {
                List<Shop> shopFilterByCity = Filter.FilterByCity(InfoFilterTextBox.Text);
                ShopListView.ItemsSource = shopFilterByCity;
            }
            else if (FilterNameComboBox.Text == "County" && DisplayInformation.GetCounty().Contains(InfoFilterTextBox.Text))
            {
                List<Shop> shopFilterByCounty = Filter.FilterByCounty(InfoFilterTextBox.Text);
                ShopListView.ItemsSource = shopFilterByCounty;
            }
            else if (FilterNameComboBox.Text == "District" && DisplayInformation.GetDistrict().Contains(InfoFilterTextBox.Text))
            {
                List<Shop> shopFilterByDistrict = Filter.FilterByDistrict(InfoFilterTextBox.Text);
                ShopListView.ItemsSource = shopFilterByDistrict;
            }
            else if (FilterNameComboBox.Text == "Country" && DisplayInformation.GetCountry().Contains(InfoFilterTextBox.Text))
            {
                List<Shop> shopFilterByCountry = Filter.FilterByCountry(InfoFilterTextBox.Text);
                ShopListView.ItemsSource = shopFilterByCountry;
            }
            else
            {
                System.Windows.MessageBox.Show("You miswrote.");
            }
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {
            List<Shop> shopList = DisplayInformation.DisplayDefaultShop();
            ShopListView.ItemsSource = shopList;
            InfoFilterTextBox.Text = String.Empty;
        }

        private void ManualSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            ManualSettingsWindows manualSettingsWindow = new ManualSettingsWindows();
            manualSettingsWindow.Owner = this;
            manualSettingsWindow.Show();
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

        private void AddShop_btn_Click(object sender, RoutedEventArgs e)
        {
            AddShopWindow addShopWindow = new AddShopWindow();
            addShopWindow.Owner = this;
            addShopWindow.Show();
        }
    }
}

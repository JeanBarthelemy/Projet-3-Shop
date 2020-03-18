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
using System.Windows.Forms;

namespace WpfTest_Shop
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Person newPerson = new Person { Name = UserNameTextBox.Text, Password = Sha256Tools.GetHash(PasswordTextBox.Password) };
            if (Authentification.Authentify(newPerson) == true)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("The user doesn't exist or was miswritten", "User issue!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
}

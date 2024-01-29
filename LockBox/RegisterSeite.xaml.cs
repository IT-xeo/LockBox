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
using System.Xml.Linq;

namespace LockBox
{
    /// <summary>
    /// Interaction logic for RegisterSeite.xaml
    /// </summary>
    public partial class RegisterSeite : Window
    {
        private accounts accountManager;
        public RegisterSeite()
        {
            InitializeComponent();
            accountManager = new accounts();
        }

        private void Registrieren(object sender, RoutedEventArgs e)
        {

            if (xName.Text != "" && xMail.Text != "" && xPass.Password != "" && xPassConfirm.Password != "")
            {
                accountManager.LoadAccounts("C:\\Users\\kgora\\Desktop\\LockBox\\LockBox\\LockBox\\login.json");
                accountManager.AddAccount(new Account { Email = xMail.Text, Name = xName.Text, Password = xPass.Password });
                accountManager.SaveAccounts("C:\\Users\\kgora\\Desktop\\LockBox\\LockBox\\LockBox\\login.json");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                // Handle the case when any of the input fields is empty
            }
        }

        private void Anmelden(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}

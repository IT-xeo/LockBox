using Gu.Wpf.Adorners;
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
using LockBox.Properties;
using System.IO;

namespace LockBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private accounts accountManager;
        public MainWindow()
        {
            InitializeComponent();
            accountManager = new accounts();
            accountManager.LoadAccounts("C:\\Users\\kgora\\Desktop\\LockBox\\LockBox\\LockBox\\login.json");

        }

        private void Anmelden(object sender, RoutedEventArgs e)
        {

            if (xNameEmail.Text != "" && xPasswort.Password.ToString() != "")
            {
                List<Account> allAccounts = accountManager.GetAccounts();

                bool isLoginSuccessful = false;
                foreach (var account in allAccounts)
                {
                    if (account.Name == xNameEmail.Text || account.Email == xNameEmail.Text && account.Password == xPasswort.Password)
                    {
                        isLoginSuccessful = true;
                        break; // Exit the loop if a matching account is found
                    }
                }

                if (isLoginSuccessful)
                {
                    GruppenSeite gruppenSeite = new GruppenSeite();
                    gruppenSeite.Show();
                    Close();
                }
                else
                {
                    xLoginError.Visibility = Visibility.Visible;
                }
            }
        }



        private void Registrieren(object sender, RoutedEventArgs e)
        {
            RegisterSeite registerSeite = new RegisterSeite();
            registerSeite.Show();
            Close();
        }
    }
}

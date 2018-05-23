using Hotel.DataModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace WpfAppClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Autorisationn : MetroWindow
    {

        public Autorisationn()
        {
            InitializeComponent();       

        }


        private void butRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(); 
            var res = registration.ShowDialog(); //  вызов модального окна регистрации 
        }

        private async void butEntry_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.HotelServiceClient aut = new ServiceReference1.HotelServiceClient();// асинхронный обработчик провеки Логина и пароля
            try
            {
                Client_Tenant client = await aut.AutorisationnAsync(tbLog.Text.ToString(), pbPass.Password.ToString()); // вызываем метод проверки из сервера 
                if (client != null)
                {

                    ClientWindow mainWindows = new ClientWindow(client);
                    mainWindows.Show();            // Открываем следующее окно WPF       
                    mainWindows.Title = tbLog.Text.ToString();
                    this.Close();       
                                              
                    
                }
                else
                {
                    MessageBox.Show("Неврно введен Login или Password! Проверте правильность их написания...");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



    }

}

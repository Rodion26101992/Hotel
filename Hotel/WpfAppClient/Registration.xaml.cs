using MahApps.Metro.Controls;
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
using System.Text.RegularExpressions;
//using WpfAppClient.ServiceReference1;

namespace WpfAppClient
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : MetroWindow
    {
        public Registration()
        {
            InitializeComponent();

        }
        private void butReg_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.HotelServiceClient proxy = new ServiceReference1.HotelServiceClient();
            Regex regex_phone = new Regex(@"((\+38|8)[ ]?)?([(]?\d{3}[)]?[\- ]?)?[\d\-]{6,14}");
           
            string pas_sha = this.pwbPassw.Password.ToString();
            string pas_test = this.pwbPassTest.Password.ToString(); 
            // проверка пароля и его подтверждение , проверка на пустые поля 
            if (pas_sha == pas_test && !string.IsNullOrWhiteSpace(tbPhone.Text.Trim()) && !string.IsNullOrWhiteSpace(pwbPassw.Password.Trim())&& !string.IsNullOrWhiteSpace(tbEmail.Text.Trim())&& !string.IsNullOrWhiteSpace(tbLastName.Text.Trim()) && !string.IsNullOrWhiteSpace(tbFirstName.Text.Trim()))
            {
                try
                {
                    proxy.AddClient(tbPhone.Text.ToString(), pwbPassw.Password.ToString(), tbEmail.Text.ToString(), "В еде не нуждаюсь", tbLastName.Text.ToString(), tbFirstName.Text.ToString());
                    this.Close();
                    MessageBox.Show("Регистрация прошла успешно! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Не правельное подтверждение пароля или не все поля были заполнены, попробуйте еще раз!");
                // очищаем поля паролей для повторного подтверждения так как они небыли коректно введены 
                pwbPassTest.Clear();
                pwbPassw.Clear();
            }




        }



    }

}

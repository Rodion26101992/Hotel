using Hotel.DataModel;
using Hotel.DataModel.Room;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using WpfAppClient.ServiceReference1;

namespace WpfAppClient
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class ClientWindow : MetroWindow
    {
        Client_Tenant _client = new Client_Tenant();
        HotelServiceClient _proxy = new HotelServiceClient();
        ObservableCollection<Room_Table> _rooms = new ObservableCollection<Room_Table>();

        string _dateBegin = null;
        string _dateEnd = null;
        string _radioBut = null;
        string _check = null;
        public ClientWindow(Client_Tenant client)
        {

            InitializeComponent();
            this.Closed += (s, e) => Application.Current.Shutdown();   //завершение приложения после закрытия программы      

            GetRooms();// лучаем список всех комнат 


        }



        private void butOrder_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            dockPanel.Visibility = Visibility.Collapsed; // скрываем видимость 
            grid.DataContext = ListBox1.SelectedItem;// выбраный элемен 
        }

        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            dockPanel.Visibility = Visibility.Visible;
        }

        private async void GetRooms()
        {
            var rooms = await _proxy.GetRoomAsync(); //асинхрое получение списка комнат 

            _rooms = new ObservableCollection<Room_Table>(rooms);
            ListBox1.ItemsSource = _rooms; // добавление комнат в лист
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            butShow.IsEnabled = ListBox1.SelectedItem != null; // скрываем кнопку

        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            if (dpicBegin.SelectedDate >= DateTime.Today)
            {

                if (dpicEnd.SelectedDate > dpicBegin.SelectedDate)
                {                
                    Time_Rooms();
                }
                else
                {

                    MessageBox.Show("Дата выезда не должна быть меньше начала даты заезда! Проверте свой заказ...");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Дата заезда не должна быть меньше нынешней! Проверте свой заказ...");
                return;
                //  dpicBegin.ClearValue();
            }


        }

        private async void Time_Rooms()
        {
            var rooms = await _proxy.Time_GetRoomAsync(dpicBegin.SelectedDate.Value, dpicEnd.SelectedDate.Value); //асинхрое получение списка комнат 
      
            _rooms = new ObservableCollection<Room_Table>(rooms);
            ListBox1.ItemsSource = _rooms; // добавление комнат в лист
        }

        private void butOr_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox check in docCheck.Children)
            {
                if (check.IsChecked == true)
                {
                    _check += check.Content.ToString() + " ,";
                }
            }
            if (dpicBegin1.SelectedDate >= DateTime.Today)
            {
                _dateBegin = dpicBegin1.SelectedDate.Value.ToShortDateString();

            }
            else
            {
                MessageBox.Show("Дата заезда не должна быть меньше нынешней! Проверте свой заказ...");
                return;
                //  dpicBegin.ClearValue();
            }

            if (dpicEnd1.SelectedDate > dpicBegin1.SelectedDate)
            {
                _dateEnd = dpicEnd1.SelectedDate.Value.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Дата выезда не должна быть меньше начала даты заезда! Проверте свой заказ...");
                return;
            }
            string order = "Количество человек: " + ComboBoxCol.Text.ToString() + "; Еда: "
          + _radioBut + "; " + _check + " Заезд от : " + _dateBegin + " до " + _dateEnd;
            MessageBox.Show(order);

        //    добавить еще от кого заказ(авторизация логин)
            MailAddress from = new MailAddress("hotelthebest2018@gmail.com", "User", Encoding.ASCII);
            MailAddress to = new MailAddress("hotelthebest2018@gmail.com");// аддрес получателя 
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Заказ комнаты абонента: " + this.Title.ToString();
            message.Body = order;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("hotelthebest2018@gmail.com", "Hotel123");
            client.Send(message);

            _proxy.addTime_Room(dpicBegin1.SelectedDate.Value, dpicEnd1.SelectedDate.Value, ((Room_Table)ListBox1.SelectedItem).Room_TableId);
            order = null;
            _check = null;
        }

        private void rbFoodFull_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            _radioBut = pressed.Content.ToString();
        }
        private void rbFoodBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            _radioBut = pressed.Content.ToString();

        }
        private void rbNoFoodt_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            _radioBut = pressed.Content.ToString();

        }
    }
}

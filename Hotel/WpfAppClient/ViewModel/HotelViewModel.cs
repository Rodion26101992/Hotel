using Hotel.DataModel.Room;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppClient.ServiceReference1;

namespace WpfAppClient.ViewModel
{
    class HotelViewModel : INotifyPropertyChanged
    {
        ServiceReference1.HotelServiceClient _proxy = new HotelServiceClient();
        ObservableCollection<Room_Table> _rooms = new ObservableCollection<Room_Table>();

        private Room_Table _selectedRoom;

        public ObservableCollection<Room_Table> Rooms
        {
            get
            {
                return _rooms;
            }

            set
            {
                if (_rooms != value)
                {
                    _rooms = value;
                    OnPropertyChanged("Rooms");
                }
            }
        }

        public Room_Table SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }

            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    OnPropertyChanged("SelectedRoom");
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

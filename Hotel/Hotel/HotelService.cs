using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hotel.DataModel;
using Hotel.DataModel.Room;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Hotel
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "HotelService" в коде и файле конфигурации.
    public class HotelService : IHotelService
    {
        public ClientContext context { get; set; }

        public void AddClient(string mobile_, string pass_, string email_, string food_, string lastName_, string firstName_)
        {
            //Добавление клиента в БД 
            using (context = new ClientContext())
            {
                Mobile_Table mobile = new Mobile_Table();
                mobile.Nuber = mobile_;
                context.Mobiles.Add(mobile);
                context.SaveChanges();

                Password_Table pass = new Password_Table();
                byte[] data = Encoding.Default.GetBytes(pass_);
                var result = new SHA256Managed().ComputeHash(data);
                pass.Pass = Encoding.Default.GetString(result);
                context.Passwords.Add(pass);
                context.SaveChanges();


                Email_Table Email = new Email_Table();
                Email.Info_Email = email_;
                context.Emails.Add(Email);
                context.SaveChanges();


                Car_Table Car = new Car_Table();
                Car.Info_Car = true;
                context.Cars.Add(Car);
                context.SaveChanges();

                Food_Table food = new Food_Table();
                food.Info_Food = food_;
                context.Foods.Add(food);
                context.SaveChanges();

                Client_Tenant Client_Tenant = new Client_Tenant();
                Client_Tenant.LastName = lastName_;
                Client_Tenant.FirstName = firstName_;

                Client_Tenant.Mobile = mobile;
                Client_Tenant.Car = Car;
                Client_Tenant.Email = Email;
                Client_Tenant.Food = food;
                Client_Tenant.Passw = pass;
                context.Client_Tenants.Add(Client_Tenant);
                context.SaveChanges();
            }

        }

        public void addTime_Room(DateTime begin, DateTime end, int number)
        {
            using (context = new ClientContext())
            {
                Time_Arrival Time_Arrival = new Time_Arrival();
                Time_Arrival.Room_ID = number;
                Time_Arrival.Time_Arri_begin = begin;
                Time_Arrival.Time_Arri_end = end;
                context.Time_Ar.Add(Time_Arrival);
                context.SaveChanges();
            }

        }

        public Client_Tenant Autorisationn(string login, string passw)
        {

            using (context = new ClientContext())
            {
                //проверка логина и пароля с БД
                byte[] data = Encoding.Default.GetBytes(passw);
                var result = new SHA256Managed().ComputeHash(data);
                passw = Encoding.Default.GetString(result);
                return context.Client_Tenants.FirstOrDefault(m => m.Mobile.Nuber == login && m.Passw.Pass == passw);

            }

        }

        public List<Room_Table> GetRoom()
        {
            // Получение спика комнат  в БД
            using (context = new ClientContext())
            {
                return context.Rooms.ToList();
            }

        }
        public List<Room_Table> Time_GetRoom(DateTime begin, DateTime end)
        {
            // Получение комнат которые не входят в промижуток выбраного периода в поиске 
            //List<Room_Table> _list = new List<Room_Table>();
            List<Room_Table> _list = null;
            using (context = new ClientContext())
            {
                // _list = context.Rooms.Where(r => r.Arrvals.FirstOrDefault(a => !(a.Time_Arri_begin <= begin && a.Time_Arri_end >= end)) != null).ToList();

                //_list = context.Rooms.Where(r=>r.Arrvals.Where(x => 
                //(begin.Ticks <= x.Time_Arri_end.Ticks && end.Ticks >= x.Time_Arri_begin.Ticks)||
                //(begin.Ticks>=x.Time_Arri_begin.Ticks && begin.Ticks<=x.Time_Arri_end.Ticks)||
                //(begin.Ticks<=x.Time_Arri_begin.Ticks && end.Ticks >= x.Time_Arri_end.Ticks)) != null).ToList();


                var res = from r in context.Rooms
                          where r.Arrvals.Any(x =>!(
                         (begin <= x.Time_Arri_end && end >= x.Time_Arri_begin) ||
                         (begin >= x.Time_Arri_begin && begin <= x.Time_Arri_end) ||
                         (begin >= x.Time_Arri_begin && end  <= x.Time_Arri_end) ||
                         (begin <= x.Time_Arri_begin && end >= x.Time_Arri_end)))
                         select r;

                _list = new List<Room_Table>(res);


                //var QueryNew = _context.Appointments.Where(x => x.CreatedOn >= FromDate).Where(x => x.CreatedOn <= ToDate).Where(x => x.IsActive == true).ToList();

                //foreach (var room in context.Rooms.Include("Arrvals"))
                //{
                //    try
                //    {
                //        foreach (var arrval in room.Arrvals)
                //        {
                //            if (!(arrval.Time_Arri_end <= begin && end >= arrval.Time_Arri_end))
                //            {
                //                _list.Add(room);
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        var tmp = ex;
                //    }
                //}
                return _list;

            }
        }

    }
}

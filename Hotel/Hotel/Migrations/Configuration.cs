namespace Hotel.Migrations
{
    using DataModel;
    using DataModel.Room;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Hotel.DataModel.ClientContext>
    {
        DirectoryInfo directoryInfo;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", directoryInfo.FullName);

        }

        protected override void Seed(Hotel.DataModel.ClientContext context)
        {
           
            Mobile_Table mobile = new Mobile_Table();
            mobile.Nuber = "+380-93-37-20-606";
            context.Mobiles.Add(mobile);
            context.SaveChanges();

            Password_Table pass = new Password_Table();
            string pas_sha = "+380-93-37-20-606";
            byte[] data = Encoding.Default.GetBytes(pas_sha);
            var result = new SHA256Managed().ComputeHash(data);
            pass.Pass = Encoding.Default.GetString(result);
            context.Passwords.Add(pass);
            context.SaveChanges();


            Email_Table Email = new Email_Table();
            Email.Info_Email = "vasya@gmail.com";
            context.Emails.Add(Email);
            context.SaveChanges();


            Car_Table Car = new Car_Table();
            Car.Info_Car = true;
            context.Cars.Add(Car);
            context.SaveChanges();

            Food_Table food = new Food_Table();
            food.Info_Food = "Нужен завтрак и ужен";
            context.Foods.Add(food);
            context.SaveChanges();

            Client_Tenant Client_Tenant = new Client_Tenant();
            Client_Tenant.LastName = "Владимир";
            Client_Tenant.FirstName = "Петров";

            Client_Tenant.Mobile = mobile;
            Client_Tenant.Car = Car;
            Client_Tenant.Email = Email;
            Client_Tenant.Food = food;
            Client_Tenant.Passw = pass;
            context.Client_Tenants.Add(Client_Tenant);
            context.SaveChanges();
            

        
            //////////////////////////////1 комната////////////////////////
            Room_Table Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName,@"Image\1.jpg"));
            Room_Table.Info_Room = "2 кровати(двухспальные), 2 тумбочки, отдельный санузел кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 3;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 1;
            DateTime date = new DateTime(2018, 6, 5);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            //////////////////////////////2 комната////////////////////////

            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\2.jpg"));
            Room_Table.Info_Room = "2 кровати(1 двухспальная, 1 односпальная), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 5;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 2;
            date = new DateTime(2018, 12, 15);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 12, 20);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            //////////////////////////////3 комната////////////////////////
            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\3.jpg"));
            Room_Table.Info_Room = "22 кровати(1 двухспальная, 1 односпальная), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 5;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 3;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            ////////////////////////////4 комната////////////////////////
            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\4.jpg"));
            Room_Table.Info_Room = "3 кровати(1 двухспальная,2 односпальная), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 3;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 4;
            date = new DateTime(2018, 6, 12);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 19);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            ////////////////////////////5 комната////////////////////////
            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\5.jpg"));
            Room_Table.Info_Room = "4 кровати(4 односпальных), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 5;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 5;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            //////////////////////////////6 комната////////////////////////

            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\6.jpg"));
            Room_Table.Info_Room = "25 кровати(1 двухспальная, 1 односпальная), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 5;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 6;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();
            //////////////////////////////7 комната////////////////////////
            Room_Table = new Room_Table();
            Room_Table.Images = File.ReadAllBytes(Path.Combine(directoryInfo.FullName, @"Image\7.jpg"));
            Room_Table.Info_Room = "26 кровати(1 двухспальная, 1 односпальная), 2 тумбочки, кондиционер, холодилькник, телевизор, WI-FI";
            Room_Table.col_peopls_Room = 5;
            context.Rooms.Add(Room_Table);
            context.SaveChanges();

            Time_Arrival = new Time_Arrival();
            Time_Arrival.Room_ID = 7;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_begin = date;
            date = new DateTime(2018, 6, 22);
            Time_Arrival.Time_Arri_end = date;
            context.Time_Ar.Add(Time_Arrival);
            context.SaveChanges();

        }
    }
}

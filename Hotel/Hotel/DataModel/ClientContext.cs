namespace Hotel.DataModel
{
   
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Room;

    public class ClientContext : DbContext
    {
     
        public ClientContext()
            : base("name=Client")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }     
       
        public DbSet<Client_Tenant> Client_Tenants { set; get; }
        public DbSet<Mobile_Table> Mobiles { set; get; }
        public DbSet<Car_Table> Cars { set; get; }
        public DbSet<Food_Table> Foods { set; get; }
        public DbSet<Email_Table> Emails { set; get; }
        public DbSet<Password_Table> Passwords { set; get; }


        public DbSet<Room_Table> Rooms { set; get; }
        public DbSet<Time_Arrival> Time_Ar { set; get; }



    }
    
}
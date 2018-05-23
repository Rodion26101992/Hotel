using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
    public class Client_Tenant
    {
        public int Client_TenantId { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }

        [ForeignKey("Mobile")]
        public int Mobile_Id { set; get; }
        [ForeignKey("Car")]
        public int Car_Id { set; get; }
        [ForeignKey("Email")]
        public int Email_Id { set; get; }
        [ForeignKey("Food")]
        public int Food_Id { set; get; }
        [ForeignKey("Passw")]
        public int Pass_Id { set; get; }

        ////////////////////////навигационное свойтсво/////////////////////////
        public Password_Table Passw { set; get; }
        public Car_Table Car { set; get; }
        public Food_Table Food { set; get; }
        public Mobile_Table Mobile { set; get; }
        public Email_Table Email { set; get; }
    }
}

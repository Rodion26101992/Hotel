using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
 public  class Password_Table
    {
        public int Password_TableId { set; get; }

        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        //[StringLength(25, MinimumLength = 8)]
        public string Pass { set; get; }
        ICollection<Password_Table> Passw { set; get; } //навигационное свойство
        public Password_Table()
        {
            Passw = new List<Password_Table>();
        }
    }
}

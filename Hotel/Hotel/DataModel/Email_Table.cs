using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
  public class Email_Table
    {
        public int Email_TableId { set; get; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Info_Email { set; get; }

        ICollection<Email_Table> Emails { set; get; } //навигационное свойство
        public Email_Table()
        {
            Emails = new List<Email_Table>();
        }

    }
}

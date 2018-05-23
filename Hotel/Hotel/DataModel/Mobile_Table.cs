using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
    public class Mobile_Table
    {
        public int Mobile_TableId { set; get; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Nuber { set; get; }

        ICollection<Mobile_Table> Mobile { set; get; }
        public Mobile_Table()
        {
            Mobile = new List<Mobile_Table>();
        }

    }
}

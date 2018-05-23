using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel.Room
{
  public  class Room_Table
    {
        public int Room_TableId { set; get; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Info_Room { set; get; }

        public int col_peopls_Room { set; get; }

        public byte[] Images { set; get; }

        public ICollection<Time_Arrival> Arrvals { set; get; }
        ICollection<Room_Table> Rooms { set; get; } //навигационное свойство
        public Room_Table()
        {
            Rooms = new List<Room_Table>();
        }
    }
}

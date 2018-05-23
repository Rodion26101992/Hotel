using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel.Room
{
  public  class Time_Arrival
    {
        public int Time_ArrivalId { set; get; }

        [ForeignKey("Rooms")]
        public int Room_ID { set; get; }
        public DateTime Time_Arri_begin { set; get; }
        public DateTime Time_Arri_end { set; get; }

        public Room_Table Rooms { set; get; }
    }
}

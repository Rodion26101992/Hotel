using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
    public class Car_Table
    {
        public int Car_TableId { set; get; }
        public bool Info_Car { set; get; }
        ICollection<Car_Table> Car { set; get; } //навигационное свойство
        public Car_Table()
        {
            Car = new List<Car_Table>();
        }

    }
}

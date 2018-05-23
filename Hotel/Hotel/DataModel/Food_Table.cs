using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataModel
{
    public class Food_Table
    {
        public int Food_TableId { set; get; }
        public string Info_Food { set; get; }

        ICollection<Food_Table> Food { set; get; } //навигационное свойство
        public Food_Table()
        {
            Food = new List<Food_Table>();
        }

    }
}

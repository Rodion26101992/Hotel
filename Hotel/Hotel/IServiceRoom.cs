using Hotel.DataModel.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    [ServiceContract]
   public  interface IServiceRoom
    {
        [OperationContract]
        List<Room_Table> GetRoom();
        [OperationContract]
        List<Room_Table> Time_GetRoom(DateTime begin,DateTime end);
        [OperationContract]
        void addTime_Room(DateTime begin, DateTime end, int number);

    }
}

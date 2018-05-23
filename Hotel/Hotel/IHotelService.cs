using Hotel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hotel
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IHotelService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IHotelService : IServiceRoom
    {
        [OperationContract]
        void AddClient(string mobile_, string pass_, string email_, string food_, string lastName_, string firstName_);

        [OperationContract]
        Client_Tenant Autorisationn(string login, string pass);


    }
}

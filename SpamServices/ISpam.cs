using System.ServiceModel;

namespace SpamServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ISpam
    {
        [OperationContract]
        string GetSpam();

        // TODO: Добавьте здесь операции служб
    }
}

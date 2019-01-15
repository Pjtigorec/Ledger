using SpamServices.Models;
using System.ServiceModel;

namespace SpamServices
{
    [ServiceContract]
    public interface ISpamServices
    {
        [OperationContract]
        Spam GetSpam();
    }
}

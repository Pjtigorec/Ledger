using SpamServices.Models;
using System.ServiceModel;

namespace SpamServices
{
    [ServiceContract]
    public interface ISpamService
    {
        [OperationContract]
        Spam GetSpam();
    }
}

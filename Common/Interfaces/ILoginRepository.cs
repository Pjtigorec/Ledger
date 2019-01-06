using Common.AccountModels;
using Common.Core;

namespace Common.Interfaces
{
    public interface ILoginRepository
    {
        User LoginUser(LoginModel model);
    }
}

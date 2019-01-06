using Common.AccountModels;
using Common.Core;

namespace Common.Interfaces
{
    public interface IRegisterRepository
    {
        bool CheckLoginForRegister(string login);

        User RegisterNewUser(RegisterModel model);
    }
}

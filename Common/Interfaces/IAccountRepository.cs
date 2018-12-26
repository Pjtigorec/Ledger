namespace Common.Interfaces
{
    public interface IAccountRepository
    {
        ILoginRepository Login { get; set; }

        IRegisterRepository Register { get; set; }
    }
}

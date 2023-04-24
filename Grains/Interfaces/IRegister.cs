using Orleans;

namespace Grains.Interfaces
{
    public interface IRegister : IGrainWithIntegerKey
    {
        Task<string> Register(int clientID, string description);
    }
}

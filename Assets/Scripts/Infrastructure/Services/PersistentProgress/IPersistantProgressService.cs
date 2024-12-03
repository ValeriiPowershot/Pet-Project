using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface IPersistantProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}

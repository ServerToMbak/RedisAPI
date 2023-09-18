using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? getPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }
}
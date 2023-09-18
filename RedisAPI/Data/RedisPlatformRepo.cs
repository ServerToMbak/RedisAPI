using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using RedisAPI.Models;
using StackExchange.Redis;

namespace RedisAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis ; 
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat)); 
            } 

            var db = _redis.GetDatabase();
            var serializePlat = JsonSerializer.Serialize(plat);

            // db.StringSet(plat.Id,serializePlat); // we are giving the key and the value when we are setting a new data
            // db.SetAdd("PlatformSet",serializePlat);
            
            db.HashSet("hashPlatform", new HashEntry[]
            {new HashEntry(plat.Id, serializePlat)});
        }

        public IEnumerable<Platform?>? GetAllPlatforms()
        {
            var db = _redis.GetDatabase();

            // var completeSet = db.SetMembers("PlatformSet");

            var completeHash = db.HashGetAll("hashPlatform");

            if(completeHash.Length > 0)
            {
                var obj = Array.ConvertAll(completeHash, val => JsonSerializer.Deserialize<Platform>(val.Value)).ToList();
            
                return obj;
            
            }
            return null;
        }

        public Platform? getPlatformById(string id)
        {
            var db = _redis.GetDatabase();
            // var plat = db.StringGet(id);

            var plat = db.HashGet("hashPlatform", id);

            if(!String.IsNullOrEmpty(nameof(plat)))
            {
                return JsonSerializer.Deserialize<Platform>(plat);
            }
            return null;
        }
    }
}
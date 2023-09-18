using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface ICommandRepo
    {
        public Task<string> CreaateCommand(Command comamnd); 
        public Task<List<string>> GetCommandsBySetId(string setId);
    }
}
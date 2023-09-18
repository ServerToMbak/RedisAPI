using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Internal;
using RedisAPI.Models;
using StackExchange.Redis;

namespace RedisAPI.Data
{
    public class RedisCommandRepo : ICommandRepo
    {
        private readonly IConnectionMultiplexer _repo;

        public RedisCommandRepo(IConnectionMultiplexer repo)
    {
        _repo = repo;
    }
        public async Task<string> CreaateCommand(Command command)
        {
            var db = _repo.GetDatabase();
            
            var seriazlizeCommand = JsonSerializer.Serialize(command);
        
            var operation = await db.SetAddAsync("commandSet",seriazlizeCommand);

            if(operation == true)
            {
                return "Operation is completed Successfully";
            }
            return "An error occured while adding the data to the db";
        }

        public async Task<List<string>> GetCommandsBySetId(string commandId)
        {
           var db = _repo.GetDatabase();

            var elements = await db.SetMembersAsync("commandSet");

        // Convert the elements to a list of strings.
            var commandStrings = elements.Select(e => e.ToString()).ToList();

            return commandStrings;
        }
    }
}
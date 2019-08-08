using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ErrorLogCenter.Entity
{
    public class MongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<ErrorLogRepo> ErrorLogRepos => _db.GetCollection<ErrorLogRepo>("errorlog");

    }
}

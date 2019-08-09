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

        public MongoContext(string s1,string s2)
        {
            var client = new MongoClient(s1);
            _db = client.GetDatabase(s2);
        }

        public IMongoCollection<ErrorLogRepo> ErrorLogRepos => _db.GetCollection<ErrorLogRepo>("errorlog");

    }
}

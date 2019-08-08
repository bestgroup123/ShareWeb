using Share.Domain.ErrorLogCenter.Entity;
using Share.Domain.ErrorLogCenter.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Share.Domain.ErrorLogCenter.Repository
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly MongoContext _mongodb;

        public ErrorLogRepository(MongoContext mongodb)
        {
            _mongodb = mongodb;
        }

        public async Task<string> Create(ErrorLogRepo repo)
        {
            await _mongodb.ErrorLogRepos.InsertOneAsync(repo);
            return repo.Id;
        }
    }
}

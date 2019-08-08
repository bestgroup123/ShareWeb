using Share.Domain.ErrorLogCenter.Entity;
using Share.Domain.ErrorLogCenter.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ErrorLogCenter.Repository
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly MongoContext _mongodb;

        public ErrorLogRepository(MongoContext mongodb)
        {
            _mongodb = mongodb;
        }

        public void Create()
        {

        }
    }
}

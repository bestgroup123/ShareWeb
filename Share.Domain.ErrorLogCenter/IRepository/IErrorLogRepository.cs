using Share.Domain.ErrorLogCenter.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Share.Domain.ErrorLogCenter.IRepository
{
    public interface IErrorLogRepository
    {
        Task<string> Create(ErrorLogRepo repo);
    }
}

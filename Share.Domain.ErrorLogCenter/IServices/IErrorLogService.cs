using Share.Domain.ErrorLogCenter.Entity;
using Share.Domain.ErrorLogCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Share.Domain.ErrorLogCenter.IServices
{
    public interface IErrorLogService
    {
        Task<string> Create(CreateErrorLogDto dto);
    }
}

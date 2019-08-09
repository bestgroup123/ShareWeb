using SchoolPal.Toolkit.Caching;
using Share.Domain.ErrorLogCenter.Entity;
using Share.Domain.ErrorLogCenter.IRepository;
using Share.Domain.ErrorLogCenter.IServices;
using Share.Domain.ErrorLogCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Share.Domain.ErrorLogCenter.Services
{
    public class ErrorLogService : IErrorLogService
    {
        private IErrorLogRepository _errorLogRepository;

        public ErrorLogService(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public async Task<string> Create(CreateErrorLogDto dto)
        {
            var repo = new ErrorLogRepo
            {
                ErrorContent = dto.ErrorContent,
                ErrorTime = dto.ErrorTime,
                OperatorId = dto.OperatorId
            };
            await _errorLogRepository.Create(repo);
            return repo.Id;
        }
    }
}

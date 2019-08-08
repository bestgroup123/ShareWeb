using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolPal.Toolkit.Caching;
using SchoolPal.Toolkit.Caching.Redis;
using Share.Common;
using Share.Domain.ErrorLogCenter.Entity;
using Share.Domain.ErrorLogCenter.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Share.Filter
{
    public class ErrorFilterAttribute : ExceptionFilterAttribute
    {
        private IErrorLogRepository _errorLogRepository;
        private ICache _cache;
        private RedisCache _redis;

        public ErrorFilterAttribute(IErrorLogRepository errorLogRepository, ICache cache, RedisCache redis)
        {
            _errorLogRepository = errorLogRepository;
            _cache = cache;
            _redis = redis;
        }

        public override void OnException(ExceptionContext exceptionContext)
        {
            var error = exceptionContext.Exception as ErrorException;
            if (error != null)
            {
                exceptionContext.ExceptionDispatchInfo.Throw();
            }
            else
            {
                var userLoginId = _redis.Get("userloginid");
                var errorLog = new ErrorLogRepo
                {
                    ErrorContent = exceptionContext.Exception.ToString(),
                    ErrorTime = DateTime.Now,
                    OperatorId = userLoginId.ToString()
                };
                _errorLogRepository.Create(errorLog);
                exceptionContext.ExceptionHandled = true;
                exceptionContext.Result = new RedirectResult("/home/Error");
            }
            base.OnException(exceptionContext);
        }
    }
}

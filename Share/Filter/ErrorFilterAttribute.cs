using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolPal.Toolkit.Caching;
using Share.Common;
using Share.Domain.ErrorLogCenter.IServices;
using Share.Domain.ErrorLogCenter.Model;
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
        private IErrorLogService _errorLogService;
        private ICache _cache;

        public ErrorFilterAttribute(IErrorLogService errorLogService, ICache cache)
        {
            _errorLogService = errorLogService;
            _cache = cache;
        }

        public override void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext.Result == null)
            {
                var error = exceptionContext.Exception as ErrorException;
                if (error != null)
                {
                    exceptionContext.Result = new ObjectResult(error.ErrorType);
                }
                else
                {
                    var userLoginId = _cache.Get("userloginid");
                    var errorLog = new CreateErrorLogDto
                    {
                        ErrorContent = exceptionContext.Exception.ToString(),
                        ErrorTime = DateTime.Now,
                        OperatorId = userLoginId == null ? "0" : userLoginId.ToString()
                    };
                    _errorLogService.Create(errorLog);


                    exceptionContext.ExceptionHandled = true;
                    exceptionContext.HttpContext.Response.StatusCode = System.Net.HttpStatusCode.InternalServerError.GetHashCode();
                    exceptionContext.Result = new ObjectResult(error.ErrorType);
                }
            }
            base.OnException(exceptionContext);
        }
    }
}

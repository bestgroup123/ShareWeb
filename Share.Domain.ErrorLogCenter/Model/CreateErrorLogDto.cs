using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ErrorLogCenter.Model
{
    public class CreateErrorLogDto
    {
        public string ErrorContent { get; set; }
        public DateTime ErrorTime { get; set; } = DateTime.Now;
        public string OperatorId { get; set; }
    }
}

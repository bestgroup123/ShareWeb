using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ErrorLogCenter.Entity
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}

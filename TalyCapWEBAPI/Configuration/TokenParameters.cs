using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalyCap.Abstraction;

namespace TalyCapWEBAPI.Configuration
{
    public class TokenParameters : ITokenParameters
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
    }
}

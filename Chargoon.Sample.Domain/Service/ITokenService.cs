using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.Service
{
    public interface ITokenService
    {
        double ExpireMilliSeconds { get; }
        string TokenType { get; }
        string GenerateToken(string id);
        bool ValidateToken(string token, out string id);
    }
}

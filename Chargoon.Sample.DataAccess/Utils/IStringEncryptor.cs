using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.DataAccess.Utils
{
    public interface IStringEncryptor
    {
        string EncryptString(string plainText);
        string DecryptString(string encryptedText);
    }
}

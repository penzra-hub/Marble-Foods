using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Application.Helpers
{
    public interface IEncryptionHandler
    {
        string RSADecryptData(string encryptedData);
        string RSAEncryptData(string plainData);
        string AESEncryptData(string userdata);
        string AESDecryptData(string encryptedData);
    }
}

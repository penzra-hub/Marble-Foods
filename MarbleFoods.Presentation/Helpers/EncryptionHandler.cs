using MarbleFoods.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MarbleFoods.Application.Helpers
{
    public class EncryptionHandler(IOptions<Access> accessSettings) : IEncryptionHandler
    {
        public string RSADecryptData(string data)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string folderPath = Path.Combine(currentDirectory, "CrptoFiles");
                string filePath = Path.Combine(folderPath, "integration-private-key-dev.pem");
                byte[] encryptedBytes = Convert.FromBase64String(data);
                string pemContents = File.ReadAllText(filePath);
                RSA privateKey = RSA.Create();
                privateKey.ImportFromPem(pemContents);
                byte[] decryptedBytes = privateKey.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
                string decryptedString = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedString;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public string RSAEncryptData(string data)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string folderPath = Path.Combine(currentDirectory, "CrptoFiles");
                string filePath = Path.Combine(folderPath, "integration-public-key-dev.pem");

                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                string pemContents = File.ReadAllText(filePath);
                RSA publicKey = RSA.Create();
                publicKey.ImportFromPem(pemContents);
                byte[] encryptedBytes = publicKey.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1);
                string encryptedString = Convert.ToBase64String(encryptedBytes);
                return encryptedString;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string AESDecryptData(string encryptedData)
        {
            var encryptionKey = accessSettings.Value.Key;
            var encryptionIV = accessSettings.Value.IV;

            byte[] cipherBytes = Convert.FromBase64String(encryptedData);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(encryptionIV);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }


        public string AESEncryptData(string userdata)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(accessSettings.Value.Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(accessSettings.Value.Key);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(userdata);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}

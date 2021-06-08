using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    class AES
    {
        static private string key = "NguyenDatThinh 19520982 ANTN2019";
        static private string iv = "19520982ANTN2019";
        static public byte[] Encrypt(string plaintext)
        {
            byte[] encrypted;
            plaintext = plaintext.Length.ToString() + '\n' + plaintext;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Encoding.UTF8.GetBytes(AES.key);
                aesAlg.IV = Encoding.UTF8.GetBytes(AES.iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plaintext);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        static public string Decrypt(byte[] ciphertext)
        {
            string plaintext;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Encoding.UTF8.GetBytes(AES.key);
                aesAlg.IV = Encoding.UTF8.GetBytes(AES.iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            int msg_len;
            for (int i = 0; i < plaintext.Length; ++i)
            {
                if (plaintext[i] == '\n')
                {
                    int.TryParse(plaintext.Substring(0, i), out msg_len);
                    plaintext = plaintext.Substring(i + 1, msg_len);
                    break;
                }
            }

            return plaintext;
        }
    }
}

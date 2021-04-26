using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FarmGame.Common
{
    static class Encrypt
    {
        private static int IVLength = 16;
        private static int KeyLength = 32;

        //! キーサイズ
        private static readonly int KeySize = 256;

        //! ブロックサイズ
        private static readonly int BlockSize = 128;

        public static void Encode(string input, string output)
        {
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.KeySize = KeySize;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.GenerateIV();
                aesAlg.GenerateKey();
                aesAlg.Padding = PaddingMode.PKCS7;

                byte[] encrypted;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            using (StreamReader read = new StreamReader(input))
                            {
                                swEncrypt.Write(read.ReadToEnd());
                            }
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
                using (FileStream write = new FileStream(output, FileMode.Create))
                {
                    write.Write(aesAlg.IV);
                    write.Write(aesAlg.Key);
                    write.Write(encrypted);
                }
            }
        }


        public static string Decode(string input)
        {
            byte[] IV = new byte[IVLength];
            byte[] Key = new byte[KeyLength];
            string plaintext = null;
            using (FileStream read = new FileStream(input, FileMode.Open))
            {
                int length = (int)(read.Length - IVLength - KeyLength);
                byte[] data = new byte[length];
                read.Read(IV, 0, IVLength);
                read.Read(Key, 0, KeyLength);
                read.Read(data, 0, length);
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.KeySize = KeySize;
                    aesAlg.BlockSize = BlockSize;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.IV = IV;
                    aesAlg.Key = Key;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(data))
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
            }

            return plaintext;
        }

        public static void Save(string input, string output)
        {
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.KeySize = KeySize;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.GenerateIV();
                aesAlg.GenerateKey();
                aesAlg.Padding = PaddingMode.PKCS7;

                byte[] encrypted;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
                using (FileStream write = new FileStream(output, FileMode.Create))
                {
                    write.Write(aesAlg.IV);
                    write.Write(aesAlg.Key);
                    write.Write(encrypted);
                }
            }
        }
    }
}

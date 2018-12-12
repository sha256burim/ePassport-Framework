using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ePassport_Framework
{
    class Encryption
    {

        public byte[] KeyGenerator(string plaintext_key)
        {
            //Key is encoded to base64 before converted into a byte array
            //
            byte[] Key = Encoding.UTF8.GetBytes(plaintext_key);

            return Key;
        }

        public byte[] IVGenerator()
        {

            //Generate a cryptographic true random number.
            using (var RNGCryptoGenerator = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[16];
                RNGCryptoGenerator.GetBytes(buffer);

                //Return Convert.ToBase64String(buffer) if you want a Base64 string representation of the random number.
                //Return BitConverter.ToString(Encrypted).Replace("-", String.Empty); if ou want a string represantation instead

                return buffer;
            }
        }

        public byte[] Encrypt(string data, byte[] Key, byte[] IV)
        {

            byte[] EncryptedData;

            //Check arguments 
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data");
            if (Key == null || data.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || data.Length <= 0)
                throw new ArgumentNullException("IV");

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(data);
                        }

                        EncryptedData = msEncrypt.ToArray();

                    }

                }

            }

            // Return the encrypted bytes from the memory stream.
            return EncryptedData;
        }

        public string Decrypt(byte[] EncryptedData, byte[] Key, byte[] IV)
        {
           

            // Check arguments.
            if (EncryptedData == null || EncryptedData.Length <= 0)
                throw new ArgumentNullException("Encrypted_data");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string Decrypted_data = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(EncryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream and place them in a string 
                           
                            Decrypted_data = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return Decrypted_data;
        }
        
    }
}


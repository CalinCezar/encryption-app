using EncryptionLibrary.EncryptionCode.Symmetric;
using EncryptProjectTSI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProjectTSI.MVVM.ViewModels
{
    class SymmetricViewModel
    {
        private AESalgorithm aes;
        private SymmetricModel symmetricModel;
        public SymmetricViewModel()
        {
            symmetricModel = new SymmetricModel();
            aes = new AESalgorithm();
        }

        public string Encrypt(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            int ciphertextSize = ((plaintextBytes.Length / 16) + 1) * 16;
            byte[] encryptedBytes = new byte[ciphertextSize]; 
            bool result = aes.Encrypt(plaintextBytes, ref encryptedBytes); 

            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
            return encryptedBase64;
        }

        public string Decrypt(string cyphertext)
        {
            byte[] encryptedBytes = Convert.FromBase64String(cyphertext);
            byte[] decryptedBytes = new byte[encryptedBytes.Length]; // Allocate space for decrypted text
            aes.Decrypt(encryptedBytes, ref decryptedBytes); // Decrypt using AES
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedText;
        }
        public string generateKey()
        {
            byte[] key = aes.GenerateKey(symmetricModel.KeySize);
            aes.SetKeySize(symmetricModel.KeySize);
            aes.Key = key;
            return Convert.ToBase64String(key);
        }
        public void setKey(int bits)
        {
            symmetricModel.KeySize = bits;
        }
    }
}

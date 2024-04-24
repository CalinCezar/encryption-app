using EncryptionLibrary.EncryptionCode.Asymmetric;
using EncryptProjectTSI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProjectTSI.MVVM.ViewModels
{
    class AsymmetricViewModel
    {
        private AsymmetricModel asymmetricModel;
        private RSAalgorithm rsa;
        public AsymmetricViewModel() 
        {
            asymmetricModel = new AsymmetricModel();
            rsa = new RSAalgorithm();
        }

        public string Encrypt(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedBytes =  rsa.Encrypt(plaintextBytes); 

            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
            return encryptedBase64;
        }

        public string Decrypt(string cyphertext)
        {
            byte[] encryptedBytes = Convert.FromBase64String(cyphertext);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes);
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedText;
        }

        public void generateKey(ref string privateKey, ref string publicKey)
        {
            rsa.GenerateKeys(asymmetricModel.KeySize);
            privateKey = rsa.GetPrivateKeyPem();
            publicKey = rsa.GetPublicKeyPem();
        }
        public void setKey(int bits)
        {
            asymmetricModel.KeySize = bits;
        }
    }
}

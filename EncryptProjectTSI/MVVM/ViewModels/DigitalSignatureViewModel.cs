using EncryptionLibrary.EncryptionCode.Asymmetric;
using EncryptProjectTSI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProjectTSI.MVVM.ViewModels
{
    class DigitalSignatureViewModel
    {
        private RSAalgorithm rsa;
        private DigitalSignatureModel digitalSignatureModel;
        public DigitalSignatureViewModel()
        {
            digitalSignatureModel = new DigitalSignatureModel();
            rsa = new RSAalgorithm();
        }
        public void setKey(int bits)
        {
            digitalSignatureModel.KeySize = bits;
        }
        public string Sign(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedBytes = rsa.Sign(plaintextBytes);

            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
            return encryptedBase64;
        }

        public string Verify(string cyphertext)
        {
            byte[] encryptedBytes = Convert.FromBase64String(cyphertext);
            byte[] decryptedBytes = rsa.Verify(encryptedBytes);
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedText;
        }

        public void generateKey(ref string privateKey, ref string publicKey)
        {
            rsa.GenerateKeys(digitalSignatureModel.KeySize);
            privateKey = rsa.GetPrivateKeyPem();
            publicKey = rsa.GetPublicKeyPem();
        }
    }
}

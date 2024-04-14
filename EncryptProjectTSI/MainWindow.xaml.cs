using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using EncryptionLibrary.EncryptionCode.Asymmetric;
using EncryptProjectTSI.Views.UserControls;

namespace EncryptProjectTSI
{
    public partial class MainWindow : Window
    {
        private RSAalgorithm rsa;
        private int keySize = 2048;
        private String? publicKey = null, privateKey = null;
        public MainWindow()
        {
            InitializeComponent();
            rsa = new RSAalgorithm();
        }
        private void Encrypt_Click(object sender,RoutedEventArgs e)
        {
            if (publicKey == null || privateKey == null)
            {
                rsa.GenerateKeys(keySize);
                publicKey = rsa.GetNPem() + "\n" + rsa.GetEPem();
                privateKey = rsa.GetNPem() + "\n" + rsa.GetDPem();
                PrivateKey.Text = privateKey;
                PublicKey.Text = publicKey;
            }

            // Your plaintext string
            string plaintext = Input.Text;

            // Convert plaintext to byte array using UTF-8 encoding
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

            // Calculate the maximum block size for encryption
            int maxBlockSize = (keySize / 8) - 11; // 11 bytes is reserved for padding

            // Encrypt plaintext by blocks
            byte[] encryptedBytes = null;
            for (int i = 0; i < plaintextBytes.Length; i += maxBlockSize)
            {
                int blockSize = Math.Min(maxBlockSize, plaintextBytes.Length - i);
                byte[] block = new byte[blockSize];
                Array.Copy(plaintextBytes, i, block, 0, blockSize);

                // Encrypt the block
                byte[] encryptedBlock = rsa.Encrypt(block);

                // Append or concatenate the encrypted block to the final encrypted bytes
                if (encryptedBytes == null)
                    encryptedBytes = encryptedBlock;
                else
                {
                    byte[] temp = new byte[encryptedBytes.Length + encryptedBlock.Length];
                    Buffer.BlockCopy(encryptedBytes, 0, temp, 0, encryptedBytes.Length);
                    Buffer.BlockCopy(encryptedBlock, 0, temp, encryptedBytes.Length, encryptedBlock.Length);
                    encryptedBytes = temp;
                }
            }

            // Store or transmit the encrypted data
            // For demonstration, let's convert the encrypted bytes to a Base64 string for easy storage/transmission
            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);

            Output.Text= encryptedBase64;
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (publicKey == null || privateKey == null)
            {
                rsa.GenerateKeys(keySize);
                publicKey = rsa.GetNPem() + "\n" + rsa.GetEPem();
                privateKey = rsa.GetNPem() + "\n" + rsa.GetDPem();
                PrivateKey.Text = privateKey;
                PublicKey.Text = publicKey;
            }
            string encryptedBase64 = Input.Text;

            // Convert the Base64 string to byte array
            byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);

            // Calculate the maximum block size for decryption
            int blockSize = keySize / 8; // RSA key size in bytes

            // Decrypt encrypted bytes by blocks
            List<byte[]> decryptedBlocks = new List<byte[]>();
            for (int i = 0; i < encryptedBytes.Length; i += blockSize)
            {
                int blockLength = Math.Min(blockSize, encryptedBytes.Length - i);
                byte[] encryptedBlock = new byte[blockLength];
                Array.Copy(encryptedBytes, i, encryptedBlock, 0, blockLength);

                // Decrypt the block
                byte[] decryptedBlock = rsa.Decrypt(encryptedBlock);

                // Add the decrypted block to the list
                decryptedBlocks.Add(decryptedBlock);
            }

            // Concatenate the decrypted blocks to form the decrypted message
            byte[] decryptedBytes = decryptedBlocks.SelectMany(x => x).ToArray();

            // Convert the decrypted byte array back to string using UTF-8 encoding
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            // Display the decrypted text in the InputText control
            Output.Text = decryptedText;
        }
    }
}
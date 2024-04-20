using System.Text;
using System.Windows;
using EncryptionLibrary.EncryptionCode.Asymmetric;
using EncryptProjectTSI._Test;

namespace EncryptProjectTSI
{
    public partial class MainWindow : Window
    {
        private string example = new Test().example;
        private RSAalgorithm rsa;
        private int keySize = 2048;
        private String publicKey, privateKey;

        public MainWindow()
        {
            InitializeComponent();
            rsa = new RSAalgorithm();
            Input.Text = new Test().example;
        }

        private void ShowSymmetricEncryptionWindow(object sender, EventArgs e)
        {

        }

        private void ShowAsymmetricEncryptionWindow(object sender, EventArgs e)
        {

        }

        private void ShowDigitalSignatureWindow(object sender, EventArgs e)
        {

        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(privateKey))
            {
                do
                {
                    rsa.GenerateKeys(keySize);
                } while (Test(example));
                publicKey = rsa.GetNPem() + "\n" + rsa.GetEPem();
                privateKey = rsa.GetNPem() + "\n" + rsa.GetDPem();
                PrivateKey.Text = privateKey;
                PublicKey.Text = publicKey;
            }

            string plaintext = Input.Text;

            // Convert plaintext to byte array
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            // Calculate the maximum block size for encryption
            int maxBlockSize = (keySize / 8);

            // Encrypt plaintext by blocks
            List<byte[]> encryptedBlocks = new List<byte[]>();
            for (int i = 0; i < plaintextBytes.Length; i += maxBlockSize)
            {
                int blockSize = Math.Min(maxBlockSize, plaintextBytes.Length - i);
                byte[] block = new byte[blockSize];
                Array.Copy(plaintextBytes, i, block, 0, blockSize);

                // Encrypt the block
                byte[] encryptedBlock = rsa.Encrypt(block);
                encryptedBlocks.Add(encryptedBlock);
            }

            // Concatenate encrypted blocks
            byte[] encryptedBytes = encryptedBlocks.SelectMany(x => x).ToArray();

            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);

            Output.Text = encryptedBase64;

        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(privateKey))
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
            int blockSize = keySize / 8;

            // Decrypt encrypted bytes by blocks
            List<byte[]> decryptedBlocks = new List<byte[]>();
            for (int i = 0; i < encryptedBytes.Length; i += blockSize)
            {
                int blockLength = Math.Min(blockSize, encryptedBytes.Length - i);
                byte[] encryptedBlock = new byte[blockLength];
                Array.Copy(encryptedBytes, i, encryptedBlock, 0, blockLength);

                byte[] decryptedBlock = rsa.Decrypt(encryptedBlock);

                decryptedBlocks.Add(decryptedBlock);
            }

            // Concatenate the decrypted blocks to form the decrypted message
            byte[] decryptedBytes = decryptedBlocks.SelectMany(x => x).ToArray();
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            Output.Text = decryptedText;
        }
        private void Reverse_Click(object sender, EventArgs e)
        {
            var temp = Input.Text;
            Input.Text = Output.Text;
            Output.Text = temp;
        }

        public bool Test(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            int maxBlockSize = keySize / 8;

            // Encrypt plaintext by blocks
            List<byte[]> encryptedBlocks = new List<byte[]>();
            for (int i = 0; i < plaintextBytes.Length; i += maxBlockSize)
            {
                int blockSize = Math.Min(maxBlockSize, plaintextBytes.Length - i);
                byte[] block = new byte[blockSize];
                Array.Copy(plaintextBytes, i, block, 0, blockSize);

                // Encrypt the block
                byte[] encryptedBlock = rsa.Encrypt(block);
                encryptedBlocks.Add(encryptedBlock);
            }
            byte[] encryptedBytes = encryptedBlocks.SelectMany(x => x).ToArray();

            // Decrypt encrypted bytes by blocks
            List<byte[]> decryptedBlocks = new List<byte[]>();
            for (int i = 0; i < encryptedBytes.Length; i += maxBlockSize)
            {
                int blockLength = Math.Min(maxBlockSize, encryptedBytes.Length - i);
                byte[] encryptedBlock = new byte[blockLength];
                Array.Copy(encryptedBytes, i, encryptedBlock, 0, blockLength);

                byte[] decryptedBlock = rsa.Decrypt(encryptedBlock);

                decryptedBlocks.Add(decryptedBlock);
            }

            // Concatenate the decrypted blocks to form the decrypted message
            byte[] decryptedBytes = decryptedBlocks.SelectMany(x => x).ToArray();
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            return !decryptedText.Equals(plaintext);
        }

    }
}

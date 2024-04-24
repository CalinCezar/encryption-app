using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using EncryptProjectTSI.MVVM.ViewModels;

namespace EncryptProjectTSI.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AsymmetricView.xaml
    /// </summary>
    public partial class AsymmetricView : UserControl
    {
        private AsymmetricViewModel asymmetricViewModel {  get; set; }
        public AsymmetricView()
        {
            InitializeComponent();
            asymmetricViewModel = new AsymmetricViewModel();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = asymmetricViewModel.Encrypt(Input.Text);
        }
        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = asymmetricViewModel.Decrypt(Input.Text);
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            string temp = Input.Text;
            Input.Text = Output.Text;
            Output.Text = temp;
        }

        private void SetKey1024(object sender, RoutedEventArgs e) 
        {
            asymmetricViewModel.setKey(1024);
        }

        private void SetKey2048(object sender, RoutedEventArgs e) 
        {
            asymmetricViewModel.setKey(2048);
        }
        private void SetKey4096(object sender, RoutedEventArgs e) 
        {
            asymmetricViewModel.setKey(4096);
        }

        private void GenerateKey_Click(object sender, RoutedEventArgs e)
        {
            string privateKeyText = PrivateKey.Text;
            string publicKeyText = PublicKey.Text;

            asymmetricViewModel.generateKey(ref privateKeyText, ref publicKeyText);

            PrivateKey.Text = privateKeyText;
            PublicKey.Text = publicKeyText;
        }
    }
}

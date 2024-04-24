using EncryptProjectTSI.MVVM.ViewModels;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptProjectTSI.MVVM.Views
{
    /// <summary>
    /// Interaction logic for DigitalSignature.xaml
    /// </summary>
    public partial class DigitalSignatureView : UserControl
    {
        private DigitalSignatureViewModel digitalSignatureViewModel {  get; set; }
        public DigitalSignatureView()
        {
            InitializeComponent();
            digitalSignatureViewModel = new DigitalSignatureViewModel();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = digitalSignatureViewModel.Sign(Input.Text);
        }
        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = digitalSignatureViewModel.Verify(Input.Text);
        }

        private void SetKey1024(object sender, RoutedEventArgs e)
        {
            digitalSignatureViewModel.setKey(1024);
        }

        private void SetKey2048(object sender, RoutedEventArgs e)
        {
            digitalSignatureViewModel.setKey(2048);
        }
        private void SetKey4096(object sender, RoutedEventArgs e)
        {
            digitalSignatureViewModel.setKey(4096);
        }

        private void GenerateKey_Click(object sender, RoutedEventArgs e)
        {
            string privateKeyText = PrivateKey.Text;
            string publicKeyText = PublicKey.Text;

            digitalSignatureViewModel.generateKey(ref privateKeyText, ref publicKeyText);

            PrivateKey.Text = privateKeyText;
            PublicKey.Text = publicKeyText;
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            string temp = Input.Text;
            Input.Text = Output.Text;
            Output.Text = temp;
        }
    }
}

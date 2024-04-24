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
    public partial class SymmetricView : UserControl
    {
        private SymmetricViewModel symmetricViewModel {  get; set; }
        private static SymmetricView? SymmetricInstance; 
        public SymmetricView()
        {
            InitializeComponent();
            SymmetricInstance = this;
            symmetricViewModel = new SymmetricViewModel();
        }
        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = symmetricViewModel.Encrypt(Input.Text);
        }
        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = symmetricViewModel.Decrypt(Input.Text);
        }

        private void SetKey128(object sender, RoutedEventArgs e)
        {
            symmetricViewModel.setKey(128);
        }

        private void SetKey196(object sender, RoutedEventArgs e)
        {
            symmetricViewModel.setKey(196);
        }
        private void SetKey256(object sender, RoutedEventArgs e)
        {
            symmetricViewModel.setKey(256);
        }

        private void GenerateKey_Click(object sender, RoutedEventArgs e)
        {
            PublicKey.Text = symmetricViewModel.generateKey();
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            string temp = Input.Text;
            Input.Text = Output.Text;
            Output.Text = temp;
        }
    }
}

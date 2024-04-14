using System.Windows;
using System.Windows.Controls;

namespace EncryptProjectTSI.Views.UserControls
{
    public partial class InputText : UserControl
    {
        public InputText()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        private string placeholder="";
        public string Placeholder
        {
            get {
                return placeholder;
            }
            set { placeholder = value; 
            tbPlaceHolder.Text = placeholder;
            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceHolder.Visibility = Visibility.Visible;
            else
                tbPlaceHolder.Visibility = Visibility.Hidden;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using EncryptProjectTSI.MVVM.Views;
using EncryptionLibrary.EncryptionCode.Asymmetric;
using EncryptionLibrary.EncryptionCode.Symmetric;
using EncryptProjectTSI._Test;

namespace EncryptProjectTSI
{
    public partial class MainWindow : Window
    {
        public static MainWindow? MainInstance { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainInstance = this;

        }
    }
}

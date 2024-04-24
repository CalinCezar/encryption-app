using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptProjectTSI.Core;

namespace EncryptProjectTSI.MVVM.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SymmetricViewCommand { get; set; }
        public RelayCommand AsymmetricViewCommand { get; set; }
        public RelayCommand DigSignatureCommand { get; set; }

        public SymmetricViewModel SymmetricVM { get; set; }
        public AsymmetricViewModel AsymmetricVM { get; set; }
        public DigitalSignatureViewModel DigSignatureVM { get; set; }

        private object? _currentView;
        public object CurrentView
        {
            get { return _currentView!; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public MainWindowViewModel()
        {
            SymmetricVM = new SymmetricViewModel();
            AsymmetricVM = new AsymmetricViewModel();
            DigSignatureVM = new DigitalSignatureViewModel();

            CurrentView = SymmetricVM;

            SymmetricViewCommand = new RelayCommand(o =>
            {
                CurrentView = SymmetricVM;
            });
            AsymmetricViewCommand = new RelayCommand(o =>
            {
                CurrentView = AsymmetricVM;
            });
            DigSignatureCommand = new RelayCommand(o =>
            {
                CurrentView = DigSignatureVM;
            });
        }
    }
}

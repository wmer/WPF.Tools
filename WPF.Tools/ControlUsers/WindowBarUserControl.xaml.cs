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
using WPF.Tools.ControlUsers.ViewModels;

namespace WPF.Tools.ControlUsers {
    /// <summary>
    /// Interação lógica para WindowBarUserControl.xam
    /// </summary>
    public partial class WindowBarUserControl : UserControl {
        private MainWindowViewModel _mainWindowViewModel;
        public WindowBarUserControl() {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            _mainWindowViewModel = Resources["MainWindow"] as MainWindowViewModel;
            _mainWindowViewModel.MinimizeWindow.RaiseCanExecuteChanged();
            _mainWindowViewModel.MaximizeWindow.RaiseCanExecuteChanged();
            _mainWindowViewModel.CloaseWindow.RaiseCanExecuteChanged();
        }

        public static readonly DependencyProperty MainWindowProperty =
        DependencyProperty.Register("MainWindow", typeof(Window), typeof(WindowBarUserControl), null);

        public Window MainWindow {
            get => (Window)GetValue(MainWindowProperty);
            set { SetValue(MainWindowProperty, value);
            }
        }
    }
}

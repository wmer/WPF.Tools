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

namespace WPF.Tools.ControlUsers {
    /// <summary>
    /// Interação lógica para WindowBarUserControl.xam
    /// </summary>
    public partial class WindowBarUserControl : UserControl {
        public WindowBarUserControl() {
            InitializeComponent();
        }

        public static readonly DependencyProperty MainWindowProperty =
        DependencyProperty.Register("MainWindow", typeof(Window), typeof(WindowBarUserControl), null);

        public Window MainWindow {
            get => (Window)GetValue(MainWindowProperty);
            set => SetValue(MainWindowProperty, value);
        }
    }
}

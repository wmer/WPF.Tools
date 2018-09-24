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
using WPF.Tools.ControlUsers.Models;
using WPF.Tools.ControlUsers.ViewModels;
using WPF.Tools.Xaml;

namespace WPF.Tools.ControlUsers {
    /// <summary>
    /// Interação lógica para NavigationUserControl.xam
    /// </summary>
    public partial class NavigationUserControl : UserControl {
        public NavigationUserControl() {
            InitializeComponent();
            this.Loaded += NavigationUserControl_Loaded;
        }

        private void NavigationUserControl_Loaded(object sender, RoutedEventArgs e) {
            AddNavigationButton(null, "\uf0c9", "Menu");
        }


        public static readonly DependencyProperty RootFrameProperty =
           DependencyProperty.Register("RootFrame", typeof(Frame), typeof(NavigationUserControl), null);

        public Frame RootFrame {
            get => (Frame)GetValue(ContentProperty);
            set {
                SetValue(ContentProperty, value);
                AddFrame(value);
            }
        }

        private void AddFrame(Frame frame) {
            Content.Children.Add(frame);
        }

        public void AddNavigationButton<T>(string icon, string label) where T : Page =>
                        AddNavigationButton(typeof(T), icon, label);

        private void AddNavigationButton(Type type, string icon, string label) {
            var navigationViewModel = Resources["NavigationView"] as NavigationViewModel;
            var buttons = navigationViewModel.Buttons;
            buttons.Add(new MenuButton { Icon = icon, Label = label, Page = type });
            navigationViewModel.Buttons = buttons;
        }
    }
}

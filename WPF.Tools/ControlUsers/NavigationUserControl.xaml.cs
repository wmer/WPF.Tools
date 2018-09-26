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
            AddNavigationButton(null, "\uf0c9", "Menu");
        }

        public void AddNavigationButton<T>(string icon, string label) where T : Page =>
                        AddNavigationButton(typeof(T), icon, label);

        public void StarWithPage<T>() where T : Page {
            var navigationViewModel = Resources["NavigationView"] as NavigationViewModel;
            foreach (var btn in navigationViewModel.Buttons) {
                if (btn.Page != null && btn.Page.IsAssignableFrom(typeof(T))) {
                    navigationViewModel.SelectedButton = btn;
                }
            }
        }

        private void AddNavigationButton(Type type, string icon, string label) {
            var navigationViewModel = Resources["NavigationView"] as NavigationViewModel;
            var buttons = navigationViewModel.Buttons;
            buttons.Add(new MenuButton { Icon = icon, Label = label, Page = type });
            navigationViewModel.Buttons = buttons;
        }
    }
}

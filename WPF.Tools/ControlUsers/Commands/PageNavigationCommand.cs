using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Tools.ControlUsers.Events;
using WPF.Tools.ControlUsers.Models;
using WPF.Tools.ControlUsers.ViewModels;
using WPF.Tools.MVVM.Commands;
using WPF.Tools.Navigation;

namespace WPF.Tools.ControlUsers.Commands {
    public class PageNavigationCommand : CommandBase<NavigationViewModel> {
        private NavigationManager _navigationManager;

        public PageNavigationCommand(NavigationManager navigationManager) {
            _navigationManager = navigationManager;
        }

        public override bool CanExecute(NavigationViewModel parameter) =>
                                    parameter is NavigationViewModel navigationViewModel &&
                                    navigationViewModel.SelectedButton is MenuButton;

        public override void Execute(NavigationViewModel navigationView) {
            var menuButton = navigationView.SelectedButton;
            if (menuButton.Label == "Menu") {
                navigationView.Opened = !navigationView.Opened;
            }else {
                _navigationManager.Navigate(menuButton.Page, menuButton.Label);
            }
        }
    }

    public class GoBackCommand : CommandBase {
        public override bool CanExecute(object parameter) =>
                                        NavigationManager.CanGoBack();
        public override void Execute(object parameter) =>
                                        NavigationManager.GoBack();
    }
}

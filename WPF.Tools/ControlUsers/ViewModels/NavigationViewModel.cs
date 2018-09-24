using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPF.Tools.ControlUsers.Commands;
using WPF.Tools.ControlUsers.Models;
using WPF.Tools.MVVM.Commands;
using WPF.Tools.MVVM.ViewModel;
using WPF.Tools.Navigation;
using WPF.Tools.Navigation.Events;

namespace WPF.Tools.ControlUsers.ViewModels {
    public class NavigationViewModel : ViewModelBase {
        private PageNavigationCommand _pageNavigationCommand;
        private GoBackCommand _goBackCommand;
        private ObservableCollection<MenuButton> _buttons;
        private MenuButton _selectedButton;
        private Thickness _marginContent;
        private bool _opened;
        private bool _showDistractions;
        private bool _canGoBack;
        private Brush _backgroundColor;

        public NavigationViewModel() {
            _pageNavigationCommand = new PageNavigationCommand(new NavigationManager(new DependencyInjectionResolver.DependencyInjection()));
            _goBackCommand = new GoBackCommand();

            ShowDistractions = true;
            MarginContent = new Thickness(40, 40, 0, 0);
            BackgroundColor = new SolidColorBrush(Colors.Black);
            Buttons = new ObservableCollection<MenuButton>();

            NavigationEventHub.Navigated += OnNavigated;
        }

        public bool CanGoBack {
            get => _canGoBack;
            set {
                _canGoBack = value;
                OnPropertyChanged("CanGoBack");
            }
        }

        public bool Opened {
            get => _opened;
            set {
                _opened = value;
                OnPropertyChanged("Opened");
                if (_opened) {
                    BackgroundColor = new SolidColorBrush(Colors.Transparent);
                    MarginContent = new Thickness(270, 40, 0, 0);
                } else {
                    MarginContent = new Thickness(40, 40, 0, 0);
                    BackgroundColor = new SolidColorBrush(Colors.Black);
                }
            }
        }

        public Brush BackgroundColor {
            get { return _backgroundColor; }
            set {
                _backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }

        public bool ShowDistractions {
            get => _showDistractions;
            set {
                _showDistractions = value;
                OnPropertyChanged("ShowDistractions");
                Opened = false;
                if (!_showDistractions) {
                    MarginContent = new Thickness(0, 0, 0, 0);
                }
            }
        }

        public Thickness MarginContent {
            get { return _marginContent; }
            set {
                _marginContent = value;
                OnPropertyChanged("MarginContent");
            }
        }

        public MenuButton SelectedButton {
            get => _selectedButton;
            set {
                _selectedButton = value;
                OnPropertyChanged("SelectedButton");
            }
        }

        public ObservableCollection<MenuButton> Buttons {
            get => _buttons;
            set {
                _buttons = value;
                OnPropertyChanged("Buttons");
            }
        }

        public DelegateCommand<NavigationViewModel> GoToPage { get => _pageNavigationCommand.Command; }
        public GoBackCommand GoBack { get => _goBackCommand; }

        private void OnNavigated(object sender, global::WPF.Tools.Navigation.Events.NavigationEventArgs e) {
            CanGoBack = NavigationManager.CanGoBack();
            GoBack.RaiseCanExecuteChanged();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Tools.ControlUsers.Commands;
using WPF.Tools.MVVM.Commands;
using WPF.Tools.MVVM.ViewModel;
using WPF.Tools.Navigation.Events;

namespace WPF.Tools.ControlUsers.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        private DragWindowCommand _dragWindowCommand;
        private MinimizeWindowCommand _minimizeWindowCommand;
        private MaximizeWindowCommand _maximizeWindowCommand;
        private FullScreenCommand _fullScreenCommand;
        private CloseWindowCommand _closeWindowCommand;
        private NoDistractionsCommand _noDistractionsCommand;

        public MainWindowViewModel(
                    DragWindowCommand dragWindowCommand,
                    MinimizeWindowCommand minimizeWindowCommand,
                    MaximizeWindowCommand maximizeWindowCommand,
                    FullScreenCommand fullScreenCommand,
                    CloseWindowCommand closeWindowCommand,
                    NoDistractionsCommand noDistractionsCommand) {
            _dragWindowCommand = dragWindowCommand;
            _minimizeWindowCommand = minimizeWindowCommand;
            _maximizeWindowCommand = maximizeWindowCommand;
            _fullScreenCommand = fullScreenCommand;
            _closeWindowCommand = closeWindowCommand;
            _noDistractionsCommand = noDistractionsCommand;

            NavigationEventHub.Navigated += OnNavigated;
        }


        private string _pageTitle;

        public string PageTitle {
            get => _pageTitle;
            set {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public DelegateCommand<Window> DragWindow { get => _dragWindowCommand.Command; }
        public DelegateCommand<Window> MinimizeWindow { get => _minimizeWindowCommand.Command; }
        public DelegateCommand<Window> MaximizeWindow { get => _maximizeWindowCommand.Command; }
        public DelegateCommand<Window> FullScreen { get => _fullScreenCommand.Command; }
        public DelegateCommand<Window> CloaseWindow { get => _closeWindowCommand.Command; }
        public DelegateCommand<NavigationViewModel> NoDistractions { get => _noDistractionsCommand.Command; }

        private void OnNavigated(object sender, global::WPF.Tools.Navigation.Events.NavigationEventArgs e) {
            PageTitle = e.Title;
        }
    }
}

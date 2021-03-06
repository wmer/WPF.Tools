﻿using DependencyInjectionResolver.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DependencyInjectionResolver.Extensions;
using WPF.Tools.ControlUsers.Commands;
using WPF.Tools.MVVM.Commands;
using WPF.Tools.MVVM.ViewModel;
using WPF.Tools.Navigation.Events;

namespace WPF.Tools.ControlUsers.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        [Inject]
        private DragWindowCommand _dragWindowCommand;
        [Inject]
        private MinimizeWindowCommand _minimizeWindowCommand;
        [Inject]
        private MaximizeWindowCommand _maximizeWindowCommand;
        [Inject]
        private FullScreenCommand _fullScreenCommand;
        [Inject]
        private CloseWindowCommand _closeWindowCommand;
        [Inject]
        private NoDistractionsCommand _noDistractionsCommand;

        public MainWindowViewModel() {
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

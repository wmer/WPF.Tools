using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Tools.ControlUsers.Events;
using WPF.Tools.MVVM.ViewModel;

namespace WPF.Tools.ControlUsers.ViewModels {
    public class NoticeViewModel : ViewModelBase {
        private bool _visibility;
        private string _message;
        private int _total;
        private int _actualValue;

        public int Total {
            get => _total;
            set { _total = value;
                OnPropertyChanged("Total");
            }
        }

        public int ActualValue {
            get => _actualValue;
            set { _actualValue = value;
                OnPropertyChanged("ActualValue");
            }
        }

        public string Message {
            get => _message;
            set {
                _message = value;
                OnPropertyChanged("Message");
            }
        }


        public bool Visibility {
            get => _visibility;
            set {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        public NoticeViewModel() {
            NoticeEventHub.ProcessingStart += OnProcessingStart;
            NoticeEventHub.ProcessingProgress += OnProcessingProgress;
            NoticeEventHub.ProcessingEnd += OnProcessingEnd;
            NoticeEventHub.ProcessingError += OnProcessingError;
        }

        private void OnProcessingStart(object sender, ProcessingEventArgs ev) {
            Task.Run(() => {
                Visibility = true;
            });
        }

        private void OnProcessingProgress(object sender, ProcessingEventArgs ev) {
            Task.Run(() => {
                Visibility = true;
                Message = ev.StateMessage;
                Total = ev.Total;
                ActualValue = ev.ActualValue;
            });
        }

        private void OnProcessingEnd(object sender, ProcessingEventArgs ev) {
            Task.Run(() => {
                Visibility = false;
            });
        }

        private void OnProcessingError(object sender, ProcessingEventArgs ev) {
            Task.Run(() => {
                Visibility = true;
                Message = ev.StateMessage;
            });
        }
    }
}

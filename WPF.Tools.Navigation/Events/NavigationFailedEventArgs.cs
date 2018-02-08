using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Tools.Navigation.Events {
    public class NavigationFailedEventArgs : EventArgs {
        public string Title { get; set; }
        public Page FromPage { get; set; }
        public Type DestinationPageType { get; set; }
        public Exception Error { get; set; }
        public object ExtraContent { get; set; }

        public NavigationFailedEventArgs(string title, Page fromPage, Type destinationPageType, object extraContent, Exception error) {
            Title = title;
            FromPage = fromPage;
            DestinationPageType = destinationPageType;
            ExtraContent = extraContent;
            Error = error;
        }

        public NavigationFailedEventArgs(string title, Page fromPage, Type destinationPageType, Exception error) : this(title, fromPage, destinationPageType, null, error) {
        }

        public NavigationFailedEventArgs(string title, Type destinationPageType, object extraContent, Exception error) : this(title, null, destinationPageType, extraContent, error) {
        }

        public NavigationFailedEventArgs(string title, Type destinationPageType, Exception error) : this(title, destinationPageType, null, error) {
        }

        public NavigationFailedEventArgs(string title, Exception error) : this(title, null, error) {
        }

        public NavigationFailedEventArgs(Exception error) : this(null, error) {
        }
    }

    public delegate void NavigationFailedEventHandler(object sender, NavigationFailedEventArgs e);
}

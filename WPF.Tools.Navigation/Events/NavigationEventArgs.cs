using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Tools.Navigation.Events {
    public class NavigationEventArgs : EventArgs {
        public string Title { get; set; }
        public Page FromPage { get; set; }
        public Page ToPage { get; set; }
        public object ExtraContent { get; set; }

        public NavigationEventArgs(string title, Page fromPage, Page toPage, object extraContent) {
            Title = title;
            FromPage = fromPage;
            ToPage = toPage;
            ExtraContent = extraContent;
        }

        public NavigationEventArgs(string title, Page toPage, object extraContent) : this(title, null, toPage, extraContent) {
        }

        public NavigationEventArgs(string title, object extraContent) : this(title, null, extraContent) {
        }
    }

    public delegate void NavigationEventHandler(object sender, NavigationEventArgs e);
}

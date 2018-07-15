using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace WPF.Tools.MVVM.Commands {
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject> {
        RoutedEvent _routedEvent;

        public RoutedEvent RoutedEvent {
            get => _routedEvent;
            set { _routedEvent = value; }
        }

        public RoutedEventTrigger() {
        }

        protected override void OnAttached() {
            FrameworkElement associatedElement = base.AssociatedObject as FrameworkElement;

            if (base.AssociatedObject is Behavior behavior) {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }
            if (associatedElement == null) {
                throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
            }
            if (RoutedEvent != null) {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(this.OnRoutedEvent));
            }
        }

        void OnRoutedEvent(object sender, RoutedEventArgs args) => base.OnEvent(args);

        protected override string GetEventName() => RoutedEvent.Name;
    }
}

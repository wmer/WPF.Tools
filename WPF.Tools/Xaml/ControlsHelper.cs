using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.Tools.Xaml {
    public static class ControlsHelper {
        public static T Find<T>(string name) where T : DependencyObject {
            T element = null;
            if (FindInMainPage<T>(name) is T elW) {
                element = elW;
            } else if (FindInCurrentPage<T>(name) is T elP) {
                element = elP;
            } else if (FindChildControl<T>(GetCurrentPage(), name) is T elC) {
                element = elC;
            } else if (FindChildControl<T>(GetCurrentWindow(), name) is T elCM) {
                element = elCM;
            }

            return element;
        }

        public static T FindResource<T>(string key) {
            T resource = default(T);
            try {
                if (GetCurrentWindow().Resources[key] is T rs) {
                    resource = rs;
                } else if (GetCurrentPage() is Page page) {
                    resource = (T)page.Resources[key];
                }
            } catch (Exception) {
                try {
                    if (GetCurrentPage() is Page page) {
                        resource = (T)page.Resources[key];
                    }
                } catch {
                    // ignored
                }
            }

            return resource;
        }

        public static T Find<T>(this DependencyObject control, string name) where T : DependencyObject {
            T element = default(T);
            try {
                if (FindChildControl<T>(control, name) is T elC) {
                    element = elC;
                }
            } catch {
                // ignored
            }

            return element;
        }

        public static List<T> Find<T>(this DependencyObject control) where T : DependencyObject {
            var list = new List<T>();
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++) {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);

                if (child is T c) {
                    list.Add(c);
                } else {
                    list.AddRange(Find<T>(child));
                }

            }

            return list;
        }

        private static T FindInMainPage<T>(string name) where T : DependencyObject {
            T element = null;
            element = GetCurrentWindow().FindName(name) as T;
            return element;
        }

        private static T FindInCurrentPage<T>(string name) where T : DependencyObject {
            T element = null;
            if (GetCurrentPage() is Page page) {
                element = page.FindName(name) as T;
            }
            return element;
        }

        public static Window GetCurrentWindow() {
            return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        }

        public static Page GetCurrentPage() {
            if (GetCurrentWindow().Find<Page>().FirstOrDefault() is Page page) {
                return page;
            }
            return null;
        }

        private static DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName) {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++) {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                if (fe == null) return null;
                if (fe.Name == ctrlName) {
                    return child;
                }

                if (child is T && fe.Name == ctrlName) {
                    return child;
                } else {
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }
    }
}

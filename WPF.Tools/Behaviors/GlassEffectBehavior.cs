using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using WPF.Tools.Helpers;

namespace WPF.Tools.Behaviors {
    public class GlassEffectBehavior : Behavior<Window> {

        protected override void OnAttached() {
            AssociatedObject.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            SetWindowTransparence();
        }

        private void SetWindowTransparence() {
            var windowHelper = new WindowInteropHelper(AssociatedObject);

            var accent = new NonClientRegionAPI.AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);
            accent.AccentState = NonClientRegionAPI.AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new NonClientRegionAPI.WindowCompositionAttributeData();
            data.Attribute = NonClientRegionAPI.WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            NonClientRegionAPI.SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
    }
}

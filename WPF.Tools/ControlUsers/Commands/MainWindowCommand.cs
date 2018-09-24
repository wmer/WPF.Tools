using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Tools.MVVM.Commands;

namespace WPF.Tools.ControlUsers.Commands {
    public class DragWindowCommand : CommandBase<Window> {
        public override void Execute(Window window) {
            try {
                window.DragMove();
            } catch { }
        }
    }

    public class MinimizeWindowCommand : CommandBase<Window> {
        public override void Execute(Window window) =>
                        window.WindowState = WindowState.Minimized;
    }

    public class MaximizeWindowCommand : CommandBase<Window> {
        public override void Execute(Window window) {
            if (window.Width == SystemParameters.PrimaryScreenWidth &&
                window.Height == SystemParameters.PrimaryScreenHeight - 40) {
                window.ResizeMode = ResizeMode.CanResize;
                window.WindowState = WindowState.Normal;
                window.Width = 900;
                window.Height = 600;
            } else {
                //window.WindowState = WindowState.Maximized;
                window.Left = 0;
                window.Top = 0;
                window.ResizeMode = ResizeMode.CanResize;
                window.Width = SystemParameters.PrimaryScreenWidth;
                window.Height = SystemParameters.PrimaryScreenHeight - 40;
            }

        }
    }

    public class FullScreenCommand : CommandBase<Window> {
        public override void Execute(Window window) {
            if (window.WindowState == WindowState.Normal) {
                //window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.NoResize;
                window.WindowState = WindowState.Maximized;
                window.Left = 0;
                window.Top = 0;
                window.Width = SystemParameters.FullPrimaryScreenWidth;
                window.Height = SystemParameters.FullPrimaryScreenHeight;
                window.Topmost = true;

            } else if (window.WindowState == WindowState.Maximized) {
                window.ResizeMode = ResizeMode.CanResize;
                window.WindowState = WindowState.Normal;
                window.Left = 10;
                window.Top = 10;
                window.Width = 900;
                window.Height = 600;
                window.Topmost = false;
            }
        }
    }

    public class CloseWindowCommand : CommandBase<Window> {
        public override void Execute(Window window) => window.Close();
    }
}

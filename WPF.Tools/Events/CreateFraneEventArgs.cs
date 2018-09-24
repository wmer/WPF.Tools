using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Tools.Events {
    public  class CreateFraneEventArgs : EventArgs {
        public Frame Frame { get; set; }

        public CreateFraneEventArgs(Frame frame) {
            Frame = frame;
        }
    }

    public delegate void CreateFraneEventHandler(object sender, CreateFraneEventArgs e);
}

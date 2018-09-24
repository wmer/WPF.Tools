using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Tools.Events {
    public class WpfToolsEventHub {
        public static event CreateFraneEventHandler CreateFrame;

        public static void OnCreateFrame(object sender, CreateFraneEventArgs e) =>
                                                            CreateFrame.Invoke(sender, e);
    }
}

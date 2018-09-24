using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Tools.ControlUsers.ViewModels;
using WPF.Tools.MVVM.Extra;

namespace WPF.Tools.ControlUsers.Extra {
    internal class CustomResourceDictionary : ResourceDictionary {
        public override void RegisterResources() {
            Register<NavigationViewModel>("NavigationView");
        }
    }
}

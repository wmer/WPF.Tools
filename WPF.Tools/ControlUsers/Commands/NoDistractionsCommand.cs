using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Tools.ControlUsers.ViewModels;
using WPF.Tools.MVVM.Commands;

namespace WPF.Tools.ControlUsers.Commands {
    public class NoDistractionsCommand : CommandBase<NavigationViewModel> {
        public override void Execute(NavigationViewModel parameter) =>
                                        parameter.ShowDistractions = !parameter.ShowDistractions;
    }
}

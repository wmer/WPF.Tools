using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Tools.ControlUsers.Events {
    public class ProcessingEventArgs : EventArgs {
        public DateTime Time { get; private set; }
        public string Message { get; set; }
        public String StateMessage { get; private set; }
        public int Total { get; set; }
        public int ActualValue { get; set; }

        public ProcessingEventArgs(DateTime time) : this(time, "Aguarde...") {
        }

        public ProcessingEventArgs(DateTime time, string message) : this(time, message, null) {
        }

        public ProcessingEventArgs(DateTime time, string message, String stateMessage) : this(time, message, stateMessage, 0) {
        }

        public ProcessingEventArgs(DateTime time, string message,  String stateMessage, int total) : this(time, message, stateMessage, total, 0) {
        }

        public ProcessingEventArgs(DateTime time, string message, String stateMessage, int total, int actualValue) {
            Time = time;
            Message = message;
            StateMessage = stateMessage;
            Total = total;
            ActualValue = actualValue;
        }
    }

    public delegate void ProcessingEventHandler(object sender, ProcessingEventArgs ev);
}

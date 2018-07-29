using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Tools.ControlUsers.Events {
    public static class NoticeEventHub {
        public static event ProcessingEventHandler ProcessingStart;
        public static event ProcessingEventHandler ProcessingEnd;
        public static event ProcessingEventHandler ProcessingProgress;
        public static event ProcessingEventHandler ProcessingError;

        public static void OnProcessingStart(object sender, ProcessingEventArgs e) => 
                                                                    ProcessingStart?.Invoke(sender, e);

        public static void OnProcessingProgress(object sender, ProcessingEventArgs e) => 
                                                                    ProcessingProgress?.Invoke(sender, e);

        public static void OnProcessingEnd(object sender, ProcessingEventArgs e) => 
                                                                    ProcessingEnd?.Invoke(sender, e);

        public static void OnProcessingProgressError(object sender, ProcessingEventArgs e) => 
                                                                    ProcessingError?.Invoke(sender, e);
    }
}

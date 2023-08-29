using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamMicMonitor
{
  static class Program
  {
    static void Main()
    {
      //Ensure that there isn't another instance of the application running
      Process[] processes = Process.GetProcesses();
      Process curProcess = Process.GetCurrentProcess();
      foreach (Process process in processes)
        if (process.ProcessName == curProcess.ProcessName && process.Id != curProcess.Id)
          return;

      // Enable XP theming
      Application.EnableVisualStyles();
      Application.DoEvents();

      //Create a new applciationContext
      WebCamMicMonitorContext applicationContext = WebCamMicMonitorContext.Instance;
      if (applicationContext != null)
        Application.Run(applicationContext);
    }
  }
}

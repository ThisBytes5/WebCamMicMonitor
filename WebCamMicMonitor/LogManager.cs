using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryMonitorDemo
{
  internal class LogManager
  {
    public static LogManager Instance = new LogManager();
    public delegate void LogEventHandler(object sender, string message);
    public LogEventHandler LogEvent;
    public static List<string> LogItems = new List<string>();

    private LogManager()
    {

    }

    public static void Log(string message)
    {
      if (LogItems.Count > 100)
        LogItems.RemoveAt(0);
      LogItems.Add(message);
      Instance.OnLog(message);
    }

    private void OnLog(string message)
    {
      if (LogEvent != null)
        LogEvent(this, message);
    }
  }
}

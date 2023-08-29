using Flurl.Http;
using Microsoft.Win32;
using RegistryUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamMicMonitor
{
  public static class MonitoringManager
  {
    private static List<RegistryMonitor> registryMonitors = new List<RegistryMonitor>();

    public static void StartMonitoring()
    {
      registryMonitors.Clear();
      RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam", false);
      CreateMonitors(reg, "Camera");

      reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone", false);
      CreateMonitors(reg, "Mic");

      SetCameraMicStatus();
    }

    public static void StopMonitoring()
    {
      foreach (RegistryMonitor registryMonitor in registryMonitors)
      {
        if (registryMonitor != null)
        {
          registryMonitor.Stop();
          registryMonitor.RegChanged -= new EventHandler<RegChangedEventArgs>(OnRegChanged);
          registryMonitor.Error -= new System.IO.ErrorEventHandler(OnError);

          LogManager.Log("Monitoring stopped");
        }
      }
    }

    private static void CreateMonitors(RegistryKey key, string id)
    {
      if (key == null)
        return;

      if (key.SubKeyCount == 0 && (long)Registry.GetValue(key.Name, "LastUsedTimeStop", (long)1) != 1)
      {
        RegistryMonitor registryMonitor = new RegistryMonitor(key.Name, id);
        registryMonitor.RegChanged += new EventHandler<RegChangedEventArgs>(OnRegChanged);
        registryMonitor.Error += new System.IO.ErrorEventHandler(OnError);
        registryMonitor.Start();
        registryMonitors.Add(registryMonitor);
      }
      else
        foreach (string subName in key.GetSubKeyNames())
          CreateMonitors(key.OpenSubKey(subName), id);
    }

    private static void SetCameraMicStatus()
    {
      bool cameraOn = false;
      bool micOn = false;
      string micApp = string.Empty;
      string cameraApp = string.Empty;
      foreach (RegistryMonitor registryMonitor in registryMonitors)
      {
        if (registryMonitor.ID == "Mic")
        {
          if ((long)Registry.GetValue(registryMonitor.RegistryKey, "LastUsedTimeStop", (long)1) == 0)
          {
            micOn = true;
            micApp = registryMonitor.RegistryKey; //Need to work on parsing the Reg Key to display the app that has the device in use.
          }
        }

        if (registryMonitor.ID == "Camera")
        {
          if ((long)Registry.GetValue(registryMonitor.RegistryKey, "LastUsedTimeStop", (long)1) == 0)
          {
            cameraOn = true;
            cameraApp = registryMonitor.RegistryKey;
          }
        }
      }

      LogManager.Log($"Camera = {cameraOn}");
      LogManager.Log($"Mic = {micOn}");

      Settings.PostUrl.PostJsonAsync(new { mic = micOn, camera = cameraOn }).Wait();
    }

    private static void OnRegChanged(object sender, RegChangedEventArgs e)
    {
      SetCameraMicStatus();
    }

    private static void OnError(object sender, ErrorEventArgs e)
    {
      LogManager.Log("ERROR: " + e.GetException().Message);
      MonitoringManager.StopMonitoring();
    }
  }
}

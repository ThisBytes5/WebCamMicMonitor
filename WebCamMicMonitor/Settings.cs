using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace RegistryMonitorDemo
{
  public static class Settings
  {
    private static FileInfo settingsFile;
    private static SettingsData data;
    private const string appName = "WebCamMicMonitor";

    public static bool StartMinimized
    {
      get { return data.StartMinimized; }
      set => data.StartMinimized = value;
    }

    public static bool AutoStart
    {
      get { return data.AutoStart; }
      set => data.AutoStart = value;
    }

    public static string PostUrl
    {
      get { return data.HostUrl; }
      set { data.HostUrl = value; }
    }

    static Settings()
    {
      string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      fileName = Path.Combine(fileName, appName, "settings.json");
      settingsFile = new FileInfo(fileName);
      LoadSettings();
    }

    internal static void LoadSettings()
    {
      if (settingsFile.Exists)
      {
        string fileContents = File.ReadAllText(settingsFile.FullName);
        data = JsonConvert.DeserializeObject<SettingsData>(fileContents);
      }
      else
        data = new SettingsData();
    }

    internal static void SaveSettings()
    {
      RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      if (key.GetValueNames().Contains(appName) && !data.AutoStart)
        key.DeleteValue(appName);
      else
      if (!key.GetValueNames().Contains(appName) && data.AutoStart)
        key.SetValue(appName, System.Reflection.Assembly.GetExecutingAssembly().Location);


      settingsFile.Directory.Create();
      System.IO.File.WriteAllText(settingsFile.FullName, JsonConvert.SerializeObject(data));
    }

    private class SettingsData
    {
      public bool StartMinimized { get; set; } = true;
      public string HostUrl { get; set; }
      public bool AutoStart { get; set; } = true;
    }
  }
}

using System;
using System.Windows.Forms;
using static RegistryMonitorDemo.LogManager;

namespace RegistryMonitorDemo
{
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
      LogManager.Instance.LogEvent += UpdateLog;
      UpdateLog(null, string.Empty);
    }

    private void UpdateLog(object sender, string message)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new LogEventHandler(UpdateLog), new object[] { sender, message });
        return;
      }

      LogListBox.BeginUpdate();
      try
      {
        LogListBox.Items.Clear();
        LogManager.LogItems.ForEach(item => { LogListBox.Items.Add(item); });
      }
      finally
      {
        LogListBox.EndUpdate();
      }
    }

    private void saveBTN_Click(object sender, EventArgs e)
    {
      Settings.PostUrl = postURLTxt.Text;
      Settings.StartMinimized = startMinimizedCB.Checked;
      Settings.AutoStart = autoStartCB.Checked;
      Settings.SaveSettings();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
      postURLTxt.Text = Settings.PostUrl;
      startMinimizedCB.Checked = Settings.StartMinimized;
      autoStartCB.Checked = Settings.AutoStart;
    }
  }
}

using Flurl.Http;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using RegistryUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryMonitorDemo
{
  public class WebCamMicMonitorContext : ApplicationContext
  {
    private System.ComponentModel.IContainer components;						// a list of components to dispose when the context is disposed
    private NotifyIcon notifyIcon;				// the icon that sits in the system tray
    private ContextMenuStrip notifyIconContextMenu;	// the context menu for the notify icon
    private ToolStripMenuItem settingsContextMenuItem;			// open menu command for context menu 	
    private ToolStripMenuItem exitContextMenuItem;			// exit menu command for context menu 
    private Form settingsForm = null;						// the current form we're displaying
    private static WebCamMicMonitorContext instance = null;

    public static WebCamMicMonitorContext Instance
    {
      get
      {
        if (instance == null)
          instance = new WebCamMicMonitorContext();
        return instance;
      }
    }

    private WebCamMicMonitorContext()
    {
      // create the notify icon and it's associated context menu
      InitializeContext();
      Settings.LoadSettings();

      if (!string.IsNullOrEmpty(Settings.PostUrl))
        MonitoringManager.StartMonitoring();

      if (!Settings.StartMinimized || string.IsNullOrEmpty(Settings.PostUrl))
        ShowSettingsForm();
    }

    private void InitializeContext()
    {
      FileInfo AppFileInfo = new FileInfo(Application.ExecutablePath);

      this.components = new System.ComponentModel.Container();
      this.notifyIcon = new NotifyIcon(this.components);
      this.notifyIconContextMenu = new ContextMenuStrip();
      this.settingsContextMenuItem = new ToolStripMenuItem();
      this.exitContextMenuItem = new ToolStripMenuItem();

      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
      this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
      this.notifyIcon.Icon = new Icon(typeof(WebCamMicMonitorContext), "App.ico");
      this.notifyIcon.Text = DateTime.Now.ToLongDateString();
      this.notifyIcon.Visible = true;

      // 
      // notifyIconContextMenu
      // 
      this.notifyIconContextMenu.Items.AddRange(new ToolStripItem[] { settingsContextMenuItem, exitContextMenuItem });

      // 
      // settingsContextMenuItem
      // 			
      this.settingsContextMenuItem.Text = "&Settings";
      this.settingsContextMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.settingsContextMenuItem.Click += new System.EventHandler(this.SettingsContextMenuItem_Click);

      // 
      // 
      //this.exitContextMenuItem.Index = notifyIconContextMenu.MenuItems.Count -1;
      this.exitContextMenuItem.Text = "&Exit";
      this.exitContextMenuItem.Click += new System.EventHandler(this.ExitContextMenuItem_Click);
    }

    private void NotifyIcon_DoubleClick(object sender, EventArgs e)
    {
      ShowSettingsForm();
    }

    private void ExitContextMenuItem_Click(object sender, EventArgs e)
    {
      settingsForm?.Close();
      Application.DoEvents();
      ExitThread();
    }

    #region Header
    /// <summary>
    /// Displays the settings form, will create the form if it has not already been created.
    /// </summary>
    #endregion

    private void ShowSettingsForm()
    {
      if (settingsForm == null)
      {
        // create a new Settings form and show it.
        settingsForm = new SettingsForm();

        // hook onto the closed event so we can null out the main form...  this avoids reshowing
        // a disposed form.
        settingsForm.Closed += new EventHandler(SettingsForm_Closed);
        settingsForm.ShowDialog();
      }
      else
      {
        // the form is currently visible, go ahead and bring it to the front so the user can interact
        settingsForm.Activate();
      }
    }

    private void SettingsForm_Closed(object sender, EventArgs e)
    {
      // null out the main form so we know to create a new one.      
      this.settingsForm = null;
    }

    private void SettingsContextMenuItem_Click(object sender, EventArgs e)
    {
      ShowSettingsForm();
    }
  }
}
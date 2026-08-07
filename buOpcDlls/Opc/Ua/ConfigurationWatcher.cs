// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfigurationWatcher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ConfigurationWatcher : IDisposable
{
  private readonly object m_lock = new object();
  private ApplicationConfiguration m_configuration;
  private Timer m_watcher;
  private DateTime m_lastWriteTime;

  public ConfigurationWatcher(ApplicationConfiguration configuration)
  {
    FileInfo fileInfo = configuration != null ? new FileInfo(configuration.SourceFilePath) : throw new ArgumentNullException(nameof (configuration));
    if (!fileInfo.Exists)
      throw new FileNotFoundException("Could not load configuration file", configuration.SourceFilePath);
    this.m_configuration = configuration;
    this.m_lastWriteTime = fileInfo.LastWriteTimeUtc;
    this.m_watcher = new Timer(new TimerCallback(this.Watcher_Changed), (object) null, 5000, 5000);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.m_watcher == null)
      return;
    this.m_watcher.Dispose();
    this.m_watcher = (Timer) null;
  }

  public event EventHandler<ConfigurationWatcherEventArgs> Changed
  {
    add
    {
      lock (this.m_lock)
        this.m_Changed += value;
    }
    remove
    {
      lock (this.m_lock)
        this.m_Changed -= value;
    }
  }

  private void Watcher_Changed(object state)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(this.m_configuration.SourceFilePath);
      if (!fileInfo.Exists || fileInfo.LastWriteTimeUtc <= this.m_lastWriteTime)
        return;
      this.m_lastWriteTime = fileInfo.LastWriteTimeUtc;
      EventHandler<ConfigurationWatcherEventArgs> changed = this.m_Changed;
      if (changed == null)
        return;
      changed((object) this, new ConfigurationWatcherEventArgs(this.m_configuration, this.m_configuration.SourceFilePath));
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error raising configuration file changed event.", objArray);
    }
  }

  private event EventHandler<ConfigurationWatcherEventArgs> m_Changed;
}

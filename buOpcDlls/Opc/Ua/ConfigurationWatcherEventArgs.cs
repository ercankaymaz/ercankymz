// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfigurationWatcherEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ConfigurationWatcherEventArgs : EventArgs
{
  private ApplicationConfiguration m_configuration;
  private string m_filePath;

  public ConfigurationWatcherEventArgs(ApplicationConfiguration configuration, string filePath)
  {
    this.m_configuration = configuration;
    this.m_filePath = filePath;
  }

  public ApplicationConfiguration Configuration => this.m_configuration;

  public string FilePath => this.m_filePath;
}

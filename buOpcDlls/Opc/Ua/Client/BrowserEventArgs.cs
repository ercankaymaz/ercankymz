// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.BrowserEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class BrowserEventArgs : EventArgs
{
  private bool m_cancel;
  private bool m_continueUntilDone;
  private ReferenceDescriptionCollection m_references;

  internal BrowserEventArgs(ReferenceDescriptionCollection references)
  {
    this.m_references = references;
  }

  public bool Cancel
  {
    get => this.m_cancel;
    set => this.m_cancel = value;
  }

  public bool ContinueUntilDone
  {
    get => this.m_continueUntilDone;
    set => this.m_continueUntilDone = value;
  }

  public ReferenceDescriptionCollection References => this.m_references;
}

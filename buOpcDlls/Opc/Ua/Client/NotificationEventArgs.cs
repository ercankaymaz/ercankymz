// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.NotificationEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class NotificationEventArgs : EventArgs
{
  private readonly Subscription m_subscription;
  private readonly NotificationMessage m_notificationMessage;
  private readonly IList<string> m_stringTable;

  internal NotificationEventArgs(
    Subscription subscription,
    NotificationMessage notificationMessage,
    IList<string> stringTable)
  {
    this.m_subscription = subscription;
    this.m_notificationMessage = notificationMessage;
    this.m_stringTable = stringTable;
  }

  public Subscription Subscription => this.m_subscription;

  public NotificationMessage NotificationMessage => this.m_notificationMessage;

  public IList<string> StringTable => this.m_stringTable;
}

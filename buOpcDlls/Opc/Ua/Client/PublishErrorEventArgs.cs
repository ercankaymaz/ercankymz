// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.PublishErrorEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class PublishErrorEventArgs : EventArgs
{
  private readonly uint m_subscriptionId;
  private readonly uint m_sequenceNumber;
  private readonly ServiceResult m_status;

  internal PublishErrorEventArgs(ServiceResult status) => this.m_status = status;

  internal PublishErrorEventArgs(ServiceResult status, uint subscriptionId, uint sequenceNumber)
  {
    this.m_status = status;
    this.m_subscriptionId = subscriptionId;
    this.m_sequenceNumber = sequenceNumber;
  }

  public ServiceResult Status => this.m_status;

  public uint SubscriptionId => this.m_subscriptionId;

  public uint SequenceNumber => this.m_sequenceNumber;
}

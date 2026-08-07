// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.PublishSequenceNumbersToAcknowledgeEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class PublishSequenceNumbersToAcknowledgeEventArgs : EventArgs
{
  private readonly SubscriptionAcknowledgementCollection m_acknowledgementsToSend;
  private readonly SubscriptionAcknowledgementCollection m_deferredAcknowledgementsToSend;

  internal PublishSequenceNumbersToAcknowledgeEventArgs(
    SubscriptionAcknowledgementCollection acknowledgementsToSend,
    SubscriptionAcknowledgementCollection deferredAcknowledgementsToSend)
  {
    this.m_acknowledgementsToSend = acknowledgementsToSend;
    this.m_deferredAcknowledgementsToSend = deferredAcknowledgementsToSend;
  }

  public SubscriptionAcknowledgementCollection AcknowledgementsToSend
  {
    get => this.m_acknowledgementsToSend;
  }

  public SubscriptionAcknowledgementCollection DeferredAcknowledgementsToSend
  {
    get => this.m_deferredAcknowledgementsToSend;
  }
}

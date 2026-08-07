// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IChannelBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IChannelBase
{
  bool UseBinaryEncoding { get; }

  void ScheduleOutgoingRequest(IChannelOutgoingRequest request);

  InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);

  IAsyncResult BeginInvokeService(
    InvokeServiceMessage request,
    AsyncCallback callback,
    object asyncState);

  InvokeServiceResponseMessage EndInvokeService(IAsyncResult result);
}

// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UaChannelBase`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class UaChannelBase<TChannel> : UaChannelBase where TChannel : class, IChannelBase
{
  private TChannel m_channel;

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      Utils.SilentDispose((object) this.m_channel);
      this.m_channel = default (TChannel);
    }
    base.Dispose(disposing);
  }

  public override InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock ((object) this.Channel)
      result = this.Channel.BeginInvokeService(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndInvokeService(result);
  }

  public override IAsyncResult BeginInvokeService(
    InvokeServiceMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<TChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<TChannel>.UaChannelAsyncResult(this.m_channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginInvokeService(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public override InvokeServiceResponseMessage EndInvokeService(IAsyncResult result)
  {
    UaChannelBase<TChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<TChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndInvokeService(channelAsyncResult.InnerResult);
  }

  public override void Reconnect()
  {
    if (this.m_uaBypassChannel != null)
      this.m_uaBypassChannel.Reconnect();
    else
      Utils.LogInfo("RECONNECT: Reconnecting to {0}.", (object) this.m_settings.Description.EndpointUrl);
  }

  public override void Reconnect(ITransportWaitingConnection connection)
  {
    throw new NotImplementedException("Reconnect for waiting connections is not supported for this channel");
  }

  protected TChannel Channel => this.m_channel;

  protected class UaChannelAsyncResult : AsyncResultBase
  {
    private TChannel m_channel;

    public UaChannelAsyncResult(TChannel channel, AsyncCallback callback, object callbackData)
      : base(callback, callbackData, 0)
    {
      this.m_channel = channel;
    }

    public TChannel Channel => this.m_channel;

    public void OnOperationCompleted(IAsyncResult ar)
    {
      try
      {
        lock (this.Lock)
        {
          if (this.InnerResult == null)
            this.InnerResult = ar;
        }
        this.OperationCompleted();
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected exception invoking UaChannelAsyncResult callback function.", objArray);
      }
    }

    public static UaChannelBase<TChannel>.UaChannelAsyncResult WaitForComplete(IAsyncResult ar)
    {
      if (!(ar is UaChannelBase<TChannel>.UaChannelAsyncResult channelAsyncResult))
        throw new ArgumentException("End called with an invalid IAsyncResult object.", nameof (ar));
      return channelAsyncResult.WaitForComplete() ? channelAsyncResult : throw new ServiceResultException(2148139008U /*0x800A0000*/);
    }
  }
}

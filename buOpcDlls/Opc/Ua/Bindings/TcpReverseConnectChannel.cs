// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpReverseConnectChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpReverseConnectChannel(
  string contextId,
  ITcpChannelListener listener,
  BufferManager bufferManager,
  ChannelQuotas quotas,
  EndpointDescriptionCollection endpoints) : TcpListenerChannel(contextId, listener, bufferManager, quotas, (X509Certificate2) null, (X509Certificate2Collection) null, endpoints)
{
  public override string ChannelName => "TCPREVERSECONNECTCHANNEL";

  protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    lock (this.DataLock)
    {
      this.SetResponseRequired(true);
      try
      {
        if (messageType == 1178945618U)
        {
          Utils.LogInfo("ChannelId {0}: ProcessReverseHelloMessage", (object) this.ChannelId);
          return this.ProcessReverseHelloMessage(messageType, messageChunk);
        }
        this.ForceChannelFault(2155741184U /*0x807E0000*/, "The reverse connect handler does not recognize the message type: {0:X8}.", (object) messageType);
        return false;
      }
      finally
      {
        this.SetResponseRequired(false);
      }
    }
  }

  private bool ProcessReverseHelloMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    if (this.State != TcpChannelState.Connecting)
    {
      this.ForceChannelFault(2155741184U /*0x807E0000*/, "Client sent an unexpected ReverseHello message.");
      return false;
    }
    try
    {
      MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, false);
      BinaryDecoder binaryDecoder = new BinaryDecoder((Stream) memoryStream, this.Quotas.MessageContext);
      memoryStream.Seek(8L, SeekOrigin.Current);
      string serverUri = binaryDecoder.ReadString((string) null);
      Uri endpointUri = new Uri(binaryDecoder.ReadString((string) null));
      this.State = TcpChannelState.Connecting;
      Task.Run((Func<Task>) (async () =>
      {
        try
        {
          if (!await this.Listener.TransferListenerChannel(this.Id, serverUri, endpointUri).ConfigureAwait(false))
          {
            this.SetResponseRequired(true);
            this.ForceChannelFault(2155741184U /*0x807E0000*/, "The reverse connection was rejected by the client.");
          }
          else
            this.CleanupTimer();
        }
        catch (Exception ex)
        {
          this.SetResponseRequired(true);
          this.ForceChannelFault(2147614720U /*0x80020000*/, "Internal error approving the reverse connection.");
        }
      }));
    }
    catch (Exception ex)
    {
      this.ForceChannelFault(ex, 2156003328U /*0x80820000*/, "Unexpected error while processing a ReverseHello message.");
    }
    return false;
  }
}

// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegistrationChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegistrationChannel : 
  UaChannelBase<IRegistrationChannel>,
  IRegistrationChannel,
  IChannelBase
{
  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    IServiceMessageContext messageContext)
  {
    ITransportChannel transportChannel = UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, messageContext);
    if (transportChannel == null)
    {
      Uri url = new Uri(description.EndpointUrl);
      transportChannel = (ITransportChannel) new RegistrationChannel();
      transportChannel.Initialize(url, new TransportChannelSettings()
      {
        Configuration = endpointConfiguration,
        Description = description,
        ClientCertificate = clientCertificate
      });
    }
    return transportChannel;
  }

  internal RegistrationChannel()
  {
  }

  public RegisterServerResponseMessage RegisterServer(RegisterServerMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginRegisterServer(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndRegisterServer(result);
  }

  public IAsyncResult BeginRegisterServer(
    RegisterServerMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginRegisterServer(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public RegisterServerResponseMessage EndRegisterServer(IAsyncResult result)
  {
    UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndRegisterServer(channelAsyncResult.InnerResult);
  }

  public Task<RegisterServerResponseMessage> RegisterServerAsync(RegisterServerMessage request)
  {
    return this.Channel.RegisterServerAsync(request);
  }

  public RegisterServer2ResponseMessage RegisterServer2(RegisterServer2Message request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginRegisterServer2(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndRegisterServer2(result);
  }

  public IAsyncResult BeginRegisterServer2(
    RegisterServer2Message request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginRegisterServer2(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result)
  {
    UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<IRegistrationChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndRegisterServer2(channelAsyncResult.InnerResult);
  }

  public Task<RegisterServer2ResponseMessage> RegisterServer2Async(RegisterServer2Message request)
  {
    return this.Channel.RegisterServer2Async(request);
  }
}

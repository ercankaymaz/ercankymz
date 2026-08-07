// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ClientBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ClientBase : IClientBase, IDisposable
{
  private readonly object m_lock = new object();
  private ITransportChannel m_channel;
  private NodeId m_authenticationToken;
  private DiagnosticsMasks m_returnDiagnostics;
  private int m_nextRequestHandle;
  private int m_pendingRequestCount;
  private bool m_disposed;
  private bool m_useTransportChannel;

  public ClientBase(ITransportChannel channel)
  {
    if (channel == null)
      throw new ArgumentNullException(nameof (channel));
    this.InitializeChannel(channel);
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    this.CloseChannel();
    this.m_disposed = true;
  }

  public EndpointDescription Endpoint => this.TransportChannel?.EndpointDescription;

  public EndpointConfiguration EndpointConfiguration
  {
    get => this.TransportChannel?.EndpointConfiguration;
  }

  public IServiceMessageContext MessageContext => this.TransportChannel?.MessageContext;

  public ITransportChannel TransportChannel
  {
    get
    {
      ITransportChannel channel = this.m_channel;
      return channel == null || !this.m_disposed ? channel : throw new ObjectDisposedException("ClientBase has been disposed.");
    }
    protected set
    {
      if (this.m_channel == value)
        return;
      ITransportChannel channel = this.m_channel;
      this.m_channel = (ITransportChannel) null;
      if (channel != null)
      {
        try
        {
          channel.Close();
          channel.Dispose();
        }
        catch
        {
        }
      }
      this.m_channel = value;
    }
  }

  internal IChannelBase InnerChannel
  {
    get => this.TransportChannel != null ? this.m_channel as IChannelBase : (IChannelBase) null;
  }

  public DiagnosticsMasks ReturnDiagnostics
  {
    get => this.m_returnDiagnostics;
    set => this.m_returnDiagnostics = value;
  }

  public int OperationTimeout
  {
    get => this.TransportChannel != null ? this.m_channel.OperationTimeout : 0;
    set
    {
      if (this.TransportChannel == null)
        return;
      this.m_channel.OperationTimeout = value;
    }
  }

  protected bool UseTransportChannel
  {
    get
    {
      if (this.TransportChannel == null)
        throw new ObjectDisposedException("TransportChannel is not available.");
      return this.m_useTransportChannel;
    }
  }

  public void AttachChannel(ITransportChannel channel) => this.InitializeChannel(channel);

  public void DetachChannel() => this.m_channel = (ITransportChannel) null;

  public virtual StatusCode Close()
  {
    if (this.m_channel != null)
    {
      this.m_channel.Close();
      this.m_channel = (ITransportChannel) null;
    }
    this.m_authenticationToken = (NodeId) null;
    return (StatusCode) 0U;
  }

  public virtual async Task<StatusCode> CloseAsync(CancellationToken ct = default (CancellationToken))
  {
    if (this.m_channel != null)
    {
      await this.m_channel.CloseAsync(ct).ConfigureAwait(false);
      this.m_channel = (ITransportChannel) null;
    }
    this.m_authenticationToken = (NodeId) null;
    return (StatusCode) 0U;
  }

  public bool Disposed => this.m_disposed;

  public uint NewRequestHandle() => (uint) Utils.IncrementIdentifier(ref this.m_nextRequestHandle);

  protected void InitializeChannel(ITransportChannel channel)
  {
    this.m_channel = channel;
    this.m_useTransportChannel = true;
    if (!(channel is UaChannelBase uaChannelBase))
      return;
    this.m_useTransportChannel = uaChannelBase.m_uaBypassChannel != null || uaChannelBase.UseBinaryEncoding;
  }

  protected void CloseChannel()
  {
    if (this.m_channel == null)
      return;
    try
    {
      this.m_channel.Close();
    }
    catch
    {
    }
    this.DisposeChannel();
  }

  protected void DisposeChannel()
  {
    if (this.m_channel == null)
      return;
    try
    {
      this.m_channel.Dispose();
    }
    catch
    {
    }
    this.m_channel = (ITransportChannel) null;
  }

  protected object SyncRoot => this.m_lock;

  protected NodeId AuthenticationToken
  {
    get => this.m_authenticationToken;
    set => this.m_authenticationToken = value;
  }

  [Obsolete("Must override the version with useDefault parameter.")]
  protected virtual void UpdateRequestHeader(IServiceRequest request)
  {
    this.UpdateRequestHeader(request, request == null);
  }

  protected virtual void UpdateRequestHeader(IServiceRequest request, bool useDefaults)
  {
    lock (this.m_lock)
    {
      if (request.RequestHeader == null)
        request.RequestHeader = new RequestHeader();
      if (useDefaults)
        request.RequestHeader.ReturnDiagnostics = (uint) this.m_returnDiagnostics;
      if (request.RequestHeader.RequestHandle == 0U)
        request.RequestHeader.RequestHandle = (uint) Utils.IncrementIdentifier(ref this.m_nextRequestHandle);
      if (NodeId.IsNull(request.RequestHeader.AuthenticationToken))
        request.RequestHeader.AuthenticationToken = this.m_authenticationToken;
      request.RequestHeader.Timestamp = DateTime.UtcNow;
      request.RequestHeader.AuditEntryId = this.CreateAuditLogEntry(request);
    }
  }

  protected virtual void UpdateRequestHeader(
    IServiceRequest request,
    bool useDefaults,
    string serviceName)
  {
    this.UpdateRequestHeader(request, useDefaults);
    int pendingRequestCount = Interlocked.Increment(ref this.m_pendingRequestCount);
    Utils.EventLog.ServiceCallStart(serviceName, (int) request.RequestHeader.RequestHandle, pendingRequestCount);
  }

  protected virtual void RequestCompleted(
    IServiceRequest request,
    IServiceResponse response,
    string serviceName)
  {
    uint requestHandle = 0;
    StatusCode statusCode = (StatusCode) 0U;
    if (request != null)
      requestHandle = request.RequestHeader.RequestHandle;
    else if (response != null)
    {
      requestHandle = response.ResponseHeader.RequestHandle;
      statusCode = response.ResponseHeader.ServiceResult;
    }
    if (response == null)
      statusCode = (StatusCode) 2147483648U /*0x80000000*/;
    int pendingRequestCount = Interlocked.Decrement(ref this.m_pendingRequestCount);
    if (statusCode != 0U)
      Utils.EventLog.ServiceCallBadStop(serviceName, (int) requestHandle, (int) statusCode.Code, pendingRequestCount);
    else
      Utils.EventLog.ServiceCallStop(serviceName, (int) requestHandle, pendingRequestCount);
  }

  protected virtual string CreateAuditLogEntry(IServiceRequest request)
  {
    return request.RequestHeader.AuditEntryId;
  }

  protected static void ValidateResponse(ResponseHeader header)
  {
    if (header == null)
      throw new ServiceResultException(2148073472U /*0x80090000*/, "Null header in response.");
    if (StatusCode.IsBad(header.ServiceResult))
      throw new ServiceResultException(new ServiceResult(header.ServiceResult, header.ServiceDiagnostics, (IList<string>) header.StringTable));
  }

  public static void ValidateResponse(IList response, IList request)
  {
    if (response is DiagnosticInfoCollection)
      throw new ArgumentException("Must call ValidateDiagnosticInfos() for DiagnosticInfoCollections.", nameof (response));
    if (response == null || response.Count != request.Count)
      throw new ServiceResultException(2147549184U /*0x80010000*/, "The server returned a list without the expected number of elements.");
  }

  public static void ValidateDiagnosticInfos(DiagnosticInfoCollection response, IList request)
  {
    if (response != null && response.Count != 0 && response.Count != request.Count)
      throw new ServiceResultException(2147549184U /*0x80010000*/, "The server forgot to fill in the DiagnosticInfos array correctly when returning an operation level error.");
  }

  public static ServiceResult GetResult(
    StatusCode statusCode,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    return diagnosticInfos != null && diagnosticInfos.Count > index ? new ServiceResult((StatusCode) statusCode.Code, diagnosticInfos[index], (IList<string>) responseHeader.StringTable) : new ServiceResult(statusCode.Code);
  }

  public static ServiceResult ValidateDataValue(
    DataValue value,
    Type expectedType,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    if (value == null)
      return new ServiceResult((StatusCode) 2147549184U /*0x80010000*/, (LocalizedText) "The server returned a value for a data value.");
    if (StatusCode.IsBad(value.StatusCode))
      return ClientBase.GetResult(value.StatusCode, index, diagnosticInfos, responseHeader);
    if (!(expectedType != (Type) null) || expectedType.IsInstanceOfType(value.Value))
      return (ServiceResult) null;
    return ServiceResult.Create(2147549184U /*0x80010000*/, "The server returned data value of type {0} when a value of type {1} was expected.", value.Value != null ? (object) value.Value.GetType().Name : (object) "(null)", (object) expectedType.Name);
  }
}

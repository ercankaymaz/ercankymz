// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransportQuotas
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TransportQuotas
{
  private int m_operationTimeout;
  private int m_maxStringLength;
  private int m_maxByteStringLength;
  private int m_maxArrayLength;
  private int m_maxMessageSize;
  private int m_maxBufferSize;
  private int m_channelLifetime;
  private int m_securityTokenLifetime;

  public TransportQuotas() => this.Initialize();

  private void Initialize()
  {
    this.m_operationTimeout = 120000;
    this.m_maxStringLength = (int) ushort.MaxValue;
    this.m_maxByteStringLength = (int) ushort.MaxValue;
    this.m_maxArrayLength = (int) ushort.MaxValue;
    this.m_maxMessageSize = 1048576 /*0x100000*/;
    this.m_maxBufferSize = (int) ushort.MaxValue;
    this.m_channelLifetime = 600000;
    this.m_securityTokenLifetime = 3600000;
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, Order = 0)]
  public int OperationTimeout
  {
    get => this.m_operationTimeout;
    set => this.m_operationTimeout = value;
  }

  [DataMember(IsRequired = false, Order = 1)]
  public int MaxStringLength
  {
    get => this.m_maxStringLength;
    set => this.m_maxStringLength = value;
  }

  [DataMember(IsRequired = false, Order = 2)]
  public int MaxByteStringLength
  {
    get => this.m_maxByteStringLength;
    set => this.m_maxByteStringLength = value;
  }

  [DataMember(IsRequired = false, Order = 3)]
  public int MaxArrayLength
  {
    get => this.m_maxArrayLength;
    set => this.m_maxArrayLength = value;
  }

  [DataMember(IsRequired = false, Order = 4)]
  public int MaxMessageSize
  {
    get => this.m_maxMessageSize;
    set => this.m_maxMessageSize = value;
  }

  [DataMember(IsRequired = false, Order = 5)]
  public int MaxBufferSize
  {
    get => this.m_maxBufferSize;
    set => this.m_maxBufferSize = value;
  }

  [DataMember(IsRequired = false, Order = 6)]
  public int ChannelLifetime
  {
    get => this.m_channelLifetime;
    set => this.m_channelLifetime = value;
  }

  [DataMember(IsRequired = false, Order = 7)]
  public int SecurityTokenLifetime
  {
    get => this.m_securityTokenLifetime;
    set => this.m_securityTokenLifetime = value;
  }
}

// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointConfiguration : IEncodeable, ICloneable, IJsonEncodeable
{
  private int m_operationTimeout;
  private bool m_useBinaryEncoding;
  private int m_maxStringLength;
  private int m_maxByteStringLength;
  private int m_maxArrayLength;
  private int m_maxMessageSize;
  private int m_maxBufferSize;
  private int m_channelLifetime;
  private int m_securityTokenLifetime;

  public static EndpointConfiguration Create()
  {
    return new EndpointConfiguration()
    {
      OperationTimeout = 120000,
      UseBinaryEncoding = true,
      MaxArrayLength = (int) ushort.MaxValue,
      MaxByteStringLength = 1048560,
      MaxMessageSize = 4194240,
      MaxStringLength = (int) ushort.MaxValue,
      MaxBufferSize = (int) ushort.MaxValue,
      ChannelLifetime = 120000,
      SecurityTokenLifetime = 3600000
    };
  }

  public static EndpointConfiguration Create(ApplicationConfiguration applicationConfiguration)
  {
    if (applicationConfiguration == null || applicationConfiguration.TransportQuotas == null)
      return EndpointConfiguration.Create();
    return new EndpointConfiguration()
    {
      OperationTimeout = applicationConfiguration.TransportQuotas.OperationTimeout,
      UseBinaryEncoding = true,
      MaxArrayLength = applicationConfiguration.TransportQuotas.MaxArrayLength,
      MaxByteStringLength = applicationConfiguration.TransportQuotas.MaxByteStringLength,
      MaxMessageSize = applicationConfiguration.TransportQuotas.MaxMessageSize,
      MaxStringLength = applicationConfiguration.TransportQuotas.MaxStringLength,
      MaxBufferSize = applicationConfiguration.TransportQuotas.MaxBufferSize,
      ChannelLifetime = applicationConfiguration.TransportQuotas.ChannelLifetime,
      SecurityTokenLifetime = applicationConfiguration.TransportQuotas.SecurityTokenLifetime
    };
  }

  public EndpointConfiguration() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_operationTimeout = 0;
    this.m_useBinaryEncoding = true;
    this.m_maxStringLength = 0;
    this.m_maxByteStringLength = 0;
    this.m_maxArrayLength = 0;
    this.m_maxMessageSize = 0;
    this.m_maxBufferSize = 0;
    this.m_channelLifetime = 0;
    this.m_securityTokenLifetime = 0;
  }

  [DataMember(Name = "OperationTimeout", IsRequired = false, Order = 1)]
  public int OperationTimeout
  {
    get => this.m_operationTimeout;
    set => this.m_operationTimeout = value;
  }

  [DataMember(Name = "UseBinaryEncoding", IsRequired = false, Order = 2)]
  public bool UseBinaryEncoding
  {
    get => this.m_useBinaryEncoding;
    set => this.m_useBinaryEncoding = value;
  }

  [DataMember(Name = "MaxStringLength", IsRequired = false, Order = 3)]
  public int MaxStringLength
  {
    get => this.m_maxStringLength;
    set => this.m_maxStringLength = value;
  }

  [DataMember(Name = "MaxByteStringLength", IsRequired = false, Order = 4)]
  public int MaxByteStringLength
  {
    get => this.m_maxByteStringLength;
    set => this.m_maxByteStringLength = value;
  }

  [DataMember(Name = "MaxArrayLength", IsRequired = false, Order = 5)]
  public int MaxArrayLength
  {
    get => this.m_maxArrayLength;
    set => this.m_maxArrayLength = value;
  }

  [DataMember(Name = "MaxMessageSize", IsRequired = false, Order = 6)]
  public int MaxMessageSize
  {
    get => this.m_maxMessageSize;
    set => this.m_maxMessageSize = value;
  }

  [DataMember(Name = "MaxBufferSize", IsRequired = false, Order = 7)]
  public int MaxBufferSize
  {
    get => this.m_maxBufferSize;
    set => this.m_maxBufferSize = value;
  }

  [DataMember(Name = "ChannelLifetime", IsRequired = false, Order = 8)]
  public int ChannelLifetime
  {
    get => this.m_channelLifetime;
    set => this.m_channelLifetime = value;
  }

  [DataMember(Name = "SecurityTokenLifetime", IsRequired = false, Order = 9)]
  public int SecurityTokenLifetime
  {
    get => this.m_securityTokenLifetime;
    set => this.m_securityTokenLifetime = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EndpointConfiguration;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointConfiguration_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointConfiguration_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointConfiguration_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteInt32("OperationTimeout", this.OperationTimeout);
    encoder.WriteBoolean("UseBinaryEncoding", this.UseBinaryEncoding);
    encoder.WriteInt32("MaxStringLength", this.MaxStringLength);
    encoder.WriteInt32("MaxByteStringLength", this.MaxByteStringLength);
    encoder.WriteInt32("MaxArrayLength", this.MaxArrayLength);
    encoder.WriteInt32("MaxMessageSize", this.MaxMessageSize);
    encoder.WriteInt32("MaxBufferSize", this.MaxBufferSize);
    encoder.WriteInt32("ChannelLifetime", this.ChannelLifetime);
    encoder.WriteInt32("SecurityTokenLifetime", this.SecurityTokenLifetime);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.OperationTimeout = decoder.ReadInt32("OperationTimeout");
    this.UseBinaryEncoding = decoder.ReadBoolean("UseBinaryEncoding");
    this.MaxStringLength = decoder.ReadInt32("MaxStringLength");
    this.MaxByteStringLength = decoder.ReadInt32("MaxByteStringLength");
    this.MaxArrayLength = decoder.ReadInt32("MaxArrayLength");
    this.MaxMessageSize = decoder.ReadInt32("MaxMessageSize");
    this.MaxBufferSize = decoder.ReadInt32("MaxBufferSize");
    this.ChannelLifetime = decoder.ReadInt32("ChannelLifetime");
    this.SecurityTokenLifetime = decoder.ReadInt32("SecurityTokenLifetime");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EndpointConfiguration endpointConfiguration && Utils.IsEqual((object) this.m_operationTimeout, (object) endpointConfiguration.m_operationTimeout) && Utils.IsEqual((object) this.m_useBinaryEncoding, (object) endpointConfiguration.m_useBinaryEncoding) && Utils.IsEqual((object) this.m_maxStringLength, (object) endpointConfiguration.m_maxStringLength) && Utils.IsEqual((object) this.m_maxByteStringLength, (object) endpointConfiguration.m_maxByteStringLength) && Utils.IsEqual((object) this.m_maxArrayLength, (object) endpointConfiguration.m_maxArrayLength) && Utils.IsEqual((object) this.m_maxMessageSize, (object) endpointConfiguration.m_maxMessageSize) && Utils.IsEqual((object) this.m_maxBufferSize, (object) endpointConfiguration.m_maxBufferSize) && Utils.IsEqual((object) this.m_channelLifetime, (object) endpointConfiguration.m_channelLifetime) && Utils.IsEqual((object) this.m_securityTokenLifetime, (object) endpointConfiguration.m_securityTokenLifetime);
  }

  public virtual object Clone() => (object) (EndpointConfiguration) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointConfiguration endpointConfiguration = (EndpointConfiguration) base.MemberwiseClone();
    endpointConfiguration.m_operationTimeout = (int) Utils.Clone((object) this.m_operationTimeout);
    endpointConfiguration.m_useBinaryEncoding = (bool) Utils.Clone((object) this.m_useBinaryEncoding);
    endpointConfiguration.m_maxStringLength = (int) Utils.Clone((object) this.m_maxStringLength);
    endpointConfiguration.m_maxByteStringLength = (int) Utils.Clone((object) this.m_maxByteStringLength);
    endpointConfiguration.m_maxArrayLength = (int) Utils.Clone((object) this.m_maxArrayLength);
    endpointConfiguration.m_maxMessageSize = (int) Utils.Clone((object) this.m_maxMessageSize);
    endpointConfiguration.m_maxBufferSize = (int) Utils.Clone((object) this.m_maxBufferSize);
    endpointConfiguration.m_channelLifetime = (int) Utils.Clone((object) this.m_channelLifetime);
    endpointConfiguration.m_securityTokenLifetime = (int) Utils.Clone((object) this.m_securityTokenLifetime);
    return (object) endpointConfiguration;
  }
}

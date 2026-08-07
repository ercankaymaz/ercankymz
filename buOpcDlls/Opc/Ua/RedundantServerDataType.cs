// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RedundantServerDataType
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
public class RedundantServerDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_serverId;
  private byte m_serviceLevel;
  private ServerState m_serverState;

  public RedundantServerDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_serverId = (string) null;
    this.m_serviceLevel = (byte) 0;
    this.m_serverState = ServerState.Running;
  }

  [DataMember(Name = "ServerId", IsRequired = false, Order = 1)]
  public string ServerId
  {
    get => this.m_serverId;
    set => this.m_serverId = value;
  }

  [DataMember(Name = "ServiceLevel", IsRequired = false, Order = 2)]
  public byte ServiceLevel
  {
    get => this.m_serviceLevel;
    set => this.m_serviceLevel = value;
  }

  [DataMember(Name = "ServerState", IsRequired = false, Order = 3)]
  public ServerState ServerState
  {
    get => this.m_serverState;
    set => this.m_serverState = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RedundantServerDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RedundantServerDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RedundantServerDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RedundantServerDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ServerId", this.ServerId);
    encoder.WriteByte("ServiceLevel", this.ServiceLevel);
    encoder.WriteEnumerated("ServerState", (Enum) this.ServerState);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ServerId = decoder.ReadString("ServerId");
    this.ServiceLevel = decoder.ReadByte("ServiceLevel");
    this.ServerState = (ServerState) decoder.ReadEnumerated("ServerState", typeof (ServerState));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RedundantServerDataType redundantServerDataType && Utils.IsEqual((object) this.m_serverId, (object) redundantServerDataType.m_serverId) && Utils.IsEqual((object) this.m_serviceLevel, (object) redundantServerDataType.m_serviceLevel) && Utils.IsEqual((object) this.m_serverState, (object) redundantServerDataType.m_serverState);
  }

  public virtual object Clone() => (object) (RedundantServerDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RedundantServerDataType redundantServerDataType = (RedundantServerDataType) base.MemberwiseClone();
    redundantServerDataType.m_serverId = (string) Utils.Clone((object) this.m_serverId);
    redundantServerDataType.m_serviceLevel = (byte) Utils.Clone((object) this.m_serviceLevel);
    redundantServerDataType.m_serverState = (ServerState) Utils.Clone((object) this.m_serverState);
    return (object) redundantServerDataType;
  }
}
